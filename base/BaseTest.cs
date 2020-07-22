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
      baseURL = "http://localhost:4200/";
      verificationErrors = new StringBuilder();
      driver.Manage().Window.Maximize();
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

      driver.Navigate().GoToUrl(baseURL);
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
    
    Thread.Sleep(500);
  }

    // TODO: fix path to page on front
    public void goToPageCadastrarAssuntoNorma()
    { 
      Thread.Sleep(1000);
      // lnkModuleADMLegis.Click();
      // lnkPageAssuntoNorma.Click();
      
      driver.Navigate().GoToUrl("http://localhost:4200/#/dashboard/assuntonorma/new");
    }
    public void goToPageListarAssuntoNorma()
    {
      Thread.Sleep(1000);
      lnkModuleADMLegis.Click();
      lnkPageAssuntoNorma.Click();
    }
    public void goToPageCadastrarLegislacao()
    {
      Thread.Sleep(1000);
      lnkModuleCTRLegis.Click();
      lnkPageCadastrarLegislacao.Click();
    }
    public void goToPageListarLegislacao()
    {
      Thread.Sleep(1000);
      lnkModuleCTRLegis.Click();
      lnkPageListarLegislacao.Click();
    }

    public void AssertSucess()
    {
      Thread.Sleep(500);
      Assert.AreEqual(FindBy(Selector.ID,"swal2-title").Text, "Sucesso");
      Thread.Sleep(500);
    }
    
    public bool AssertElementExist(IWebElement element)
    {
      return element != null;
    }
    public abstract void AssertBadRequest();

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
