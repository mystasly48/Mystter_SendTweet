using CoreTweet;
using System.Xml.Serialization;

namespace Mystter_SendTweet.Entities {
  public sealed class Account {
    public string AccessToken { get; set; }
    public string AccessSecret { get; set; }
    [XmlIgnore]
    public Tokens Tokens {
      get {
        if (_tokens == null) {
          _tokens = Tokens.Create(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, this.AccessToken, this.AccessSecret);
        }
        return _tokens;
      }
    }
    private Tokens _tokens;
    [XmlIgnore]
    public string ScreenName { get => Tokens.Account.UpdateProfile().ScreenName; }
    [XmlIgnore]
    public string ProfileUrl { get => "https://www.twitter.com/" + ScreenName; }
    [XmlIgnore]
    public string ScreenNameWithAt { get => "@" + ScreenName; }

    public Account() { }

    public Account(string AccessToken, string AccessSecret) {
      this.AccessToken = AccessToken;
      this.AccessSecret = AccessSecret;
    }

    public override string ToString() {
      return ScreenName;
    }

    public override bool Equals(object obj) {
      if (obj is Account account) {
        return account.AccessToken == this.AccessToken && account.AccessSecret == this.AccessSecret;
      }
      return false;
    }

    public override int GetHashCode() {
      return (this.AccessToken + "&" + this.AccessSecret).GetHashCode();
    }
  }
}
