using CoreTweet;
using Mystter_SendTweet.Forms;
using Mystter_SendTweet.Helpers;
using Mystter_SendTweet.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Mystter_SendTweet.Entities {
  public class AccountSwitcher {
    public List<Account> Accounts { get; set; }
    public int SelectedIndex { get; set; }
    [XmlIgnore]
    public Account SelectedAccount {
      get {
        if (0 <= SelectedIndex && SelectedIndex < Accounts.Count()) {
          return Accounts.ElementAt(SelectedIndex);
        } else {
          return null;
        }
      }
      set {
        SelectedIndex = Accounts.IndexOf(value);
      }
    }

    public AccountSwitcher() {
      Accounts = new List<Account>();
    }

    public bool IsEmpty() {
      return SelectedAccount == null || Accounts.Count == 0;
    }

    public void Add() {
      START:
      var s = OAuth.Authorize(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret);
      var form = new AuthBrowser(s.AuthorizeUri.AbsoluteUri + "&lang=" + LocalizeHelper.CurrentLanguage);
      form.ShowDialog();
      if (form.Success) {
        var _tokens = s.GetTokens(form.PIN);
        SetAccount(_tokens);
      } else if (Accounts.Count == 0) {
        if (MessageHelper.RetryAddingAccount()) {
          goto START;
        } else {
          Environment.Exit(0);
        }
      } else {
        MessageHelper.Show(Resources.FailedToAddAccountMessage);
      }
      form.Dispose();
    }

    private void SetAccount(Tokens _tokens) {
      var accessToken = _tokens.AccessToken;
      var accessSecret = _tokens.AccessTokenSecret;

      var account = new Account(accessToken, accessSecret);
      if (Accounts.Contains(account)) {
        MessageHelper.Show(Resources.AccountAlreadyAddedMessage);
        return;
      }
      Accounts.Add(account);
      SelectedAccount = account;
    }

    public bool Remove(Account selected) {
      if (!Accounts.Contains(selected))
        return false;

      Accounts.Remove(selected);
      SelectedAccount = Accounts.FirstOrDefault();
      return true;
    }
  }
}
