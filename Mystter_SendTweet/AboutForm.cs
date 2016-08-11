using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mystter_SendTweet {
    public partial class AboutForm : Form {
        public AboutForm() {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e) {
            nameLabel.Text = Information.Title;
            verLabel.Text = Information.Version;
            authorLabel.Text = Information.Author;
            repoLinkLabel.Text = Information.Repository;
            twitterLinkLabel.Text = Information.Twitter;
        }

        private void repoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(repoLinkLabel.Text);
        }

        private void twitterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start(twitterLinkLabel.Text);
        }
    }
}
