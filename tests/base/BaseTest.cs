using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using SeleniumExtras.WaitHelpers;

using LegisTests.pages;

namespace LegisTests
{
  public abstract class BaseTest : BaseDriver
  {
    public string baseURL;
    // public IWebDriver driver;
    public IWebElement lnkModulo;
    public IWebElement lnkPage;
    public StringBuilder verificationErrors;

    public BaseTest(IWebDriver driver, int spanTime) : base( driver, spanTime)
    {
      verificationErrors = new StringBuilder();
    }

    // public setup(string baseURL, IWebDriver driver,IWebElement lnkModulo, IWebElement lnkPage){
    //   this.baseURL = baseURL;
    //   this.driver = driver;
    //   this.lnkModulo = lnkModulo;
    //   this.lnkPage = lnkPage;
    // }


    public void goToModule()
    {
      lnkModulo.Click();
    }

    public void goToPage()
    {
      lnkPage.Click();
    }

    [TearDown]
    public void TeardownTest()
    {
      try
      {
        driver.Quit();
      }
      catch (Exception)
      {
        // Ignore errors if unable to close the browser
      }
      Assert.AreEqual("", verificationErrors.ToString());
    }
  }
}