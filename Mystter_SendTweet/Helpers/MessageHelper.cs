using Mystter_SendTweet.Languages;
using System;
using System.Windows.Forms;

namespace Mystter_SendTweet.Helpers {
  public class MessageHelper {
    public static bool RetryAddingAccount() {
      return ShowYesNoDialog(Resources.yetAdded1 + Environment.NewLine + Resources.yetAdded2);
    }

    public static bool ShowYesNoDialog(string message) {
      var result = MessageBox.Show(message, Information.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      return result == DialogResult.Yes;
    }
  }
}
