using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

namespace LegisTests.pages {
  class LoginPage : BaseDriver
  {
    protected IWebDriver driver;

    public IWebElement txtUserName;
    public IWebElement txtPassword;
    public IWebElement btnLogin;

    public LoginPage(IWebDriver driver) : base(driver)
    {
      txtUserName = FindBy(Selector.ID, "username");
      txtPassword = FindBy(Selector.ID, "password");
      btnLogin = FindBy(Selector.XPATH, "(//input[@type='text'])[2]");
    }

    public void PerformLogin(string username, string password)
    {
      txtUserName.Click();
      txtUserName.Clear();
      txtUserName.SendKeys(username);
      txtPassword.Click();
      txtPassword.Clear();
      txtPassword.SendKeys(password);

      btnLogin.Click();
    }
  }

}