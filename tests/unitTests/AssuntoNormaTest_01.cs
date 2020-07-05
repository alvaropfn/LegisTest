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
  public class AssuntoNormaTest_01 : BaseTest
  {
    public const string norma01 = "norma-18902ybcis0";
    public AssuntoNormaTest_01() : base (
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

    // [TestCase (norma01)]
    public void cadastrarAssuntonorma(string _assuntoNorma)
    {
      goToPageCadastrarAssuntoNorma();
      CadastrarAssuntoNormaPage page = new CadastrarAssuntoNormaPage(driver);
      page.CadastrarNorma(_assuntoNorma);

      AssertSucess();
    }

    // [TestCase (norma01)]
    public void listarAssuntonorma(string _assuntoNorma)
    {
      goToPageListarAssuntoNorma();
      ListarAssuntoNormaPage page = new ListarAssuntoNormaPage(driver);
      page.performSearch(_assuntoNorma);
    }
  }
}