using Mystter_SendTweet.Entities;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Mystter_SendTweet.Entities {
  public class Settings {
    public bool TopMost { get; set; }
    public bool WordWrap { get; set; }
    public Point Location { get; set; }
    public Size Size { get; set; }
    public string Language { get; set; }
    public AccountSwitcher AccountSwitcher { get; set; }
    public List<Hashtag> Hashtags { get; set; }
    public bool AppendHashtags { get; set; }

    [XmlIgnore]
    public static bool DefaultTopMost { get => false; }
    [XmlIgnore]
    public static bool DefaultWordWrap { get => true; }
    [XmlIgnore]
    public static Point DefaultLocation { get => new Point(200, 100); }
    [XmlIgnore]
    public static Size DefaultSize { get => new Size(400, 300); }
    [XmlIgnore]
    public static string DefaultLanguage { get => CultureInfo.CurrentCulture.Parent.ToString(); }
    [XmlIgnore]
    public static bool DefaultAppendHashtags { get => false; }

    [XmlIgnore]
    public List<Hashtag> CheckedHashtags => Hashtags.Where(x => x.Enabled).ToList();
    [XmlIgnore]
    public string CheckedHashtagsString => string.Join(" ", CheckedHashtags.Select(x => x.NameWithMark));

    public Settings() {
      TopMost = DefaultTopMost;
      WordWrap = DefaultWordWrap;
      Location = DefaultLocation;
      Size = DefaultSize;
      Language = DefaultLanguage;
      AccountSwitcher = new AccountSwitcher();
      Hashtags = new List<Hashtag>();
      AppendHashtags = DefaultAppendHashtags;
    }

    public void Save() {
      var serializer = new XmlSerializer(typeof(Settings));
      using (var writer = new StreamWriter(Information.SettingsFile, false, Encoding.UTF8)) {
        serializer.Serialize(writer, this);
      }
    }

    public static Settings Create() {
      CreateFolder();
      Settings settings = new Settings();
      settings.Save();
      return Load();
    }

    public static Settings Load() {
      if (File.Exists(Information.SettingsFile)) {
        var serializer = new XmlSerializer(typeof(Settings));
        using (var reader = new StreamReader(Information.SettingsFile)) {
          return (Settings)serializer.Deserialize(reader);
        }
      } else {
        return Create();
      }
    }

    private static void CreateFolder() {
      Directory.CreateDirectory(Information.SettingsFolder);
    }
  }
}
