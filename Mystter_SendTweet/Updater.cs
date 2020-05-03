using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Mystter_SendTweet {
  public class Updater {
    private static readonly string GitHubReleasesUrl = "https://api.github.com/repos/mystasly48/Mystter_SendTweet/releases";
    private List<ReleaseInformation> Releases;

    public Updater() {
      Releases = GetReleases();
    }

    public bool IsLatestVersion {
      get {
        return Information.Version == LatestRelease.Version;
      }
    }

    private List<ReleaseInformation> GetReleases() {
      using (var wc = new WebClient()) {
        wc.Encoding = Encoding.UTF8;
        wc.Headers.Add(HttpRequestHeader.ContentType, "application/json");
        wc.Headers.Add(HttpRequestHeader.UserAgent, Information.Title+"/"+Information.Version);
        string json = wc.DownloadString(GitHubReleasesUrl);
        var releases = JsonConvert.DeserializeObject<List<GitHubRelease>>(json)
          .Where(x => !x.PreRelease && !x.Draft)
          .Select(x => new ReleaseInformation(x)).ToList();
        return releases;
      }
    }

    public ReleaseInformation LatestRelease {
      get {
        return Releases.FirstOrDefault();
      }
    }

    public List<ReleaseInformation> NewerReleases {
      get {
        return Releases.TakeWhile(x => x.Version != Information.Version).ToList();
      }
    }
  }
}
