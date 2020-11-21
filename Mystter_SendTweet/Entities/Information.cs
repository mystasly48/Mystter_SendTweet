using System;
using System.IO;
using System.Reflection;

namespace Mystter_SendTweet.Entities {
  public static class Information {
    public static string Title { get => "Mystter"; }
    public static string Version { get => Assembly.GetExecutingAssembly().GetName().Version.ToString(3); }
    public static string Developer { get => "Mystasly"; }
    public static string Repository { get => "https://github.com/mystasly48/Mystter_SendTweet"; }
    public static string Twitter { get => "https://twitter.com/30msl"; }
    public static string SettingsFolder { get => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Title); }
    public static string SettingsFile { get => Path.Combine(SettingsFolder, "Settings.xml"); }

    public static string GetConcatTitle(string title) {
      return string.Join(" / ", Title, title);
    }
  }
}
