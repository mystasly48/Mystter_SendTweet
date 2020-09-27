using System;
using System.Diagnostics;
using System.Windows.Forms;
using Mystter_SendTweet.Languages;

namespace Mystter_SendTweet {
  public partial class AboutForm : Form {
    public AboutForm() {
      InitializeComponent();
    }

    private void AboutForm_Load(object sender, EventArgs e) {
      ApplyLocalization();
      ApplyInformation();
    }

    private void repoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      Process.Start(repoLinkLabel.Text);
    }

    private void twitterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      Process.Start(twitterLinkLabel.Text);
    }

    private void ApplyInformation() {
      nameLabel.Text = Information.Title;
      verLabel.Text = Information.Version;
      developerLabel.Text = Information.Developer;
      repoLinkLabel.Text = Information.Repository;
      twitterLinkLabel.Text = Information.Twitter;
    }

    private void ApplyLocalization() {
      this.Text = Information.Title + " - " + Resources.About;
      verLabelTitle.Text = Resources.Version + ":";
      developerLabelTitle.Text = Resources.Developer + ":";
      repoLinkLabelTitle.Text = Resources.ProjectRepository + ":";
      twitterLinkLabelTitle.Text = Resources.DeveloperTwitter + ":";
    }
  }
}
