using System.Xml.Serialization;

namespace Mystter_SendTweet.Entities {
  public sealed class Account {
    public string AccessToken { get; set; }
    public string AccessSecret { get; set; }
    public string ScreenName { get; set; }
    public long UserId { get; set; }

    [XmlIgnore]
    public string ProfileUrl {
      get {
        return "https://www.twitter.com/" + ScreenName;
      }
    }

    [XmlIgnore]
    public string ScreenNameWithAt {
      get {
        return "@" + ScreenName;
      }
    }

    public Account() { }

    public Account(string AccessToken, string AccessSecret, string ScreenName, long UserId) {
      this.AccessToken = AccessToken;
      this.AccessSecret = AccessSecret;
      this.ScreenName = ScreenName;
      this.UserId = UserId;
    }

    public override string ToString() {
      return ScreenName;
    }
  }
}
