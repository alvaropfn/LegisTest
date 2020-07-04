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
  [TestFixture]
  class UnitTest01
  {
    public StringBuilder verificationErrors = new StringBuilder();
    public IWebDriver driver;



    [SetUp]
    public void loginTest()
    {
      this.driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory));

      driver.Navigate().GoToUrl("http://localhost:4200/");

      LoginPage loginpage = new LoginPage(driver);
      loginpage.PerformLogin("05510151447", "tce@123");
    }

    [Test] //todo a proper test
    public void doNothing(){}

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