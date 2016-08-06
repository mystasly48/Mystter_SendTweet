using System.Collections.Generic;
using System.Drawing;

namespace Mystter_SendTweet {
    public class Settings {
        public bool TopMost = false;
        public bool WordWrap = true;
        public Point Location = new Point(200, 100);
        public string SelectedItem;
        public List<Account> Twitter = new List<Account>();
    }

    public class Account {
        public string AccessToken;
        public string AccessSecret;
        public string ScreenName;
        public long UserId;
    }
}
