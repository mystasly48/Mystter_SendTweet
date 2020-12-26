namespace Mystter_SendTweet.Forms {
  partial class MainForm {
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.sendBtn = new System.Windows.Forms.Button();
      this.lengthLabel1 = new System.Windows.Forms.Label();
      this.lengthLabel2 = new System.Windows.Forms.Label();
      this.lengthLabel3 = new System.Windows.Forms.Label();
      this.deleteBtn = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.accountsMenuTitle = new System.Windows.Forms.ToolStripMenuItem();
      this.addAccountMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.showProfileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.accountsComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.settingsMenuTitle = new System.Windows.Forms.ToolStripMenuItem();
      this.openSettingsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
      this.topMostMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.wordWrapMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.languageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.languagesComboBox = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.autoAppendHashtagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.hashtagsSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpMenuTitle = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.checkForUpdatesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.imageList = new Manina.Windows.Forms.ImageListView();
      this.imageListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.removeContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.hashtagsStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.menuStrip1.SuspendLayout();
      this.imageListContextMenu.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBox1
      // 
      this.textBox1.AllowDrop = true;
      this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F);
      this.textBox1.Location = new System.Drawing.Point(12, 27);
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(383, 199);
      this.textBox1.TabIndex = 1;
      this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      this.textBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImagesDragDrop);
      this.textBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImagesDragEnter);
      this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
      // 
      // sendBtn
      // 
      this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.sendBtn.Enabled = false;
      this.sendBtn.Location = new System.Drawing.Point(320, 231);
      this.sendBtn.Name = "sendBtn";
      this.sendBtn.Size = new System.Drawing.Size(75, 23);
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
      this.lengthLabel1.Location = new System.Drawing.Point(136, 235);
      this.lengthLabel1.Name = "lengthLabel1";
      this.lengthLabel1.Size = new System.Drawing.Size(121, 19);
      this.lengthLabel1.TabIndex = 3;
      this.lengthLabel1.Text = "0";
      this.lengthLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lengthLabel2
      // 
      this.lengthLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lengthLabel2.AutoSize = true;
      this.lengthLabel2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F);
      this.lengthLabel2.Location = new System.Drawing.Point(257, 235);
      this.lengthLabel2.Name = "lengthLabel2";
      this.lengthLabel2.Size = new System.Drawing.Size(19, 19);
      this.lengthLabel2.TabIndex = 4;
      this.lengthLabel2.Text = "/";
      // 
      // lengthLabel3
      // 
      this.lengthLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.lengthLabel3.AutoSize = true;
      this.lengthLabel3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F);
      this.lengthLabel3.Location = new System.Drawing.Point(275, 235);
      this.lengthLabel3.Name = "lengthLabel3";
      this.lengthLabel3.Size = new System.Drawing.Size(39, 19);
      this.lengthLabel3.TabIndex = 5;
      this.lengthLabel3.Text = "140";
      // 
      // deleteBtn
      // 
      this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.deleteBtn.Location = new System.Drawing.Point(10, 231);
      this.deleteBtn.Name = "deleteBtn";
      this.deleteBtn.Size = new System.Drawing.Size(123, 23);
      this.deleteBtn.TabIndex = 7;
      this.deleteBtn.Text = "Delete Last Tweet";
      this.deleteBtn.UseVisualStyleBackColor = true;
      this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
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
      this.menuStrip1.Size = new System.Drawing.Size(410, 24);
      this.menuStrip1.TabIndex = 9;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // accountsMenuTitle
      // 
      this.accountsMenuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAccountMenuItem,
            this.showProfileMenuItem,
            this.logoutMenuItem,
            this.accountsComboBox});
      this.accountsMenuTitle.Name = "accountsMenuTitle";
      this.accountsMenuTitle.Size = new System.Drawing.Size(69, 20);
      this.accountsMenuTitle.Text = "Accounts";
      // 
      // addAccountMenuItem
      // 
      this.addAccountMenuItem.Name = "addAccountMenuItem";
      this.addAccountMenuItem.Size = new System.Drawing.Size(195, 22);
      this.addAccountMenuItem.Text = "Add an account";
      this.addAccountMenuItem.Click += new System.EventHandler(this.addAccountMenuItem_Click);
      // 
      // showProfileMenuItem
      // 
      this.showProfileMenuItem.Name = "showProfileMenuItem";
      this.showProfileMenuItem.Size = new System.Drawing.Size(195, 22);
      this.showProfileMenuItem.Text = "Show profile";
      this.showProfileMenuItem.Click += new System.EventHandler(this.showProfileMenuItem_Click);
      // 
      // logoutMenuItem
      // 
      this.logoutMenuItem.Name = "logoutMenuItem";
      this.logoutMenuItem.Size = new System.Drawing.Size(195, 22);
      this.logoutMenuItem.Text = "Log out @ScreenName";
      this.logoutMenuItem.Click += new System.EventHandler(this.logoutMenuItem_Click);
      // 
      // accountsComboBox
      // 
      this.accountsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.accountsComboBox.Name = "accountsComboBox";
      this.accountsComboBox.Size = new System.Drawing.Size(121, 23);
      this.accountsComboBox.SelectedIndexChanged += new System.EventHandler(this.accountsComboBox_SelectedIndexChanged);
      // 
      // settingsMenuTitle
      // 
      this.settingsMenuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSettingsFolderToolStripMenuItem,
            this.toolStripMenuItem2,
            this.topMostMenuItem,
            this.wordWrapMenuItem,
            this.languageMenuItem,
            this.toolStripMenuItem1,
            this.autoAppendHashtagsToolStripMenuItem,
            this.hashtagsSettingToolStripMenuItem});
      this.settingsMenuTitle.Name = "settingsMenuTitle";
      this.settingsMenuTitle.Size = new System.Drawing.Size(61, 20);
      this.settingsMenuTitle.Text = "Settings";
      // 
      // openSettingsFolderToolStripMenuItem
      // 
      this.openSettingsFolderToolStripMenuItem.Name = "openSettingsFolderToolStripMenuItem";
      this.openSettingsFolderToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
      this.openSettingsFolderToolStripMenuItem.Text = "Open Settings Folder";
      this.openSettingsFolderToolStripMenuItem.Click += new System.EventHandler(this.openSettingsFolderToolStripMenuItem_Click);
      // 
      // toolStripMenuItem2
      // 
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 6);
      // 
      // topMostMenuItem
      // 
      this.topMostMenuItem.CheckOnClick = true;
      this.topMostMenuItem.Name = "topMostMenuItem";
      this.topMostMenuItem.Size = new System.Drawing.Size(197, 22);
      this.topMostMenuItem.Text = "Top Most";
      this.topMostMenuItem.Click += new System.EventHandler(this.topMostMenuItem_Click);
      // 
      // wordWrapMenuItem
      // 
      this.wordWrapMenuItem.CheckOnClick = true;
      this.wordWrapMenuItem.Name = "wordWrapMenuItem";
      this.wordWrapMenuItem.Size = new System.Drawing.Size(197, 22);
      this.wordWrapMenuItem.Text = "Word Wrap";
      this.wordWrapMenuItem.Click += new System.EventHandler(this.wordWrapMenuItem_Click);
      // 
      // languageMenuItem
      // 
      this.languageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.languagesComboBox});
      this.languageMenuItem.Name = "languageMenuItem";
      this.languageMenuItem.Size = new System.Drawing.Size(197, 22);
      this.languageMenuItem.Text = "Language";
      // 
      // languagesComboBox
      // 
      this.languagesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.languagesComboBox.Name = "languagesComboBox";
      this.languagesComboBox.Size = new System.Drawing.Size(121, 23);
      this.languagesComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 6);
      // 
      // autoAppendHashtagsToolStripMenuItem
      // 
      this.autoAppendHashtagsToolStripMenuItem.CheckOnClick = true;
      this.autoAppendHashtagsToolStripMenuItem.Name = "autoAppendHashtagsToolStripMenuItem";
      this.autoAppendHashtagsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
      this.autoAppendHashtagsToolStripMenuItem.Text = "Auto Append Hashtags";
      this.autoAppendHashtagsToolStripMenuItem.Click += new System.EventHandler(this.autoAppendHashtagsToolStripMenuItem_Click);
      // 
      // hashtagsSettingToolStripMenuItem
      // 
      this.hashtagsSettingToolStripMenuItem.Name = "hashtagsSettingToolStripMenuItem";
      this.hashtagsSettingToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
      this.hashtagsSettingToolStripMenuItem.Text = "Hashtags Setting";
      this.hashtagsSettingToolStripMenuItem.Click += new System.EventHandler(this.hashtagsSettingToolStripMenuItem_Click);
      // 
      // helpMenuTitle
      // 
      this.helpMenuTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem,
            this.checkForUpdatesMenuItem});
      this.helpMenuTitle.Name = "helpMenuTitle";
      this.helpMenuTitle.Size = new System.Drawing.Size(44, 20);
      this.helpMenuTitle.Text = "Help";
      // 
      // aboutMenuItem
      // 
      this.aboutMenuItem.Name = "aboutMenuItem";
      this.aboutMenuItem.Size = new System.Drawing.Size(170, 22);
      this.aboutMenuItem.Text = "About";
      this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
      // 
      // checkForUpdatesMenuItem
      // 
      this.checkForUpdatesMenuItem.Name = "checkForUpdatesMenuItem";
      this.checkForUpdatesMenuItem.Size = new System.Drawing.Size(170, 22);
      this.checkForUpdatesMenuItem.Text = "Check for Updates";
      this.checkForUpdatesMenuItem.Click += new System.EventHandler(this.checkForUpdatesMenuItem_Click);
      // 
      // imageList
      // 
      this.imageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.imageList.ContextMenuStrip = this.imageListContextMenu;
      this.imageList.Location = new System.Drawing.Point(12, 125);
      this.imageList.Name = "imageList";
      this.imageList.PersistentCacheDirectory = "";
      this.imageList.PersistentCacheSize = ((long)(100));
      this.imageList.Size = new System.Drawing.Size(383, 100);
      this.imageList.TabIndex = 10;
      this.imageList.ThumbnailSize = new System.Drawing.Size(70, 70);
      this.imageList.UseWIC = true;
      this.imageList.Visible = false;
      this.imageList.ItemHover += new Manina.Windows.Forms.ItemHoverEventHandler(this.imageList_ItemHover);
      this.imageList.ItemDoubleClick += new Manina.Windows.Forms.ItemDoubleClickEventHandler(this.imageList_ItemDoubleClick);
      this.imageList.ItemCollectionChanged += new Manina.Windows.Forms.ItemCollectionChangedEventHandler(this.imageList_ItemCollectionChanged);
      this.imageList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ImagesDragDrop);
      this.imageList.DragEnter += new System.Windows.Forms.DragEventHandler(this.ImagesDragEnter);
      // 
      // imageListContextMenu
      // 
      this.imageListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeContextMenuItem});
      this.imageListContextMenu.Name = "imageListContextMenu";
      this.imageListContextMenu.Size = new System.Drawing.Size(117, 26);
      this.imageListContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.imageListContextMenu_Opening);
      // 
      // removeContextMenuItem
      // 
      this.removeContextMenuItem.Name = "removeContextMenuItem";
      this.removeContextMenuItem.Size = new System.Drawing.Size(116, 22);
      this.removeContextMenuItem.Text = "Remove";
      this.removeContextMenuItem.Click += new System.EventHandler(this.removeContextMenuItem_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hashtagsStatusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 257);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(410, 22);
      this.statusStrip1.TabIndex = 11;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // hashtagsStatusLabel
      // 
      this.hashtagsStatusLabel.Name = "hashtagsStatusLabel";
      this.hashtagsStatusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(410, 279);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.imageList);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.deleteBtn);
      this.Controls.Add(this.lengthLabel3);
      this.Controls.Add(this.lengthLabel2);
      this.Controls.Add(this.lengthLabel1);
      this.Controls.Add(this.sendBtn);
      this.Controls.Add(this.textBox1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.MaximizeBox = false;
      this.Name = "MainForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Mystter - Send Tweet";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
      this.Resize += new System.EventHandler(this.MainForm_Resize);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.imageListContextMenu.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button sendBtn;
    private System.Windows.Forms.Label lengthLabel1;
    private System.Windows.Forms.Label lengthLabel2;
    private System.Windows.Forms.Label lengthLabel3;
    private System.Windows.Forms.Button deleteBtn;
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
    private System.Windows.Forms.ToolStripMenuItem showProfileMenuItem;
    private Manina.Windows.Forms.ImageListView imageList;
    private System.Windows.Forms.ContextMenuStrip imageListContextMenu;
    private System.Windows.Forms.ToolStripMenuItem removeContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openSettingsFolderToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem autoAppendHashtagsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem hashtagsSettingToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel hashtagsStatusLabel;
  }
}

