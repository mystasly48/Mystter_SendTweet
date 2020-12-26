using Mystter_SendTweet.Entities;
using Mystter_SendTweet.Entities.Older;
using Mystter_SendTweet.Languages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Mystter_SendTweet.Helpers {
  public class SettingsParser {
    private bool IsCanceled { get; set; }

    public Settings Parse() {
      Settings settings = LoadNullable<Settings>();
      if (settings != null && !IsCanceled) {
        return settings;
      }

      Settings1 settings1 = LoadNullable<Settings1>();
      if (settings1 != null && !IsCanceled) {
        MessageHelper.Show(Resources.SuccessToConvertSettings);
        return ParseSettings(settings1);
      }

      if (MessageHelper.ShowYesNo(Resources.FailedToConvertSettings, Resources.ApplicationExitIfSelectNoMessage)) {
        return SettingsHelper.Create();
      } else {
        Environment.Exit(0);
        return null;
      }
    }

    private Settings ParseSettings(Settings1 oldSettings) {
      Settings newSettings = new Settings();
      newSettings.TopMost = oldSettings.TopMost;
      newSettings.WordWrap = oldSettings.WordWrap;
      newSettings.Location = oldSettings.Location;
      newSettings.Language = oldSettings.Language;

      List<Account> accounts = oldSettings.Twitter
        .Select(account => new Account(account.AccessToken, account.AccessSecret)).ToList();
      newSettings.AccountSwitcher.Accounts = accounts;

      Account selectedAccount = newSettings.AccountSwitcher.Accounts
        .Where(account => account.ScreenName == oldSettings.SelectedItem).FirstOrDefault();
      if (selectedAccount != null) {
        newSettings.AccountSwitcher.SelectedAccount = selectedAccount;
      }

      newSettings.Save();

      return SettingsHelper.Load();
    }

    private T LoadNullable<T>() where T : SettingsBase<T>, new() {
      IsCanceled = false;

      if (File.Exists(Information.SettingsFile)) {
        try {
          var serializer = new XmlSerializer(typeof(T));
          serializer.UnknownNode += new XmlNodeEventHandler(serializer_UnknownNode);
          serializer.UnknownAttribute += new XmlAttributeEventHandler(serializer_UnknownAttribute);
          using (var reader = new StreamReader(Information.SettingsFile)) {
            return (T)serializer.Deserialize(reader);
          }
        } catch {
          return null;
        }
      }
      return null;
    }

    private void serializer_UnknownNode(object sender, XmlNodeEventArgs e) {
      Console.WriteLine($"Unknown Node: {e.Name}, Line: {e.LineNumber}, Pos: {e.LinePosition}");
      IsCanceled = true;
    }

    private void serializer_UnknownAttribute(object sender, XmlAttributeEventArgs e) {
      Console.WriteLine($"Unknown attribute: {e.Attr.Name}='{e.Attr.Value}', Line: {e.LineNumber}, Pos: {e.LinePosition}");
      IsCanceled = true;
    }
  }
}
