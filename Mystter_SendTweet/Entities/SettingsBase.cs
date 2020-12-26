using Mystter_SendTweet.Entities;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Mystter_SendTweet {
  public class SettingsBase<T> where T : new(){
    public void Save() {
      var serializer = new XmlSerializer(typeof(T));
      using (var writer = new StreamWriter(Information.SettingsFile, false, Encoding.UTF8)) {
        serializer.Serialize(writer, this);
      }
    }
  }
}
