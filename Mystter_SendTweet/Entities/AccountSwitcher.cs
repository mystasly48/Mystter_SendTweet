using CoreTweet;
using Mystter_SendTweet.Helpers;
using Mystter_SendTweet.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Mystter_SendTweet.Entities {
  public class AccountSwitcher {
    public List<Account> Accounts { get; private set; }
    private Account _selectedAccount;
    public Account SelectedAccount {
      get {
        return _selectedAccount;
      }
      set {
        if (Accounts.Contains(value)) {
          _selectedAccount = value;
          SelectedTokens = Tokens.Create(SecretKeys.ConsumerKey, SecretKeys.ConsumerSecret, SelectedAccount.AccessToken, SelectedAccount.AccessSecret);
        } else {
          throw new MissingFieldException(value.ToString());
        }
      }
    }
    [XmlIgnore]
    public Tokens SelectedTokens { get; private set; }

    public AccountSwitcher() {
      Accounts = new List<Account>();
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
        MessageBox.Show(Resources.FailedToAddAccount);
      }
      form.Dispose();
    }

    private void SetAccount(Tokens _tokens) {
      var accessToken = _tokens.AccessToken;
      var accessSecret = _tokens.AccessTokenSecret;
      var screenName = _tokens.ScreenName;
      var userId = _tokens.UserId;

      if (IsDuplicateAccount(userId)) {
        MessageBox.Show(Resources.alreadyAdded);
        return;
      }

      var account = new Account(accessToken, accessSecret, screenName, userId);
      Accounts.Add(account);
      SelectedAccount = account;
    }

    private bool IsDuplicateAccount(long userId) {
      return Accounts.Any(account => account.UserId == userId);
    }

    public bool Remove(Account selected) {
      if (!Accounts.Contains(selected))
        return false;

      Accounts.Remove(selected);
      if (Accounts.Count == 0) {
        if (MessageHelper.RetryAddingAccount()) {
          Add();
        } else {
          Environment.Exit(0);
        }
      } else {
        SelectedAccount = Accounts.FirstOrDefault();
      }
      return true;
    }
  }
}
