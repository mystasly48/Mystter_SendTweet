using Mystter_SendTweet.Languages;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Mystter_SendTweet.Forms {
  public partial class UpdatesAvailableForm : Form {
    Updater updater;
    string installerDestination;
    public UpdatesAvailableForm(Updater updater) {
      InitializeComponent();
      this.updater = updater;
    }

    private void UpdatesAvailableForm_Load(object sender, EventArgs e) {
      availableLabel.Text = Resources.UpdatesAvailableMessage;
      // "Release notes 1.4.1 (04/25/2020)"
      var notes = updater.NewerReleases
        .Select(x => $"{Resources.ReleaseNotes} {x.Version} ({x.ReleasedAt:MM/dd/yyyy}){Environment.NewLine}{x.ReleaseNotes}{Environment.NewLine}");
      textBox1.Text = string.Join(Environment.NewLine, notes);
      updateButton.Text = Resources.Update;
      laterButton.Text = Resources.Later;
    }

    private void updateButton_Click(object sender, EventArgs e) {
      updateButton.Enabled = false;
      laterButton.Enabled = false;
      progressBar1.Visible = true;
      progressBar1.Enabled = true;
      backgroundWorker1.RunWorkerAsync();
    }

    private void laterButton_Click(object sender, EventArgs e) {
      Close();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
      installerDestination = updater.LatestRelease.DownloadDestination;
      using (var wc = new WebClient()) {
        wc.DownloadFile(new Uri(updater.LatestRelease.InstallerDownloadUrl), installerDestination);
      }
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      progressBar1.Enabled = false;
      progressBar1.Visible = false;
      Process.Start(installerDestination);
      Close();
    }
  }
}
