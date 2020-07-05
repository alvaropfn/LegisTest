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
    string norma01 = "uma norma";
    string norma02 = "ota norma";
    public AssuntoNorma_01() : base (
        new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory)),
        5)
    {}

    public override void SetupTest() {
      baseURL = "http://localhost:4200/";

      driver.Manage().Window.Maximize();
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
      driver.Navigate().GoToUrl(baseURL);

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


    public override void AssertBadRequest(){
      Thread.Sleep(500);
      Assert.AreEqual(FindBy(Selector.XPATH,"/html/body/app-root/app-dashboard/div/div/main/app-assunto-norma-form/tce-server-error-messages/div[1]/ul/li").Text,"Campo nome Assunto Norma obrigatório");
      Thread.Sleep(500);
    }

    // [TestCase ("")]
    public void cadastrarAssuntoNormaFalha(string _assuntoNorma)
    {
      goToPageCadastrarAssuntoNorma();
      CadastrarAssuntoNormaPage page = new CadastrarAssuntoNormaPage(driver);
      page.CadastrarNorma(_assuntoNorma);
      AssertBadRequest();
    }

    // [TestCase ("uma norma")]
    public void cadastrarAssuntonorma(string _assuntoNorma)
    {
      goToPageCadastrarAssuntoNorma();
      CadastrarAssuntoNormaPage page = new CadastrarAssuntoNormaPage(driver);
      page.CadastrarNorma(_assuntoNorma);

      AssertSucess();
    }

    [TestCase ("Norma 012312509123")]
    public void listarAssuntonorma(string _assuntoNorma)
    {
      goToPageListarAssuntoNorma();
      ListarAssuntoNormaPage page = new ListarAssuntoNormaPage(driver);
      page.performSearch(_assuntoNorma);
    }
  }
}