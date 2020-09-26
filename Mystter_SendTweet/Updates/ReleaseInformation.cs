using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Mystter_SendTweet {
  public class ReleaseInformation {
    public ReleaseInformation(GitHubRelease release) {
      this.Release = release;
    }

    public GitHubRelease Release { get; private set; }

    public string Version {
      get {
        return Release.TagName;
      }
    }

    public DateTime ReleasedAt {
      get {
        return Release.CreatedAt;
      }
    }

    public string ReleaseUrl {
      get {
        return Release.HtmlUrl;
      }
    }

    // ReleaseNotes_en.txt
    // ReleaseNotes_ja.txt
    public string ReleaseNotes {
      get {
        var asset = Release.Assets.Where(x => x.ContentType == "text/plain" && x.Name.Contains(LocalizeHelper.CurrentLanguage)).FirstOrDefault();
        using (var wc = new WebClient()) {
          wc.Encoding = Encoding.UTF8;
          return wc.DownloadString(asset.BrowserDownloadUrl).Trim();
        }
      }
    }

    public string InstallerDownloadUrl {
      get {
        return Installer.BrowserDownloadUrl;
      }
    }

    public string InstallerFileName {
      get {
        return Installer.Name;
      }
    }

    private GitHubAsset Installer {
      get {
        return Release.Assets.Where(x => x.ContentType == "application/x-msdownload").FirstOrDefault();
      }
    }

    public string DownloadDestination {
      get {
        var destinationFolder = Path.Combine(Path.GetTempPath(), Information.Title);
        Directory.CreateDirectory(destinationFolder);
        var destinationFile = Path.Combine(destinationFolder, InstallerFileName);
        return destinationFile;
      }
    }
  }
}
