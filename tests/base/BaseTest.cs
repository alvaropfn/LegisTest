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
  public abstract class BaseTest : BaseDriver
  {
    public string baseURL;

    public IWebElement lnkModuleADMLegis;
    public IWebElement lnkPageAssuntoNorma;

    public IWebElement lnkModuleCTRLegis;
    public IWebElement lnkPageCadastrarLegislacao;
    public IWebElement lnkPageListarLegislacao;

    public StringBuilder verificationErrors;

    public BaseTest(IWebDriver driver, int spanTime) : base( driver, spanTime)
    {
      verificationErrors = new StringBuilder();
    }

    [OneTimeSetUp]
    public abstract void SetupTest();

  public void fetchMenu()
  {
    lnkModuleADMLegis = FindBy(Selector.LINK, "Módulo de administração do Legis");
    lnkPageAssuntoNorma = FindBy(Selector.ID, "AssuntoNorma");


    lnkModuleCTRLegis = FindBy(Selector.LINK, "Módulo de controle de legislações do Legis");
    lnkPageCadastrarLegislacao = FindBy(Selector.ID, "LegislacaoCadastro");
    lnkPageListarLegislacao = FindBy(Selector.ID, "LegislacaoConsulta");

  }

    // TODO: fix it on front
    public void goToPageCadastrarAssuntoNorma()
    { 
      // lnkModuleADMLegis.Click();
      // lnkPageAssuntoNorma.Click();

      driver.Navigate().GoToUrl("http://localhost:4200/#/dashboard/assuntonorma/new");
    }
    public void goToPageListarAssuntoNorma()
    {
      lnkModuleADMLegis.Click();
      lnkPageAssuntoNorma.Click();
    }
    public void goToPageCadastrarLegislacao()
    {
      lnkModuleCTRLegis.Click();
      lnkPageCadastrarLegislacao.Click();
    }
    public void goToPageListarLegislacao()
    {
      lnkModuleCTRLegis.Click();
      lnkPageListarLegislacao.Click();
    }

    public void AssertSucess(){
      Thread.Sleep(500);
      Assert.AreEqual(FindBy(Selector.ID,"swal2-title").Text, "Sucesso");
      Thread.Sleep(500);
    }


    public  abstract void AssertBadRequest();

    [OneTimeTearDown]
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
