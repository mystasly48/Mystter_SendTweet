using Mystter_SendTweet.Entities;
using System.IO;

namespace Mystter_SendTweet.Helpers {
  public static class SettingsHelper {
    public static Settings Load() {
      if (File.Exists(Information.SettingsFile)) {
        return new SettingsParser().Parse();
      } else {
        return Create();
      }
    }

    public static Settings Create() {
      CreateFolder();
      new Settings().Save();
      return Load();
    }

    public static void CreateFolder() {
      Directory.CreateDirectory(Information.SettingsFolder);
    }
  }
}
