using System.Net.NetworkInformation;

namespace Mystter_SendTweet.Helpers {
  public static class NetworkHelper {
    public static bool IsAvailable() {
      return NetworkInterface.GetIsNetworkAvailable();
    }
  }
}
