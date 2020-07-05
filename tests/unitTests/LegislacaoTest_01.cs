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

namespace LegisTests
{

  [TestFixture]
  public class LegislacaoTest_01 : BaseTest
  {
    
    public LegislacaoTest_01() : base (
        new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory)),
        5)
    {}

    public override void SetupTest() {
      baseURL = "http://localhost:4200/";

      // login
      LoginPage loginpage = new LoginPage(driver);
      loginpage.PerformLogin(
        "05510151447",
        "tce@123",
        LoginPage.Operator.INTERN
      );
      fetchMenu();
      Thread.Sleep(500);
    }

    
  }

}