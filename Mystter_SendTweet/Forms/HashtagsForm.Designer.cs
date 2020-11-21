namespace Mystter_SendTweet.Forms {
  partial class HashtagsForm {
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HashtagsForm));
      this.addButton = new System.Windows.Forms.Button();
      this.hashtagTextBox = new System.Windows.Forms.TextBox();
      this.hashtagsListBox = new System.Windows.Forms.CheckedListBox();
      this.cancelButton = new System.Windows.Forms.Button();
      this.applyButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // addButton
      // 
      this.addButton.Location = new System.Drawing.Point(333, 21);
      this.addButton.Name = "addButton";
      this.addButton.Size = new System.Drawing.Size(75, 23);
      this.addButton.TabIndex = 0;
      this.addButton.Text = "Add";
      this.addButton.UseVisualStyleBackColor = true;
      this.addButton.Click += new System.EventHandler(this.addButton_Click);
      // 
      // hashtagTextBox
      // 
      this.hashtagTextBox.Location = new System.Drawing.Point(22, 25);
      this.hashtagTextBox.Name = "hashtagTextBox";
      this.hashtagTextBox.Size = new System.Drawing.Size(295, 19);
      this.hashtagTextBox.TabIndex = 1;
      this.hashtagTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hashtagTextBox_KeyDown);
      // 
      // hashtagsListBox
      // 
      this.hashtagsListBox.FormattingEnabled = true;
      this.hashtagsListBox.Location = new System.Drawing.Point(22, 65);
      this.hashtagsListBox.Name = "hashtagsListBox";
      this.hashtagsListBox.Size = new System.Drawing.Size(386, 172);
      this.hashtagsListBox.TabIndex = 2;
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(252, 258);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 3;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // applyButton
      // 
      this.applyButton.Location = new System.Drawing.Point(92, 258);
      this.applyButton.Name = "applyButton";
      this.applyButton.Size = new System.Drawing.Size(75, 23);
      this.applyButton.TabIndex = 4;
      this.applyButton.Text = "Apply";
      this.applyButton.UseVisualStyleBackColor = true;
      this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
      // 
      // HashtagsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(434, 293);
      this.Controls.Add(this.applyButton);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.hashtagsListBox);
      this.Controls.Add(this.hashtagTextBox);
      this.Controls.Add(this.addButton);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "HashtagsForm";
      this.Text = "Mystter - Hashtags";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button addButton;
    private System.Windows.Forms.TextBox hashtagTextBox;
    private System.Windows.Forms.CheckedListBox hashtagsListBox;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button applyButton;
  }
}