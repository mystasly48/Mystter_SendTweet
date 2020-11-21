using Mystter_SendTweet.Languages;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Mystter_SendTweet.Forms {
  public partial class UpdatesUnavailableForm : Form {
    ReleaseInformation info;

    public UpdatesUnavailableForm(ReleaseInformation info) {
      InitializeComponent();
      this.info = info;
    }

    private void okButton_Click(object sender, EventArgs e) {
      Close();
    }

    private void UpdatesUnavailableForm_Load(object sender, EventArgs e) {
      latestLabel.Text = Resources.onTheLatestLabel;
      versionLabel.Text = Resources.latestVersionLabel.Replace("{version}", info.Version);
      releaseNotesLink.Text = Resources.ReleaseNotes;
    }

    private void releaseNotesLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      Process.Start(info.ReleaseUrl);
    }
  }
}
