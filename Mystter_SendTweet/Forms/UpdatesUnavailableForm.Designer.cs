namespace Mystter_SendTweet.Forms {
  partial class UpdatesUnavailableForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatesUnavailableForm));
      this.okButton = new System.Windows.Forms.Button();
      this.latestLabel = new System.Windows.Forms.Label();
      this.versionLabel = new System.Windows.Forms.Label();
      this.releaseNotesLink = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.okButton.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.okButton.Location = new System.Drawing.Point(266, 204);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(140, 50);
      this.okButton.TabIndex = 2;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // latestLabel
      // 
      this.latestLabel.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.latestLabel.Location = new System.Drawing.Point(12, 28);
      this.latestLabel.Name = "latestLabel";
      this.latestLabel.Size = new System.Drawing.Size(660, 59);
      this.latestLabel.TabIndex = 0;
      this.latestLabel.Text = "You are up to date.";
      this.latestLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // versionLabel
      // 
      this.versionLabel.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.versionLabel.Location = new System.Drawing.Point(127, 107);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(428, 47);
      this.versionLabel.TabIndex = 3;
      this.versionLabel.Text = "Lateset version: {version}";
      this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // releaseNotesLink
      // 
      this.releaseNotesLink.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.releaseNotesLink.Location = new System.Drawing.Point(127, 154);
      this.releaseNotesLink.Name = "releaseNotesLink";
      this.releaseNotesLink.Size = new System.Drawing.Size(428, 47);
      this.releaseNotesLink.TabIndex = 5;
      this.releaseNotesLink.TabStop = true;
      this.releaseNotesLink.Text = "Release notes";
      this.releaseNotesLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.releaseNotesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.releaseNotesLink_LinkClicked);
      // 
      // UpdatesUnavailableForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 261);
      this.Controls.Add(this.releaseNotesLink);
      this.Controls.Add(this.versionLabel);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.latestLabel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UpdatesUnavailableForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Mystter - Updater";
      this.Load += new System.EventHandler(this.UpdatesUnavailableForm_Load);
      this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Label latestLabel;
    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.LinkLabel releaseNotesLink;
  }
}