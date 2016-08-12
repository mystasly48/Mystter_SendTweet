﻿using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using CoreTweet;
using Mystter_SendTweet.Languages;

namespace Mystter_SendTweet {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Settings settings = new Settings();
        Tokens tokens;
        String NL = Environment.NewLine;

        #region Form

        private void Form1_Load(object sender, EventArgs e) {
            LoadSettings();
            SettingsInit();
            TwitterInit();
            ActiveControl = richTextBox1;
        }

        private void Form1_LocationChanged(object sender, EventArgs e) {
            if (this.WindowState != FormWindowState.Minimized) {
                ChangeLocation(Location);
            }
        }

        private void sendBtn_Click(object sender, EventArgs e) {
            DisabledButton(sendBtn);
            SendTweet(richTextBox1.Text);
            EnabledButton(sendBtn);
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.Enter) {
                sendBtn.PerformClick();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            IsTweetable();
        }

        // Delete Last Tweet
        private void deleteBtn_Click(object sender, EventArgs e) {
            DisabledButton(deleteBtn);
            DeleteLatestTweet();
            EnabledButton(deleteBtn);
        }

        // Add account
        private void addAccountMenuItem_Click(object sender, EventArgs e) {
            AddAccount();
        }
        
        // Switch account
        private void accountsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            var selected = accountsComboBox.SelectedItem.ToString();
            tokens = GetAccountTokens(selected);
            ChangeSelectedItem(selected);
        }

        // Top Most
        private void topMostMenuItem_Click(object sender, EventArgs e) {
            ChangeTopMost(topMostMenuItem.Checked);
        }
        
        // Word Wrap
        private void wordWrapMenuItem_Click(object sender, EventArgs e) {
            ChangeWordWrap(wordWrapMenuItem.Checked);
        }

        // About
        private void aboutMenuItem_Click(object sender, EventArgs e) {
            AboutForm form = new AboutForm();
            form.ShowDialog();
        }

        // Language
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var selected = languagesComboBox.SelectedIndex;
            var lang = Localization.GetLanguageParent(selected);
            ChangeLanguage(lang);
        }

        #endregion

        #region Method

        private void IsTweetable() {
            var text = richTextBox1.Text;
            var length = richTextBox1.TextLength;
            lengthLabel1.Text = length.ToString();
            if (length > 140) {
                DisabledButton(sendBtn);
                lengthLabel1.ForeColor = Color.Red;
            } else if (length == 0 || IsEmpty(text)) {
                DisabledButton(sendBtn);
            } else {
                EnabledButton(sendBtn);
                lengthLabel1.ForeColor = SystemColors.WindowText;
            }
        }

        private void ChangeSelectedItem(string item) {
            accountsComboBox.SelectedItem = item;
            settings.SelectedItem = item;
            SaveSettings();
        }

        private void ChangeTopMost(bool top) {
            TopMost = top;
            topMostMenuItem.Checked = top;
            settings.TopMost = top;
            SaveSettings();
        }

        private void ChangeWordWrap(bool wrap) {
            richTextBox1.WordWrap = wrap;
            wordWrapMenuItem.Checked = wrap;
            settings.WordWrap = wrap;
            SaveSettings();
        }

        private void ChangeLocation(Point location) {
            Location = location;
            settings.Location = location;
            SaveSettings();
        }

        private void SettingsInit() {
            ChangeLanguage(settings.Language);
            ChangeTopMost(settings.TopMost);
            ChangeLocation(settings.Location);
            ChangeWordWrap(settings.WordWrap);
        }

        private void TwitterInit() {
            if (settings.Twitter.Count > 0) {
                for (int i = 0; i < settings.Twitter.Count; i++) {
                    var account = new Account();
                    account = settings.Twitter[i];
                    accountsComboBox.Items.Add(account.ScreenName);
                }
                accountsComboBox.SelectedItem = settings.SelectedItem;
                tokens = GetAccountTokens(settings.SelectedItem);
            } else {
                AddAccount();
            }
        }

        string SettingsFile = Information.Title + ".xml";

        private void SaveSettings() {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            StreamWriter writer = new StreamWriter(SettingsFile, false, Encoding.UTF8);
            serializer.Serialize(writer, settings);
            writer.Close();
        }

        private void LoadSettings() {
            if (File.Exists(SettingsFile)) {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                StreamReader reader = new StreamReader(SettingsFile);
                settings = (Settings)serializer.Deserialize(reader);
                reader.Close();
            } else {
                SaveSettings();
                LoadSettings();
            }
        }

        private void DisabledButton(Button btn) {
            btn.Enabled = false;
        }

        private void EnabledButton(Button btn) {
            btn.Enabled = true;
        }

        private void SetStatusMessage(string msg) {
            statusLabel1.Text = msg;
        }

        private void DeleteLatestTweet() {
            var latest = tokens.Account.UpdateProfile().Status;
            var msgResult = MessageBox.Show(Resources.deleteComfirm + NL + "------------------------------" + NL + latest.Text + NL + "------------------------------", Information.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (msgResult) {
                case DialogResult.Yes:
                    tokens.Statuses.Destroy(latest.Id);
                    MessageBox.Show(Resources.deleteYes, Information.Title);
                    break;
                case DialogResult.No:
                    MessageBox.Show(Resources.deleteNo, Information.Title);
                    break;
            }
        }

        private void SetAccountTokens(Tokens _tokens) {
            var token = _tokens.AccessToken;
            var secret = _tokens.AccessTokenSecret;
            var screen = _tokens.ScreenName;
            var id = _tokens.UserId;

            if (IsDuplicate(id)) {
                MessageBox.Show(Resources.alreadyAdded);
                return;
            }

            var account = new Account();
            account.AccessToken = token;
            account.AccessSecret = secret;
            account.ScreenName = screen;
            account.UserId = id;

            settings.Twitter.Add(account);
            
            accountsComboBox.Items.Add(screen);

            ChangeSelectedItem(screen);
        }

        private Tokens GetAccountTokens(string screen) {
            var account = new Account();
            for (int i = 0; i < settings.Twitter.Count; i++) {
                account = settings.Twitter[i];
                if (account.ScreenName.Equals(screen)) {
                    Tokens _tokens = Tokens.Create(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, account.AccessToken, account.AccessSecret);
                    return _tokens;
                }
            }
            return null;
        }

        private bool IsDuplicate(long userId) {
            var account = new Account();
            for (int i = 0; i < settings.Twitter.Count; i++) {
                account = settings.Twitter[i];
                if (account.UserId == userId) {
                    return true;
                }
            }
            return false;
        }

        private void AddAccount() {
            START:
            AuthBrowser form = new AuthBrowser();
            var s = OAuth.Authorize(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret);
            form.URL = s.AuthorizeUri.AbsoluteUri;
            form.ShowDialog();
            if (form.Success) {
                Tokens _tokens = s.GetTokens(form.PIN);
                SetAccountTokens(_tokens);
            } else if (settings.Twitter.Count == 0) {
                var result = MessageBox.Show(Resources.yetAdded1 + NL + Resources.yetAdded2, Information.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (result) {
                    case DialogResult.Yes:
                        goto START;
                    case DialogResult.No:
                        Environment.Exit(0);
                        break;
                }
            }
            form.Dispose();
        }

        private void SendTweet(string msg) {
            if (IsEmpty(msg)) {
                MessageBox.Show(Resources.tooShort);
                return;
            } else if (msg.Length > 140) {
                MessageBox.Show(Resources.tooLong);
                return;
            }
            try {
                tokens.Statuses.Update(status: msg);
            } catch (TwitterException ex) {
                if (ex.Message.Contains("Status is a duplicate")) {
                    MessageBox.Show(Resources.duplicate);
                    return;
                }
                MessageBox.Show(Resources.TwitterException);
                throw;
            } catch {
                MessageBox.Show(Resources.UnknownException);
                throw;
            }
            richTextBox1.Text = "";
            richTextBox1.Focus();
        }

        private bool IsEmpty(string str) {
            str = str.Replace(" ", "");
            str = str.Replace("　", "");
            str = str.Replace("\r", "");
            str = str.Replace("\n", "");
            if (str.Length == 0) {
                return true;
            } else {
                return false;
            }
        }

        private void ApplyLocalization() {
            sendBtn.Text = Resources.sendBtn;
            deleteBtn.Text = Resources.deleteBtn;
            accountsMenuTitle.Text = Resources.accountMenuTitle;
            addAccountMenuItem.Text = Resources.addAccountMenuItem;
            settingsMenuTitle.Text = Resources.settingsMenuTitle;
            topMostMenuItem.Text = Resources.topMostMenuItem;
            wordWrapMenuItem.Text = Resources.wordWrapMenuItem;
            helpMenuTitle.Text = Resources.helpMenuTitle;
            aboutMenuItem.Text = Resources.aboutMenuItem;
            languageMenuItem.Text = Resources.Language;
            languagesComboBox.Items.Clear();
            languagesComboBox.Items.Add(Resources.English);
            languagesComboBox.Items.Add(Resources.Japanese);
            languagesComboBox.SelectedItem = Localization.GetLanguageFullName(Localization.CurrentLanguage);
        }

        private void ChangeLanguage(string lang) {
            if (Localization.ChangeLanguage(lang)) {
                settings.Language = lang;
                SaveSettings();
                ApplyLocalization();
            }
        }
        
        #endregion
    }
}