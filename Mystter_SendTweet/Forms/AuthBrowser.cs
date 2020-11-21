using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Mystter_SendTweet.Entities;
using Mystter_SendTweet.Helpers;
using Mystter_SendTweet.Languages;

namespace Mystter_SendTweet.Forms {
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
      authorizingLabel.Text = MessageHelper.ConcatWithNewLine(Resources.Authorizing, Resources.WindowClosing);
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
        //var logout = webBrowser1.Document.GetElementsByTagName("button").OfType<HtmlElement>()
        //  .Where(x => x.OuterHtml.Contains("js-logout-button")).FirstOrDefault();
        //logout.InvokeMember("click");
        // javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split("; ");for(e=0;e<a.length&&a[e];e++){f++;for(b="."+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,"")){for(c=location.pathname;c;c=c.replace(/.$/,"")){document.cookie=(a[e]+"; domain="+b+"; path="+c+"; expires="+new Date((new Date()).getTime()-1e11).toGMTString());}}}alert("Expired "+f+" cookies");})())
        // javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())
        string clearCookiesScript = "webBrowser.Navigate(\"javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())\")";
        webBrowser1.Navigate(clearCookiesScript);
      } else if (webBrowser1.Url.OriginalString.Contains(AuthUrl1) || webBrowser1.Url.OriginalString.Contains(AuthUrl2)) {
        // login
      } else {
        Close();
      }
    }

    private void AuthBrowser_Load(object sender, EventArgs e) {
      Text = Information.GetConcatTitle(Resources.OAuth);
      webBrowser1.Navigate(URL);
    }

    private void AuthBrowser_FormClosing(object sender, FormClosingEventArgs e) {
      webBrowser1.Dispose();
    }
  }
}
