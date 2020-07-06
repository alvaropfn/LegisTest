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
  public class LegislacaoTest_01 : BaseTest
  {
    public const string ementa01 = " aiosdhiadf32458jg";
    public LegislacaoTest_01() : base (
        new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory)),
        5)
    {}

    public override void AssertBadRequest(){}

    [TestCase (ementa01)]
    public void CadastrarLegislacao(string ementa)
    {
      goToPageCadastrarLegislacao();

      CadastrarLegislacaoPage page = new CadastrarLegislacaoPage(driver);

      page.fetchLegislacao();
      page.chooseEmenta(ementa01);
      page.submitLegislacao();
      AssertSucess();
    }

    [TestCase (ementa01)]
    public void SearchEmenta(String text)
    {
      goToPageListarLegislacao();
      ListarLegislacaoPage page = new ListarLegislacaoPage(driver);

      // page.ClearSearch();
      // page.SubmitSearch();
      page.SearchEmenta(text);
      page.SubmitSearch();

      Assert.IsNotNull(page.getDelete());
      page.DeleteLegislacao();
    }

    public override void SetupTest() {

      // login
      LoginPage loginpage = new LoginPage(driver);
      loginpage.PerformLogin(
        "05510151447",
        "tce@123",
        LoginPage.Operator.INTERN
      );

      fetchMenu();
    }
  }

}