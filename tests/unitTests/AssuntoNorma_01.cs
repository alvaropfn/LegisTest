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

using LegisTests.pages;

namespace LegisTests
{
  [TestFixture]
  public class AssuntoNorma_01 : BaseTest
  {

    public AssuntoNorma_01(IWebDriver driver, int spanTime) : base(driver, spanTime){}

    [SetUp]
    public void loginTest()
    {

      baseURL = "http://localhost:4200/";

      driver.Manage().Window.Maximize();
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
      driver.Navigate().GoToUrl(baseURL);

      // login
      LoginPage loginpage = new LoginPage(driver);
      loginpage.PerformLogin("05510151447", "tce@123");

      // go to further modules
      lnkModulo = FindBy(Selector.LINK, "Módulo de administração do Legis");
      lnkPage = FindBy(Selector.ID, "AssuntoNorma");

      lnkModulo.Click();
      lnkPage.Click();
    }

    [Test] //todo a proper test
    public void doNothing(){}

    
  }
}