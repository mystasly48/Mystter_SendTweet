namespace Mystter_SendTweet.Forms {
  partial class CheckingUpdatesForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckingUpdatesForm));
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.checkingForUpdatesLabe = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      // 
      // progressBar1
      // 
      this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.progressBar1.Enabled = false;
      this.progressBar1.Location = new System.Drawing.Point(7, 140);
      this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.progressBar1.MarqueeAnimationSpeed = 1;
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(396, 26);
      this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      this.progressBar1.TabIndex = 0;
      // 
      // checkingForUpdatesLabe
      // 
      this.checkingForUpdatesLabe.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.checkingForUpdatesLabe.Location = new System.Drawing.Point(7, 20);
      this.checkingForUpdatesLabe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
      this.checkingForUpdatesLabe.Name = "checkingForUpdatesLabe";
      this.checkingForUpdatesLabe.Size = new System.Drawing.Size(396, 103);
      this.checkingForUpdatesLabe.TabIndex = 1;
      this.checkingForUpdatesLabe.Text = "Checking for updates...";
      this.checkingForUpdatesLabe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // CheckingUpdatesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(410, 174);
      this.Controls.Add(this.checkingForUpdatesLabe);
      this.Controls.Add(this.progressBar1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CheckingUpdatesForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Mystter - Check for Updates";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.CheckingUpdatesForm_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label checkingForUpdatesLabe;
  }
}