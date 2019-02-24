using System.Globalization;
using System.Threading;
using Mystter_SendTweet.Languages;

namespace Mystter_SendTweet {
  public static class Localization {
    public static string CurrentLanguage;
    public static bool ChangeLanguage(string lang) {
      if (lang != CurrentLanguage) {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
        CurrentLanguage = lang;
        return true;
      } else {
        return false;
      }
    }

    public static string GetLanguageParent(int index) {
      switch (index) {
        default:
        case 0:
          return "en";
        case 1:
          return "ja";
      }
    }

    public static int GetLanguageIndex(string lang) {
      switch (lang) {
        default:
        case "en":
          return 0;
        case "ja":
          return 1;
      }
    }

    public static string GetLanguageFullName(string lang) {
      switch (lang) {
        case "en":
          return Resources.English;
        case "ja":
          return Resources.Japanese;
        default:
          return null;
      }
    }

    // English en 0
    // Japanese ja 1
  }
}
