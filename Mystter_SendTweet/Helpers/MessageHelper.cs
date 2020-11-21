using Mystter_SendTweet.Entities;
using Mystter_SendTweet.Languages;
using System;
using System.Windows.Forms;

namespace Mystter_SendTweet.Helpers {
  public class MessageHelper {
    public static void Show(string message) {
      MessageBox.Show(message, Information.Title);
    }

    public static void Show(params string[] messages) {
      string message = string.Join(Environment.NewLine, messages);
      Show(message);
    }

    public static bool RetryAddingAccount() {
      return ShowYesNo(Resources.yetAdded1, Resources.yetAdded2);
    }

    public static bool ShowYesNo(string message) {
      var result = MessageBox.Show(message, Information.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      return result == DialogResult.Yes;
    }

    public static bool ShowYesNo(params string[] messages) {
      string message = string.Join(Environment.NewLine, messages);
      return ShowYesNo(message);
    }
  }
}
