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
    
    public LegislacaoTest_01() : base (
        new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory)),
        5)
    {}

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
    public override void AssertBadRequest(){}

    [TestCase]
    public void CadastrarLegislacao()
    {

      goToPageCadastrarLegislacao();
      // waitAlert();

      CadastrarLegislacaoPage page = new CadastrarLegislacaoPage(driver);

      page.chooseEsfera();
      page.chooseAreaAtuacao();
      page.chooseMunicipio();
      page.chooseTipoNorma();
      page.chooseAno();
      page.chooseMeioPublicacao();
      page.chooseDataPublicacao();
      page.chooseDataInicioVigencia();
      page.chooseDataFimVigencia();
      page.chooseEmenta();
      page.chooseEnderecoEletronico();

      page.cadastrarLegislacao();

      Thread.Sleep(10000);
      // AssertSucess();
    }

    // [TestCase]
    public void ListarLegislacao()
    {
      goToPageListarLegislacao();
      ListarLegislacaoPage page = new ListarLegislacaoPage(driver);
      page.performSearch();

      AssertSucess();

    }

  }

}