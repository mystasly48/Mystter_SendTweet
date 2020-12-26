using System.Xml.Serialization;

namespace Mystter_SendTweet.Entities.Older {
  [XmlType("Account")]
  public class Account1 {
    public string AccessToken { get; set; }
    public string AccessSecret { get; set; }
    public string ScreenName { get; set; }
    public long UserId { get; set; }

    public Account1() { }
  }
}
