using System;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LegisTests
{
  [TestFixture]
  public class CadasTroLegislacao_Sucesso_00 : BaseTest
  {
    SelectEsfera selectEsfera;
    private bool acceptNextAlert = true;
    public CadasTroLegislacao_Sucesso_00(){
      selectEsfera = new SelectEsfera();
    }

    [Test]
    public void CadasTroLegislacao_Sucesso_00Test()
    {
      //* go to module
      FindBy(Selector.LINK, "Módulo de controle de legislações do Legis").Click();
      FindBy(Selector.ID, "LegislacaoCadastro").Click();

      //* Select Esfera
      selectEsfera.choseEsfera(Esfera.MUNICIPAL);
      // FindBy(Selector.ID, "select_idAssuntoNorma").Click();
      // FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[1]").Click();

      //* Select Area Atuacao
      FindBy(Selector.ID, "select_idAreaAtuacao").Click();
      FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[2]/ng-select/ng-dropdown-panel/div/div[2]/div[1]").Click();

      //* Select Municipio
      FindBy(Selector.ID, "idCidade").Click();
      FindBy(Selector.XPATH, "/html/body/ng-dropdown-panel/div/div[2]/div[88]").Click();

      //* Select tipo norma
      FindBy(Selector.ID, "select_idTipoNorma").Click();
      FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[2]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[3]").Click();

      //* Select Ano
      IWebElement anoNorma = FindBy(Selector.ID, "anoNorma");
      if(anoNorma != null){
          anoNorma.Click();
          anoNorma.Clear();
          anoNorma.SendKeys("2019");
      }

      //* Select Numero
      IWebElement numeroNorma = FindBy(Selector.ID, "numeroNorma");
      if(numeroNorma != null){
          numeroNorma.Click();
          numeroNorma.Clear();
          numeroNorma.SendKeys("0123456789");
      }

      //* Select Meio Publicacao
      FindBy(Selector.ID, "select_idMeioPublicacao").Click();
      FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[3]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[3]").Click();

      //* Select Data Publicacao
      IWebElement dataPublicacao = FindBy(Selector.ID, "dataPublicacao");
      dataPublicacao.Click();
      dataPublicacao.Clear();
      dataPublicacao.SendKeys("01/01/1950");

      //* Select Data Inicio Vigencia
      IWebElement dataInicioVigencia = FindBy(Selector.ID, "dataInicioVigencia");
      dataInicioVigencia.Click();
      dataInicioVigencia.Clear();
      dataInicioVigencia.SendKeys("01/01/2020");

      //* Select Data Fim Vigencia
      IWebElement dataFimVigencia = FindBy(Selector.ID, "dataFimVigencia");
      dataFimVigencia.Click();
      dataFimVigencia.Clear();
      dataFimVigencia.SendKeys("01/12/2020");

      //* Select pdf
      IWebElement anexo = FindBy(Selector.ID, "anexo");
      // anexo.Click();
      // anexo.Clear();
      anexo.SendKeys(@"C:/Users/alvaro/Documents/Flutter-Dev-Syllabus.pdf");

      //* Enviar
      FindBy(Selector.XPATH, "//*[@id='legislacaoCadastroForm']/div[8]/button").Click();

      Assert.AreEqual(FindBy(Selector.ID,"swal2-title").Text, "Sucesso");
    }

    private string CloseAlertAndGetItsText() {
      try {
        IAlert alert = this.driver.SwitchTo().Alert();
        string alertText = alert.Text;
        if (acceptNextAlert) {
            alert.Accept();
        } else {
            alert.Dismiss();
        }
        return alertText;
      } finally {
        acceptNextAlert = true;
      }
    }
  }
}
