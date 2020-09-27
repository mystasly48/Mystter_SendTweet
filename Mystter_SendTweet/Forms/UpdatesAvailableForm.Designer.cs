namespace Mystter_SendTweet {
  partial class UpdatesAvailableForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatesAvailableForm));
      this.availableLabel = new System.Windows.Forms.Label();
      this.updateButton = new System.Windows.Forms.Button();
      this.laterButton = new System.Windows.Forms.Button();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
      this.SuspendLayout();
      // 
      // availableLabel
      // 
      this.availableLabel.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.availableLabel.Location = new System.Drawing.Point(34, 25);
      this.availableLabel.Name = "availableLabel";
      this.availableLabel.Size = new System.Drawing.Size(617, 63);
      this.availableLabel.TabIndex = 0;
      this.availableLabel.Text = "Updates Available!";
      this.availableLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // updateButton
      // 
      this.updateButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
      this.updateButton.FlatAppearance.BorderSize = 0;
      this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.updateButton.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.updateButton.ForeColor = System.Drawing.SystemColors.Control;
      this.updateButton.Location = new System.Drawing.Point(350, 600);
      this.updateButton.Name = "updateButton";
      this.updateButton.Size = new System.Drawing.Size(140, 50);
      this.updateButton.TabIndex = 1;
      this.updateButton.Text = "Update";
      this.updateButton.UseVisualStyleBackColor = false;
      this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
      // 
      // laterButton
      // 
      this.laterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.laterButton.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.laterButton.Location = new System.Drawing.Point(511, 599);
      this.laterButton.Name = "laterButton";
      this.laterButton.Size = new System.Drawing.Size(140, 50);
      this.laterButton.TabIndex = 2;
      this.laterButton.Text = "Later";
      this.laterButton.UseVisualStyleBackColor = true;
      this.laterButton.Click += new System.EventHandler(this.laterButton_Click);
      // 
      // textBox1
      // 
      this.textBox1.BackColor = System.Drawing.SystemColors.Control;
      this.textBox1.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.textBox1.Location = new System.Drawing.Point(39, 102);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.textBox1.Size = new System.Drawing.Size(612, 441);
      this.textBox1.TabIndex = 3;
      this.textBox1.TabStop = false;
      // 
      // progressBar1
      // 
      this.progressBar1.Enabled = false;
      this.progressBar1.Location = new System.Drawing.Point(39, 549);
      this.progressBar1.MarqueeAnimationSpeed = 1;
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(612, 44);
      this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
      this.progressBar1.TabIndex = 4;
      this.progressBar1.Visible = false;
      // 
      // backgroundWorker1
      // 
      this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
      this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
      // 
      // UpdatesAvailableForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(684, 661);
      this.Controls.Add(this.progressBar1);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.laterButton);
      this.Controls.Add(this.updateButton);
      this.Controls.Add(this.availableLabel);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UpdatesAvailableForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Mystter - Updater";
      this.Load += new System.EventHandler(this.UpdatesAvailableForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label availableLabel;
    private System.Windows.Forms.Button updateButton;
    private System.Windows.Forms.Button laterButton;
    private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}