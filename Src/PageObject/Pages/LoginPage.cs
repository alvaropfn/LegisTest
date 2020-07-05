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
    public IWebElement drpOperator;
    public IWebElement slcOperatorIntern;
    public IWebElement slcOperatorExtern;
    
    public IWebElement btnLogin;

    public enum Operator{
      INTERN = 1,
      EXTERN = 2,
    }

    public LoginPage(IWebDriver driver) : base(driver)
    {
      txtUserName = FindBy(Selector.ID, "username");
      txtPassword = FindBy(Selector.ID, "password");
      btnLogin = FindBy(Selector.ID, "idEntrarLogin");

      drpOperator = FindBy(Selector.XPATH, "/html/body/app-root/tce-login/div/form/div[3]/ng-select/div");

    }
    /*
    #logincp > ng-select > div
    */

    public void PerformLogin(string username, string password, Operator _operator = Operator.INTERN)
    {
      txtUserName.Click();
      txtUserName.Clear();
      txtUserName.SendKeys(username);
      txtPassword.Click();
      txtPassword.Clear();
      txtPassword.SendKeys(password);

      drpOperator.Click();
      String slcPath = "/html/body/app-root/tce-login/div/form/div[3]/ng-select/ng-dropdown-panel/div/div[2]/";
      if(_operator == Operator.EXTERN) {
        slcOperatorExtern = FindBy(Selector.XPATH, slcPath + "div[2]");
        slcOperatorExtern.Click();
      } else {
        slcOperatorIntern = FindBy(Selector.XPATH, slcPath + "div[1]");
        slcOperatorIntern.Click();
      }

      btnLogin.Click();
    }

  }

}