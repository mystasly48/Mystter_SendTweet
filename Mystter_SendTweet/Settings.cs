using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Mystter_SendTweet {
    public class Settings {
        public bool TopMost = false;
        public Point Location = new Point(0, 0);
        public string SelectedItem;
        public List<Account> Twitter = new List<Account>();

        private static string SettingsFile = Information.Title + ".xml";

        public static void Save(Settings settings) {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            StreamWriter writer = new StreamWriter(SettingsFile, false, Encoding.UTF8);
            serializer.Serialize(writer, settings);
            writer.Close();
        }

        public static Settings Load() {
            if (IsExist()) {
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                StreamReader reader = new StreamReader(SettingsFile);
                Settings settings = (Settings)serializer.Deserialize(reader);
                reader.Close();
                return settings;
            } else {
                Settings settings = new Settings();
                Save(settings);
                return settings;
            }
        }

        private static bool IsExist() {
            if (File.Exists(SettingsFile)) {
                return true;
            } else {
                return false;
            }
        }
    }

    public class Account {
        public string AccessToken;
        public string AccessSecret;
        public string ScreenName;
        public long UserId;
    }

    public class Information {
        public const string Title = "Mystter - Send Tweet";
        public const string Version = "0.2";
    }
}
