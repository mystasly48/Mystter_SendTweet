using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Mystter_SendTweet.Languages;

namespace Mystter_SendTweet {
  public partial class AuthBrowser : Form {
    private static readonly string AuthUrl1 = "https://api.twitter.com/oauth/authorize";
    private static readonly string AuthUrl2 = "https://twitter.com/oauth/authorize";
    private static readonly string LogoutUrl = "https://twitter.com/logout";

    public bool Success { get; private set; }
    public string PIN { get; private set; }
    public string URL { get; private set; }

    public AuthBrowser(string URL) {
      InitializeComponent();
      this.URL = URL;
      authorizingLabel.Text = Resources.Authorizing + Environment.NewLine + Resources.WindowClosing;
      Success = false;
    }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
      if (webBrowser1.Url.OriginalString == AuthUrl1 || webBrowser1.Url.OriginalString == AuthUrl2) {
        var r = new Regex(@"<CODE>(\d+)</CODE>");
        var m = r.Match(webBrowser1.DocumentText);
        if (m != null) {
          PIN = m.Result("${1}");
          Success = true;
        }
        authorizingLabel.Visible = true;
        webBrowser1.Visible = false;
        webBrowser1.Navigate(LogoutUrl);
      } else if (webBrowser1.Url.OriginalString == LogoutUrl) {
        // logout
        var logout = webBrowser1.Document.GetElementsByTagName("button").OfType<HtmlElement>()
          .Where(x => x.OuterHtml.Contains("js-logout-button")).FirstOrDefault();
        logout.InvokeMember("click");
      } else if (webBrowser1.Url.OriginalString.Contains(AuthUrl1) || webBrowser1.Url.OriginalString.Contains(AuthUrl2)) {
        // login
      } else {
        Close();
      }
    }

    private void AuthBrowser_Load(object sender, EventArgs e) {
      Text = Information.TitleSimple + " - " + Resources.OAuth;
      webBrowser1.Navigate(URL);
    }

    private void AuthBrowser_FormClosing(object sender, FormClosingEventArgs e) {
      webBrowser1.Dispose();
    }
  }
}
