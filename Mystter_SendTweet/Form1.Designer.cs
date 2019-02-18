namespace Mystter_SendTweet {
    partial class Form1 {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.richTextBox1 = new System.Windows.Forms.RichTextBox();
      this.sendBtn = new System.Windows.Forms.Button();
      this.lengthLabel1 = new System.Windows.Forms.Label();
      this.lengthLabel2 = new System.Windows.Forms.Label();
      this.lengthLabel3 = new System.Windows.Forms.Label();
      this.deleteBtn = new System.Windows.Forms.Button();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.accountsMenuTitle = new System.Windows.Forms.ToolStripMenuItem();
      this.addAccountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.accountsComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.settingsMenuTitle = new System.Windows.Forms.ToolStripMenuItem();
      this.topMostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.wordWrapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.languageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.languagesComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.helpMenuTitle = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // richTextBox1
      // 
      this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.richTextBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F);
      this.richTextBox1.Location = new System.Drawing.Point(20, 40);
      this.richTextBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.richTextBox1.Name = "richTextBox1";
      this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
      this.richTextBox1.Size = new System.Drawing.Size(646, 271);
      this.richTextBox1.TabIndex = 1;
      this.richTextBox1.Text = "";
      this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
      this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
      // 
      // sendBtn
      // 
      this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.sendBtn.Enabled = false;
      this.sendBtn.Location = new System.Drawing.Point(543, 322);
      this.sendBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.sendBtn.Name = "sendBtn";
      this.sendBtn.Size = new System.Drawing.Size(125, 34);
      this.sendBtn.TabIndex = 2;
      this.sendBtn.Text = "Send";
      this.sendBtn.UseVisualStyleBackColor = true;
      this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
      // 
      // lengthLabel1
      // 
      this.lengthLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lengthLabel1.BackColor = System.Drawing.SystemColors.Control;
      this.lengthLabel1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F);
      this.lengthLabel1.Location = new System.Drawing.Point(235, 328);
      this.lengthLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lengthLabel1.Name = "lengthLabel1";
      this.lengthLabel1.Size = new System.Drawing.Size(202, 44);
      this.lengthLabel1.TabIndex = 3;
      this.lengthLabel1.Text = "0";
      this.lengthLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lengthLabel2
      // 
      this.lengthLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lengthLabel2.AutoSize = true;
      this.lengthLabel2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F);
      this.lengthLabel2.Location = new System.Drawing.Point(438, 328);
      this.lengthLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lengthLabel2.Name = "lengthLabel2";
      this.lengthLabel2.Size = new System.Drawing.Size(28, 29);
      this.lengthLabel2.TabIndex = 4;
      this.lengthLabel2.Text = "/";
      // 
      // lengthLabel3
      // 
      this.lengthLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lengthLabel3.AutoSize = true;
      this.lengthLabel3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F);
      this.lengthLabel3.Location = new System.Drawing.Point(468, 328);
      this.lengthLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
      this.lengthLabel3.Name = "lengthLabel3";
      this.lengthLabel3.Size = new System.Drawing.Size(58, 29);
      this.lengthLabel3.TabIndex = 5;
      this.lengthLabel3.Text = "140";
      // 
      // deleteBtn
      // 
      this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.deleteBtn.Location = new System.Drawing.Point(20, 322);
      this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.deleteBtn.Name = "deleteBtn";
      this.deleteBtn.Size = new System.Drawing.Size(205, 34);
      this.deleteBtn.TabIndex = 7;
      this.deleteBtn.Text = "Delete Last Tweet";
      this.deleteBtn.UseVisualStyleBackColor = true;
      this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
      this.statusStrip1.Location = new System.Drawing.Point(0, 382);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
      this.statusStrip1.Size = new System.Drawing.Size(688, 22);
      this.statusStrip1.TabIndex = 8;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // statusLabel1
      // 
      this.statusLabel1.Name = "statusLabel1";
      this.statusLabel1.Size = new System.Drawing.Size(0, 17);
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountsMenuTitle,
            this.settingsMenuTitle,
            this.helpMenuTitle});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
      this.menuStrip1.Size = new System.Drawing.Size(688, 35);
      this.menuStrip1.TabIndex = 9;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // accountsMenuTitle
      // 
      this.accountsMenuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountMenuItem,
            this.accountsComboBox});
      this.accountsMenuTitle.Name = "accountsMenuTitle";
      this.accountsMenuTitle.Size = new System.Drawing.Size(97, 29);
      this.accountsMenuTitle.Text = "Accounts";
      // 
      // addAccountMenuItem
      // 
      this.addAccountMenuItem.Name = "addAccountMenuItem";
      this.addAccountMenuItem.Size = new System.Drawing.Size(197, 30);
      this.addAccountMenuItem.Text = "Add account";
      this.addAccountMenuItem.Click += new System.EventHandler(this.addAccountMenuItem_Click);
      // 
      // accountsComboBox
      // 
      this.accountsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.accountsComboBox.Name = "accountsComboBox";
      this.accountsComboBox.Size = new System.Drawing.Size(121, 33);
      this.accountsComboBox.SelectedIndexChanged += new System.EventHandler(this.accountsComboBox_SelectedIndexChanged);
      // 
      // settingsMenuTitle
      // 
      this.settingsMenuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostMenuItem,
            this.wordWrapMenuItem,
            this.languageMenuItem});
      this.settingsMenuTitle.Name = "settingsMenuTitle";
      this.settingsMenuTitle.Size = new System.Drawing.Size(88, 29);
      this.settingsMenuTitle.Text = "Settings";
      // 
      // topMostMenuItem
      // 
      this.topMostMenuItem.CheckOnClick = true;
      this.topMostMenuItem.Name = "topMostMenuItem";
      this.topMostMenuItem.Size = new System.Drawing.Size(187, 30);
      this.topMostMenuItem.Text = "Top Most";
      this.topMostMenuItem.Click += new System.EventHandler(this.topMostMenuItem_Click);
      // 
      // wordWrapMenuItem
      // 
      this.wordWrapMenuItem.CheckOnClick = true;
      this.wordWrapMenuItem.Name = "wordWrapMenuItem";
      this.wordWrapMenuItem.Size = new System.Drawing.Size(187, 30);
      this.wordWrapMenuItem.Text = "Word Wrap";
      this.wordWrapMenuItem.Click += new System.EventHandler(this.wordWrapMenuItem_Click);
      // 
      // languageMenuItem
      // 
      this.languageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languagesComboBox});
      this.languageMenuItem.Name = "languageMenuItem";
      this.languageMenuItem.Size = new System.Drawing.Size(187, 30);
      this.languageMenuItem.Text = "Language";
      // 
      // languagesComboBox
      // 
      this.languagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.languagesComboBox.Name = "languagesComboBox";
      this.languagesComboBox.Size = new System.Drawing.Size(121, 33);
      this.languagesComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
      // 
      // helpMenuTitle
      // 
      this.helpMenuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
      this.helpMenuTitle.Name = "helpMenuTitle";
      this.helpMenuTitle.Size = new System.Drawing.Size(61, 29);
      this.helpMenuTitle.Text = "Help";
      // 
      // aboutMenuItem
      // 
      this.aboutMenuItem.Name = "aboutMenuItem";
      this.aboutMenuItem.Size = new System.Drawing.Size(146, 30);
      this.aboutMenuItem.Text = "About";
      this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(688, 404);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.deleteBtn);
      this.Controls.Add(this.lengthLabel3);
      this.Controls.Add(this.lengthLabel2);
      this.Controls.Add(this.lengthLabel1);
      this.Controls.Add(this.sendBtn);
      this.Controls.Add(this.richTextBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.MaximizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Mystter - Send Tweet";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label lengthLabel1;
        private System.Windows.Forms.Label lengthLabel2;
        private System.Windows.Forms.Label lengthLabel3;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountsMenuTitle;
        private System.Windows.Forms.ToolStripMenuItem addAccountMenuItem;
        private System.Windows.Forms.ToolStripComboBox accountsComboBox;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuTitle;
        private System.Windows.Forms.ToolStripMenuItem topMostMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuTitle;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageMenuItem;
        private System.Windows.Forms.ToolStripComboBox languagesComboBox;
    }
}

