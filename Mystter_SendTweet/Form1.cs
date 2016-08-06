using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using CoreTweet;

namespace Mystter_SendTweet {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        Settings settings = new Settings();
        Tokens tokens;

        #region Form

        private void Form1_Load(object sender, EventArgs e) {
            LoadSettings();
            SettingsInit();
            TwitterInit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            settings.Location = Location;
            settings.TopMost = TopMost;
            settings.SelectedItem = accountsComboBox.SelectedItem.ToString();
            settings.WordWrap = richTextBox1.WordWrap;
            SaveSettings();
        }

        private void Form1_LocationChanged(object sender, EventArgs e) {
            ChangeLocation(Location);
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
            var length = richTextBox1.TextLength;
            lengthLabel1.Text = length.ToString();
            if (length <= 140) {
                lengthLabel1.ForeColor = System.Drawing.SystemColors.WindowText;
            } else if (length > 140) {
                lengthLabel1.ForeColor = System.Drawing.Color.Red;
            }
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

        #endregion

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
            tokens.Statuses.Destroy(latest.Id);
        }

        private void SetAccountTokens(Tokens _tokens) {
            var token = _tokens.AccessToken;
            var secret = _tokens.AccessTokenSecret;
            var screen = _tokens.ScreenName;
            var id = _tokens.UserId;

            if (IsDuplicate(id)) {
                MessageBox.Show("既に登録されています。");
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
            AuthBrowser form = new AuthBrowser();
            var s = OAuth.Authorize(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret);
            form.URL = s.AuthorizeUri.AbsoluteUri;
            form.ShowDialog();
            if (form.Success) {
                Tokens _tokens = s.GetTokens(form.PIN);
                SetAccountTokens(_tokens);
            }
            form.Dispose();
        }

        private void SendTweet(string msg) {
            if (msg.Length > 140) {
                MessageBox.Show("Tweet is too long!");
                return;
            }
            if (IsEmpty(msg)) {
                MessageBox.Show("Tweet is too short!");
                return;
            }

            try {
                tokens.Statuses.Update(status: msg);
            } catch (TwitterException ex) {
                if (ex.Message.Contains("Status is a duplicate")) {
                    MessageBox.Show("Status is a duplicate!");
                    return;
                }
                MessageBox.Show("Twitter Exception!");
                throw;
            } catch {
                MessageBox.Show("Unknown Exception!");
                throw;
            }

            richTextBox1.Text = "";
            richTextBox1.Focus();
        }

        private bool IsEmpty(string str) {
            str = str.Replace(" ", "");
            str = str.Replace("　", "");
            str = str.Replace("\r\n", "");
            if (str.Length == 0) {
                return true;
            } else {
                return false;
            }
        }
    }
}
