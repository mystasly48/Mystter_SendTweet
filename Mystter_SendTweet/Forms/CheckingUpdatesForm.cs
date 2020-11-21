using Mystter_SendTweet.Languages;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Mystter_SendTweet.Forms {
  public partial class CheckingUpdatesForm : Form {
    public Updater Updater { get; private set; }

    public CheckingUpdatesForm() {
      InitializeComponent();
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
      this.Updater = new Updater();
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
      progressBar1.Enabled = false;
      Close();
    }

    private void CheckingUpdatesForm_Load(object sender, EventArgs e) {
      label1.Text = Resources.checkingForUpdates;
      progressBar1.Enabled = true;
      backgroundWorker1.RunWorkerAsync();
    }
  }
}
