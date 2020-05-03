using Newtonsoft.Json;
using System;

namespace Mystter_SendTweet {
  public class GitHubAsset {
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("node_id")]
    public string NodeId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("uploader")]
    public GitHubUploader Uploader { get; set; }

    [JsonProperty("content_type")]
    public string ContentType { get; set; }

    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("size")]
    public long Size { get; set; }

    [JsonProperty("download_count")]
    public int DownloadCount { get; set; }

    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonProperty("browser_download_url")]
    public string BrowserDownloadUrl { get; set; }
  }
}
