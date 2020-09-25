using System.Globalization;

namespace Mystter_SendTweet.Helpers {
  public static class TweetHelper {
    public static bool IsEmpty(string tweet) {
      tweet = tweet.Replace(" ", "");
      tweet = tweet.Replace("　", "");
      tweet = tweet.Replace("\r", "");
      tweet = tweet.Replace("\n", "");
      return GetLength(tweet) == 0;
    }

    public static int GetLength(string tweet) {
      return new StringInfo(tweet).LengthInTextElements;
    }
  }
}
