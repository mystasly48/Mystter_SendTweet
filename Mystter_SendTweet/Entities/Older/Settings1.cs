using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Xml.Serialization;

namespace Mystter_SendTweet.Entities.Older {
  [XmlRoot("Settings")]
  public class Settings1 : SettingsBase<Settings1> {
    public bool TopMost { get; set; }
    public bool WordWrap { get; set; }
    public Point Location { get; set; }
    public string SelectedItem { get; set; }
    public string Language { get; set; }
    public List<Account1> Twitter { get; set; }

    [XmlIgnore]
    public static bool DefaultTopMost { get => false; }
    [XmlIgnore]
    public static bool DefaultWordWrap { get => true; }
    [XmlIgnore]
    public static Point DefaultLocation { get => new Point(200, 100); }
    [XmlIgnore]
    public static string DefaultLanguage { get => CultureInfo.CurrentCulture.Parent.ToString(); }

    public Settings1() {
      TopMost = DefaultTopMost;
      WordWrap = DefaultWordWrap;
      Location = DefaultLocation;
      Language = DefaultLanguage;
      Twitter = new List<Account1>();
    }
  }
}
