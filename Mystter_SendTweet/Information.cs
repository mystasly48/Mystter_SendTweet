using System;
using System.IO;

namespace Mystter_SendTweet {
  public class Information {
    public static readonly string Title = "Mystter";
    public static readonly string Version = "1.4.0";
    public static readonly string Developer = "Mystasly";
    public static readonly string Repository = "https://github.com/mystasly48/Mystter_SendTweet";
    public static readonly string Twitter = "https://twitter.com/30msl";
    public static readonly string SettingsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Title);
    public static readonly string SettingsFile = Path.Combine(SettingsFolder, "Settings.xml");
  }
}
