﻿using CoreTweet;
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

    private void MainForm_Load(object sender, EventArgs e) {
      // Settings init
      settings = Settings.Load();
      ChangeLanguage(settings.Language);
      ChangeTopMost(settings.TopMost);
      ChangeWordWrap(settings.WordWrap);
      ChangeLocation(settings.Location);
      
      // Twitter init
      if (settings.AccountSwitcher.Accounts.Count == 0) {
        settings.AccountSwitcher.Add();
        settings.Save();
      }
      UpdateAccountsList();

      // Controls init
      ActiveControl = textBox1;
      EnableImageListView(false);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
      settings.Save();
    }

    private void MainForm_LocationChanged(object sender, EventArgs e) {
      if (WindowState != FormWindowState.Minimized) {
        // don't save the settings every time because the event is invoked frequently
        settings.Location = Location;
      }
    }

    private void sendBtn_Click(object sender, EventArgs e) {
      sendBtn.Enabled = false;
      SendTweet(textBox1.Text);
      // sendBtn will be enabled in SendTweet
    }

    private void textBox1_KeyDown(object sender, KeyEventArgs e) {
      if (e.Control && e.KeyCode == Keys.Enter) {
        e.SuppressKeyPress = true;
        sendBtn.PerformClick();
      }
    }

    private void textBox1_TextChanged(object sender, EventArgs e) {
      UpdateTweetableStatus();
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
      settings.Save();
      UpdateAccountsList();
    }

    // Switch account
    private void accountsComboBox_SelectedIndexChanged(object sender, EventArgs e) {
      var selected = (Account)accountsComboBox.SelectedItem;
      ChangeSelectedAccount(selected);
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
      new AboutForm().ShowDialog();
    }

    // Language
    private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      var selected = languagesComboBox.SelectedIndex;
      var lang = LocalizeHelper.GetLanguageParent(selected);
      ChangeLanguage(lang);
    }

    // Show Profile
    private void showProfileMenuItem_Click(object sender, EventArgs e) {
      Process.Start(settings.AccountSwitcher.SelectedAccount.ProfileUrl);
    }

    // Logout @ScreenName
    private void logoutMenuItem_Click(object sender, EventArgs e) {
      var result = MessageHelper.ShowYesNo(Resources.LogoutConfirm);
      if (!result)
        return;

      settings.AccountSwitcher.Remove(settings.AccountSwitcher.SelectedAccount);
      settings.Save();
      UpdateAccountsList();
      ChangeSelectedAccount(settings.AccountSwitcher.SelectedAccount);
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
        MessageHelper.Show(Resources.upTo4Images);
      } else {
        imageList.Items.AddRange(files);
        EnableImageListView(true);
        UpdateTweetableStatus();
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
      Process.Start(ImageHelper.GetFullPath(e.Item));
    }

    private void imageList_ItemCollectionChanged(object sender, ItemCollectionChangedEventArgs e) {
      UpdateTweetableStatus();
      EnableImageListView(imageList.Items.Count > 0);
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
      languagesComboBox.SelectedIndex = LocalizeHelper.GetLanguageIndex(LocalizeHelper.CurrentLanguage);
      removeContextMenuItem.Text = Resources.remove;
      checkForUpdatesMenuItem.Text = Resources.checkForUpdates;
      UpdateLogoutMenu();
    }

    private void UpdateLogoutMenu() {
      if (settings.AccountSwitcher.Accounts.Count == 0 || settings.AccountSwitcher.SelectedAccount == null) {
        logoutMenuItem.Text = Resources.Logout;
        logoutMenuItem.Enabled = false;
      } else {
        logoutMenuItem.Text = Resources.Logout + " " + settings.AccountSwitcher.SelectedAccount.ScreenNameWithAt;
        logoutMenuItem.Enabled = true;
      }
    }

    private void UpdateFormTitle() {
      Text = settings.AccountSwitcher.SelectedAccount.ScreenName + " / " + Information.Title;
    }

    private void UpdateAccountsList() {
      accountsComboBox.Items.Clear();
      accountsComboBox.Items.AddRange(settings.AccountSwitcher.Accounts.ToArray());
      ChangeSelectedAccount(settings.AccountSwitcher.SelectedAccount);
    }

    private void ChangeSelectedAccount(Account account) {
      accountsComboBox.SelectedItem = account;
      settings.AccountSwitcher.SelectedAccount = account;
      settings.Save();
      UpdateLogoutMenu();
      UpdateFormTitle();
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
        settings.Save();
      }
    }

    private void ChangeLanguage(string lang) {
      if (LocalizeHelper.ChangeLanguage(lang)) {
        settings.Language = lang;
        settings.Save();
        ApplyLocalization();
      }
    }

    private bool IsAccessibleForm(Point location, Size size) {
      foreach (Screen sc in Screen.AllScreens) {
        if (sc.WorkingArea.Contains(new Rectangle(location, size))) {
          return true;
        }
      }
      return false;
    }

    private void EnableImageListView(bool show) {
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

    private void DeleteLatestTweet() {
      var tokens = settings.AccountSwitcher.SelectedTokens;
      var latest = tokens.Account.UpdateProfile().Status;
      var result = MessageHelper.ShowYesNo(Resources.deleteComfirm, latest.Text);
      if (result) {
        tokens.Statuses.Destroy(latest.Id);
        MessageHelper.Show(Resources.deleteYes);
      } else {
        MessageHelper.Show(Resources.deleteNo);
      }
    }

    private void SendTweet(string msg) {
      if (!NetworkHelper.IsAvailable()) {
        MessageHelper.Show(Resources.networkNotAvailable);
        return;
      }
      if (TweetHelper.IsEmpty(msg) && imageList.Items.Count == 0) {
        MessageHelper.Show(Resources.tooShort);
        return;
      } else if (TweetHelper.GetLength(msg) > 140) {
        MessageHelper.Show(Resources.tooLong);
        return;
      }
      try {
        var tokens = settings.AccountSwitcher.SelectedTokens;
        if (imageList.Items.Count > 0) {
          var ids = imageList.Items.Select(x => tokens.Media.Upload(ImageHelper.GetFileInfo(x)).MediaId);
          tokens.Statuses.Update(status: msg, media_ids: ids);
          imageList.Items.Clear();
        } else {
          tokens.Statuses.Update(status: msg);
        }
      } catch (TwitterException ex) {
        if (ex.Message.Contains("Status is a duplicate")) {
          MessageHelper.Show(Resources.duplicate);
          return;
        }
        MessageHelper.Show(Resources.TwitterException);
        throw;
      } catch {
        MessageHelper.Show(Resources.UnknownException);
        throw;
      }
      textBox1.Clear();
      textBox1.Focus();
      UpdateTweetableStatus();
    }

    private TweetableStatus UpdateTweetableStatus() {
      var text = textBox1.Text;
      var length = TweetHelper.GetLength(textBox1.Text);
      lengthLabel1.Text = length.ToString();
      if (length > 140) {
        sendBtn.Enabled = false;
        lengthLabel1.ForeColor = Color.Red;
        return TweetableStatus.TooLong;
      } else if (TweetHelper.IsEmpty(text) && imageList.Items.Count == 0) {
        sendBtn.Enabled = false;
        lengthLabel1.ForeColor = SystemColors.WindowText;
        return TweetableStatus.Empty;
      } else {
        sendBtn.Enabled = true;
        lengthLabel1.ForeColor = SystemColors.WindowText;
        return TweetableStatus.OK;
      }
    }
  }
}
