using Mystter_SendTweet.Entities;
using Mystter_SendTweet.Languages;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mystter_SendTweet.Forms {
  public partial class HashtagsForm : Form {
    public List<Hashtag> Hashtags { get; private set; }
    public bool Canceled { get; private set; } = true;

    public HashtagsForm(List<Hashtag> hashtags) {
      InitializeComponent();

      // localization
      this.Text = Information.GetConcatTitle(Resources.Hashtags);
      addButton.Text = Resources.Add;
      applyButton.Text = Resources.Apply;
      cancelButton.Text = Resources.Cancel;

      // initialize
      this.Hashtags = hashtags;
      hashtagsListBox.Items.Clear();
      foreach (Hashtag hashtag in hashtags) {
        hashtagsListBox.Items.Add(hashtag.Name, hashtag.Enabled);
      }
    }

    private void addButton_Click(object sender, EventArgs e) {
      addButton.Enabled = false;
      string hashtag = hashtagTextBox.Text;
      if (!hashtagsListBox.Items.Contains(hashtag)) {
        hashtagsListBox.Items.Add(hashtag);
      }
      hashtagTextBox.Clear();
      addButton.Enabled = true;
    }

    private void cancelButton_Click(object sender, EventArgs e) {
      this.Canceled = true;
      this.Close();
    }

    private void applyButton_Click(object sender, EventArgs e) {
      List<Hashtag> hashtags = new List<Hashtag>();
      for (int i = 0; i < hashtagsListBox.Items.Count; i++) {
        string name = hashtagsListBox.Items[i].ToString();
        bool state = hashtagsListBox.GetItemChecked(i);
        hashtags.Add(new Hashtag(name, state));
      }
      this.Hashtags = hashtags;
      this.Canceled = false;
      this.Close();
    }

    private void hashtagTextBox_KeyDown(object sender, KeyEventArgs e) {
      if (e.Control && e.KeyCode == Keys.Enter) {
        e.SuppressKeyPress = true;
        addButton.PerformClick();
      }
    }
  }
}
