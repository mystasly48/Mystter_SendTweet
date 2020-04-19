using CoreTweet;
using ImageMagick;
using Manina.Windows.Forms;
using Mystter_SendTweet.Languages;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Mystter_SendTweet {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    Settings settings = new Settings();
    Tokens tokens;
    string NewLine = Environment.NewLine;
    string SettingsFile = Information.Title + ".xml";

    #region Controls

    private void Form1_Load(object sender, EventArgs e) {
      LoadSettings();
      SettingsInit();
      TwitterInit();
      ActiveControl = textBox1;
      ToggleImageListView(false);
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
      SaveSettings();
    }

    private void Form1_LocationChanged(object sender, EventArgs e) {
      if (WindowState != FormWindowState.Minimized) {
        settings.Location = Location;
        Console.WriteLine(Location);
      }
    }

    private void sendBtn_Click(object sender, EventArgs e) {
      DisabledButton(sendBtn);
      SendTweet(textBox1.Text);
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e) {
      if (e.Control && e.KeyCode == Keys.Enter) {
        e.SuppressKeyPress = true;
        sendBtn.PerformClick();
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e) {
      IsTweetable();
    }

    // Delete Last Tweet
    private void deleteBtn_Click(object sender, EventArgs e) {
      DisabledButton(deleteBtn);
      DeleteLatestTweet();
      EnabledButton(deleteBtn);
    }

    // Add account
    private void addAccountMenuItem_Click(object sender, EventArgs e) {
      AddAccount();
    }

    // Switch account
    private void accountsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      var selected = accountsComboBox.SelectedItem.ToString();
      tokens = GetAccountTokens(selected);
      ChangeSelectedItem(selected);
    }

    // Top Most
    private void topMostMenuItem_Click(object sender, EventArgs e) {
      ChangeTopMost(topMostMenuItem.Checked);
    }

    // Word Wrap
    private void wordWrapMenuItem_Click(object sender, EventArgs e) {
      ChangeWordWrap(wordWrapMenuItem.Checked);
    }

    // About
    private void aboutMenuItem_Click(object sender, EventArgs e) {
      var form = new AboutForm();
      form.ShowDialog();
    }

    // Language
    private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      var selected = languagesComboBox.SelectedIndex;
      var lang = Localization.GetLanguageParent(selected);
      ChangeLanguage(lang);
    }

    // Show Profile
    private void showProfileMenuItem_Click(object sender, EventArgs e) {
      Process.Start("https://twitter.com/" + settings.SelectedItem);
    }

    private void ImagesDragEnter(object sender, DragEventArgs e) {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        var files = (string[])e.Data.GetData(DataFormats.FileDrop);
        foreach (var file in files) {
          if(!File.Exists(file) || !IsSupportedImage(file)) {
            e.Effect = DragDropEffects.None;
            return;
          }
        }
      }
      e.Effect = DragDropEffects.Copy;
    }

    private void ImagesDragDrop(object sender, DragEventArgs e) {
      var files = (string[])e.Data.GetData(DataFormats.FileDrop);
      if (files.Length + imageList.Items.Count > 4) {
        MessageBox.Show(Resources.upTo4Images);
      } else {
        imageList.Items.AddRange(files);
        ToggleImageListView(true);
        IsTweetable();
      }
    }

    private void removeContextMenuItem_Click(object sender, EventArgs e) {
      foreach (var selected in imageList.SelectedItems) {
        imageList.Items.Remove(selected);
      }
    }

    private void imageList_ItemHover(object sender, ItemHoverEventArgs e) {
      removeContextMenuItem.Enabled = true;
    }

    private void imageListContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
      if (imageList.SelectedItems.Count > 0) {
        removeContextMenuItem.Enabled = true;
      } else {
        removeContextMenuItem.Enabled = false;
      }
    }

    private void imageList_ItemDoubleClick(object sender, ItemClickEventArgs e) {
      Process.Start(Path.Combine(e.Item.FilePath, e.Item.FileName));
    }

    private void imageList_ItemCollectionChanged(object sender, ItemCollectionChangedEventArgs e) {
      IsTweetable();
      ToggleImageListView(imageList.Items.Count > 0);
    }

    #endregion

    #region Control Methods

    private void ApplyLocalization() {
      sendBtn.Text = Resources.sendBtn;
      deleteBtn.Text = Resources.deleteBtn;
      accountsMenuTitle.Text = Resources.accountMenuTitle;
      addAccountMenuItem.Text = Resources.addAccountMenuItem;
      showProfileMenuItem.Text = Resources.showProfileMenuItem;
      settingsMenuTitle.Text = Resources.settingsMenuTitle;
      topMostMenuItem.Text = Resources.topMostMenuItem;
      wordWrapMenuItem.Text = Resources.wordWrapMenuItem;
      helpMenuTitle.Text = Resources.helpMenuTitle;
      aboutMenuItem.Text = Resources.aboutMenuItem;
      languageMenuItem.Text = Resources.Language;
      languagesComboBox.Items.Clear();
      languagesComboBox.Items.Add(Resources.English);
      languagesComboBox.Items.Add(Resources.Japanese);
      languagesComboBox.SelectedItem = Localization.GetLanguageFullName(Localization.CurrentLanguage);
      removeContextMenuItem.Text = Resources.remove;
    }

    private void ChangeSelectedItem(string item) {
      if (item != settings.SelectedItem) {
        accountsComboBox.SelectedItem = item;
        settings.SelectedItem = item;
        SaveSettings();
        Text = item + " / " + Information.Title;
      }
    }

    private void ChangeTopMost(bool top) {
      if (top != TopMost) {
        TopMost = top;
        topMostMenuItem.Checked = top;
        settings.TopMost = top;
        SaveSettings();
      }
    }

    private void ChangeWordWrap(bool wrap) {
      if (wrap != textBox1.WordWrap) {
        textBox1.WordWrap = wrap;
        wordWrapMenuItem.Checked = wrap;
        settings.WordWrap = wrap;
        SaveSettings();
      }
    }

    private void ChangeLocation(Point location) {
      if (location != Location) {
        if (IsAccessibleForm(location, Size)) {
          Location = location;
        } else {
          Location = new Point(200, 100);
        }
        settings.Location = Location;
      }
    }

    private void ChangeLanguage(string lang) {
      if (Localization.ChangeLanguage(lang)) {
        settings.Language = lang;
        SaveSettings();
        ApplyLocalization();
      }
    }

    private void DisabledButton(Button btn) {
      btn.Enabled = false;
    }

    private void EnabledButton(Button btn) {
      btn.Enabled = true;
    }

    private void SetStatusMessage(string msg) {
      statusLabel1.Text = msg;
    }

    private void SettingsInit() {
      ChangeLanguage(settings.Language);
      ChangeTopMost(settings.TopMost);
      ChangeWordWrap(settings.WordWrap);
      ChangeLocation(settings.Location);
    }

    private bool IsAccessibleForm(Point location, Size size) {
      foreach (Screen sc in Screen.AllScreens) {
        if (sc.WorkingArea.Contains(new Rectangle(location, size))) {
          return true;
        }
      }
      return false;
    }

    private void ToggleImageListView(bool show) {
      if (show && !imageList.Visible) {
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
        Height += imageList.Height;
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
        imageList.Visible = true;
      } else if (!show && imageList.Visible) {
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
        Height -= imageList.Height;
        textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
        imageList.Visible = false;
      }
    }

    #endregion

    #region Methods

    private void SaveSettings() {
      var serializer = new XmlSerializer(typeof(Settings));
      var writer = new StreamWriter(SettingsFile, false, Encoding.UTF8);
      serializer.Serialize(writer, settings);
      writer.Close();
    }

    private void LoadSettings() {
      if (File.Exists(SettingsFile)) {
        var serializer = new XmlSerializer(typeof(Settings));
        var reader = new StreamReader(SettingsFile);
        settings = (Settings)serializer.Deserialize(reader);
        reader.Close();
      } else {
        SaveSettings();
        LoadSettings();
      }
    }

    private void TwitterInit() {
      if (settings.Twitter.Count > 0) {
        for (int i = 0; i < settings.Twitter.Count; i++) {
          var account = new Account();
          account = settings.Twitter[i];
          accountsComboBox.Items.Add(account.ScreenName);
        }
        tokens = GetAccountTokens(settings.SelectedItem);
        accountsComboBox.SelectedItem = settings.SelectedItem;
        Text = settings.SelectedItem + " / " + Information.Title;
      } else {
        AddAccount();
      }
    }

    private void AddAccount() {
      START:
      var form = new AuthBrowser();
      var s = OAuth.Authorize(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret);
      form.URL = s.AuthorizeUri.AbsoluteUri;
      form.ShowDialog();
      if (form.Success) {
        var _tokens = s.GetTokens(form.PIN);
        SetAccountTokens(_tokens);
      } else if (settings.Twitter.Count == 0) {
        var result = MessageBox.Show(Resources.yetAdded1 + NewLine + Resources.yetAdded2, Information.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        switch (result) {
          case DialogResult.Yes:
            goto START;
          case DialogResult.No:
            Environment.Exit(0);
            break;
        }
      }
      form.Dispose();
    }

    private void DeleteLatestTweet() {
      var latest = tokens.Account.UpdateProfile().Status;
      var msgResult = MessageBox.Show(Resources.deleteComfirm + NewLine + "------------------------------" + NewLine + latest.Text + NewLine + "------------------------------", Information.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      switch (msgResult) {
        case DialogResult.Yes:
          tokens.Statuses.Destroy(latest.Id);
          MessageBox.Show(Resources.deleteYes, Information.Title);
          break;
        case DialogResult.No:
          MessageBox.Show(Resources.deleteNo, Information.Title);
          break;
      }
    }

    private void SetAccountTokens(Tokens _tokens) {
      var token = _tokens.AccessToken;
      var secret = _tokens.AccessTokenSecret;
      var screen = _tokens.ScreenName;
      var id = _tokens.UserId;

      if (IsDuplicate(id)) {
        MessageBox.Show(Resources.alreadyAdded);
        return;
      }

      var account = new Account();
      account.AccessToken = token;
      account.AccessSecret = secret;
      account.ScreenName = screen;
      account.UserId = id;

      settings.Twitter.Add(account);

      accountsComboBox.Items.Add(screen);

      ChangeSelectedItem(screen);
    }

    private Tokens GetAccountTokens(string screen) {
      var account = new Account();
      for (int i = 0; i < settings.Twitter.Count; i++) {
        account = settings.Twitter[i];
        if (account.ScreenName.Equals(screen)) {
          var _tokens = Tokens.Create(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, account.AccessToken, account.AccessSecret);
          return _tokens;
        }
      }
      return null;
    }

    private bool IsDuplicate(long userId) {
      var account = new Account();
      for (int i = 0; i < settings.Twitter.Count; i++) {
        account = settings.Twitter[i];
        if (account.UserId == userId) {
          return true;
        }
      }
      return false;
    }

    private void SendTweet(string msg) {
      if (!IsNetworkAvailable()) {
        MessageBox.Show(Resources.networkNotAvailable);
        return;
      }
      if (IsEmpty(msg) && imageList.Items.Count == 0) {
        MessageBox.Show(Resources.tooShort);
        return;
      } else if (GetLength(msg) > 140) {
        MessageBox.Show(Resources.tooLong);
        return;
      }
      try {
        if (imageList.Items.Count > 0) {
          var ids = imageList.Items.Select(x => tokens.Media.Upload(new FileInfo(Path.Combine(x.FilePath, x.FileName))).MediaId);
          tokens.Statuses.Update(status: msg, media_ids: ids);
          imageList.Items.Clear();
        } else {
          tokens.Statuses.Update(status: msg);
        }
      } catch (TwitterException ex) {
        if (ex.Message.Contains("Status is a duplicate")) {
          MessageBox.Show(Resources.duplicate);
          return;
        }
        MessageBox.Show(Resources.TwitterException);
        throw;
      } catch {
        MessageBox.Show(Resources.UnknownException);
        throw;
      }
      textBox1.Text = "";
      textBox1.Focus();
      IsTweetable();
    }

    private bool IsEmpty(string str) {
      str = str.Replace(" ", "");
      str = str.Replace("　", "");
      str = str.Replace("\r", "");
      str = str.Replace("\n", "");
      if (GetLength(str) == 0) {
        return true;
      } else {
        return false;
      }
    }

    private bool IsNetworkAvailable() {
      return NetworkInterface.GetIsNetworkAvailable();
    }

    private void IsTweetable() {
      var text = textBox1.Text;
      var length = GetLength(textBox1.Text);
      lengthLabel1.Text = length.ToString();
      if (length > 140) {
        DisabledButton(sendBtn);
        lengthLabel1.ForeColor = Color.Red;
      } else if ((length == 0 || IsEmpty(text)) && imageList.Items.Count == 0) {
        DisabledButton(sendBtn);
      } else {
        EnabledButton(sendBtn);
        lengthLabel1.ForeColor = SystemColors.WindowText;
      }
    }

    private bool IsSupportedImage(string path) {
      try {
        // I don't know the difference between Jpg and Jpeg.
        // A lot of .jpg extention files are recognized as Jpeg.
        MagickFormat format = new MagickImageInfo(path).Format;
        if (format == MagickFormat.Jpg || format == MagickFormat.Jpeg || format == MagickFormat.Png || format == MagickFormat.Gif || format == MagickFormat.WebP) {
          return true;
        } else {
          Console.WriteLine(format);
          return false;
        }
      } catch {
        Console.WriteLine(path);
        return false;
      }
    }

    private int GetLength(string str) {
      return new StringInfo(str).LengthInTextElements;
    }

    #endregion
  }
}
