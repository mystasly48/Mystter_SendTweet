using CoreTweet;
using Manina.Windows.Forms;
using Mystter_SendTweet.Entities;
using Mystter_SendTweet.Helpers;
using Mystter_SendTweet.Languages;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mystter_SendTweet {
  public partial class MainForm : Form {
    public MainForm() {
      InitializeComponent();
    }

    private Settings settings;

    #region Controls

    private void MainForm_Load(object sender, EventArgs e) {
      settings = Settings.Load();
      SettingsInit();
      TwitterInit();
      ActiveControl = textBox1;
      ToggleImageListView(false);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      settings.Save();
    }

    private void MainForm_LocationChanged(object sender, EventArgs e) {
      if (WindowState != FormWindowState.Minimized) {
        settings.Location = Location;
      }
    }

    private void sendBtn_Click(object sender, EventArgs e) {
      sendBtn.Enabled = false;
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
      deleteBtn.Enabled = false;
      DeleteLatestTweet();
      deleteBtn.Enabled = true;
    }

    // Add account
    private void addAccountMenuItem_Click(object sender, EventArgs e) {
      settings.AccountSwitcher.Add();
    }

    // Switch account
    private void accountsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      var selected = (Account)accountsComboBox.SelectedItem;
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
      Process.Start(settings.AccountSwitcher.SelectedAccount.ProfileUrl);
    }

    // Logout @ScreenName
    private void logoutMenuItem_Click(object sender, EventArgs e) {
      var result = MessageHelper.ShowYesNoDialog(Resources.LogoutConfirm);
      if (!result)
        return;

      var selected = settings.SelectedItem;
      for (int i = 0; i < settings.Twitter.Count; i++) {
        if (settings.Twitter[i].ScreenName == selected) {
          settings.Twitter.RemoveAt(i);
          accountsComboBox.Items.RemoveAt(i);
          break;
        }
      }

      var next = settings.Twitter.Where(x => x.ScreenName != selected).FirstOrDefault();
      ChangeSelectedItem(next?.ScreenName);

      if (next == null) {
        if (IsRetryAddingAccount()) {
          AddAccount();
        } else {
          Environment.Exit(0);
        }
      }
    }

    private void ImagesDragEnter(object sender, DragEventArgs e) {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
        var files = (string[])e.Data.GetData(DataFormats.FileDrop);
        foreach (var file in files) {
          if (!File.Exists(file) || !ImageHelper.IsSupported(file)) {
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

    private void checkForUpdatesMenuItem_Click(object sender, EventArgs e) {
      var updatesForm = new CheckingUpdatesForm();
      updatesForm.ShowDialog();
      var updater = updatesForm.Updater;
      if (updater.IsLatestVersion) {
        var form = new UpdatesUnavailableForm(updater.LatestRelease);
        form.ShowDialog();
      } else {
        var form = new UpdatesAvailableForm(updater);
        form.ShowDialog();
      }
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
      languagesComboBox.Items.Add(Resources.English + " (English)");
      languagesComboBox.Items.Add(Resources.Japanese + " (日本語)");
      languagesComboBox.SelectedIndex = Localization.GetLanguageIndex(Localization.CurrentLanguage);
      removeContextMenuItem.Text = Resources.remove;
      checkForUpdatesMenuItem.Text = Resources.checkForUpdates;
      UpdateLogoutMenu();
    }

    private void UpdateLogoutMenu() {
      logoutMenuItem.Text = Resources.Logout + " " + settings.AccountSwitcher.SelectedAccount.ScreenNameWithAt;
    }

    private void ChangeSelectedItem(Account account) {
      accountsComboBox.SelectedItem = account;
      settings.AccountSwitcher.SelectedAccount = account;
      settings.Save();
      UpdateLogoutMenu();
      Text = account.ScreenName + " / " + Information.Title;
    }

    private void ChangeTopMost(bool top) {
      if (top != TopMost) {
        TopMost = top;
        topMostMenuItem.Checked = top;
        settings.TopMost = top;
        settings.Save();
      }
    }

    private void ChangeWordWrap(bool wrap) {
      textBox1.WordWrap = wrap;
      wordWrapMenuItem.Checked = wrap;
      settings.WordWrap = wrap;
      settings.Save();
    }

    private void ChangeLocation(Point location) {
      if (location != Location) {
        if (IsAccessibleForm(location, Size)) {
          Location = location;
        } else {
          Location = Settings.DefaultLocation;
        }
        settings.Location = Location;
      }
    }

    private void ChangeLanguage(string lang) {
      if (Localization.ChangeLanguage(lang)) {
        settings.Language = lang;
        settings.Save();
        ApplyLocalization();
      }
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

    private void TwitterInit() {
      if (settings.Twitter.Count > 0) {
        for (int i = 0; i < settings.Twitter.Count; i++) {
          var account = new Account();
          account = settings.Twitter[i];
          accountsComboBox.Items.Add(account.ScreenName);
        }
        tokens = GetAccountTokens(settings.SelectedItem);
        ChangeSelectedItem(settings.SelectedItem);
      } else {
        AddAccount();
      }
    }

    private void DeleteLatestTweet() {
      var latest = tokens.Account.UpdateProfile().Status;
      var msgResult = MessageBox.Show(
        Resources.deleteComfirm + Environment.NewLine
        + "------------------------------" + Environment.NewLine +
        latest.Text + Environment.NewLine +
        "------------------------------",
        Information.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

    private void SendTweet(string msg) {
      if (!NetworkHelper.IsAvailable()) {
        MessageBox.Show(Resources.networkNotAvailable);
        return;
      }
      if (TweetHelper.IsEmpty(msg) && imageList.Items.Count == 0) {
        MessageBox.Show(Resources.tooShort);
        return;
      } else if (TweetHelper.GetLength(msg) > 140) {
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

    private void IsTweetable() {
      var text = textBox1.Text;
      var length = TweetHelper.GetLength(textBox1.Text);
      lengthLabel1.Text = length.ToString();
      if (length > 140) {
        sendBtn.Enabled = false;
        lengthLabel1.ForeColor = Color.Red;
      } else if ((length == 0 || TweetHelper.IsEmpty(text)) && imageList.Items.Count == 0) {
        sendBtn.Enabled = false;
      } else {
        sendBtn.Enabled = true;
        lengthLabel1.ForeColor = SystemColors.WindowText;
      }
    }
  }
}
