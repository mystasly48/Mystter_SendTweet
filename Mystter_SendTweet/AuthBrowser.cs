using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Mystter_SendTweet.Languages;

namespace Mystter_SendTweet {
    public partial class AuthBrowser : Form {
        public AuthBrowser() {
            InitializeComponent();
            Success = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (webBrowser1.Url.OriginalString == "https://api.twitter.com/oauth/authorize") {
                Regex r = new Regex(@"<CODE>(\d+)</CODE>");
                Match m = r.Match(webBrowser1.DocumentText);
                PIN = m.Result("${1}");
                Success = true;
                this.Close();
            }
        }

        public bool Success { get; set; }

        public string PIN { get; set; }

        public string URL { get; set; }

        private void AuthBrowser_Load(object sender, EventArgs e) {
            this.Text = Information.TitleSimple + " - " + Resources.OAuth;
            webBrowser1.Navigate(new Uri(URL));
        }

        private void AuthBrowser_FormClosing(object sender, FormClosingEventArgs e) {
            webBrowser1.Dispose();
        }
    }
}
