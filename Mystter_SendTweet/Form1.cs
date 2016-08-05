using System;
using System.Windows.Forms;
using CoreTweet;

namespace Mystter_SendTweet {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        #region Form

        private void Form1_Load(object sender, EventArgs e) {
            SettingsInit();
            TwitterInit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            settings.TopMost = TopMost;
            settings.Location = this.Location;
            settings.SelectedItem = comboBox1.SelectedItem.ToString();
            Settings.Save(settings);
        }

        private void button1_Click(object sender, EventArgs e) {
            button1.Enabled = false;
            SendTweet();
            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            var selected = comboBox1.SelectedItem.ToString();
            if (selected == "Add account") {
                comboBox1.SelectedItem = settings.SelectedItem;
                AddAccount();
            } else {
                tokens = GetAccountTokens(comboBox1.SelectedItem.ToString());
            }
        }


        private void richTextBox1_KeyDown(object sender, KeyEventArgs e) {
            if (e.Control && e.KeyCode == Keys.Enter) {
                button1.PerformClick();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            var length = richTextBox1.TextLength;
            label1.Text = length.ToString();
            if (length <= 140) {
                label1.ForeColor = System.Drawing.SystemColors.WindowText;
            } else if (length > 140) {
                label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            TopMost = checkBox1.Checked;
        }

        private void button2_Click(object sender, EventArgs e) {

        }

        #endregion

        Settings settings = new Settings();
        Tokens tokens;

        private void SettingsInit() {
            settings = Settings.Load();
            TopMost = settings.TopMost;
            checkBox1.Checked = this.TopMost;
            Location = settings.Location;
        }

        private void TwitterInit() {
            if (settings.Twitter.Count > 0) {
                for (int i = 0; i < settings.Twitter.Count; i++) {
                    var account = new Account();
                    account = settings.Twitter[i];
                    comboBox1.Items.Add(account.ScreenName);
                }
                comboBox1.SelectedItem = settings.SelectedItem;
                tokens = GetAccountTokens(settings.SelectedItem);
            } else {
                AddAccount();
            }
        }

        private void DeleteLatestTweet() {
            var latest = tokens.Account.UpdateProfile().Status;
            tokens.Statuses.Destroy(latest);
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

            Settings.Save(settings);

            comboBox1.Items.Add(screen);
            comboBox1.SelectedItem = screen;
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
        }

        private void SendTweet() {
            var msg = richTextBox1.Text;
            if (msg.Length > 140) {
                MessageBox.Show("Tweet is too long!");
                return;
            }
            if (msg.Length < 1) {
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
                throw;
            } catch {
                throw;
            }
            richTextBox1.Text = "";
            richTextBox1.Focus();
        }
    }
}
