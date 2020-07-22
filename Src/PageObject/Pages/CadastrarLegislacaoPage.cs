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

namespace LegisTests.pages
{
  public class CadastrarLegislacaoPage : BaseDriver
  {
    protected IWebElement slcEsfera;
    protected IWebElement slcAreaAtuacao;
    protected IWebElement slcMunicipio;

    protected IWebElement slcTipoNorma;
    protected IWebElement txtAno;
    protected IWebElement txtNumeroNorma;

    protected IWebElement slcMeioPublicacao;
    protected IWebElement datPublicacao;
    protected IWebElement datInicioVigencia;
    protected IWebElement datFimVigencia;

    protected IWebElement txtEmenta;
    protected IWebElement txtEnderecoEletronico;

    protected IWebElement slcAssuntoNorma;
    protected IWebElement btnAddAssuntoNorma;
    protected IWebElement slcOrgaoAssociado;
    protected IWebElement btnAddOrgaoAssociado;

    protected IWebElement pdfAnexo;
    protected IWebElement btnSubmit;


    public CadastrarLegislacaoPage(IWebDriver driver) : base(driver)
    {
      slcEsfera = FindBy(Selector.ID, "idEsferaGovernamental");
      slcAreaAtuacao = FindBy(Selector.ID, "select_idAreaAtuacao");
      slcMunicipio = FindBy(Selector.ID, "idCidade");

      slcTipoNorma = FindBy(Selector.ID, "select_idTipoNorma");
      txtAno = FindBy(Selector.ID, "anoNorma");
      txtNumeroNorma = FindBy(Selector.ID, "numeroNorma");

      slcMeioPublicacao = FindBy(Selector.ID, "select_idMeioPublicacao");
      datPublicacao = FindBy(Selector.ID, "dataPublicacao");
      datInicioVigencia = FindBy(Selector.ID, "dataInicioVigencia");
      datFimVigencia = FindBy(Selector.ID, "dataFimVigencia");

      txtEmenta = FindBy(Selector.ID, "ementa");
      txtEnderecoEletronico = FindBy(Selector.ID, "enderecoEletronico");

      slcAssuntoNorma = FindBy(Selector.ID, "idAssuntoNorma");
      btnAddAssuntoNorma = FindBy(Selector.ID, "acao");
      slcOrgaoAssociado = FindBy(Selector.ID, "idOrgao");
      btnAddOrgaoAssociado = FindBy(Selector.ID, "acaoOrgao");

      pdfAnexo = FindBy(Selector.ID, "anexo");

      btnSubmit = FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[8]/button");

    }

    public void chooseEsfera(Esfera esfera = Esfera.MUNICIPAL)
    {
      slcEsfera.Click();
      Thread.Sleep(250);
      FindBy(Selector.XPATH, $"/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[{(int)esfera}]").Click();
    }

    public void chooseAreaAtuacao(Atuacao atuacao = Atuacao.CIVIL)
    {
      slcAreaAtuacao.Click();
      Thread.Sleep(250);
      FindBy(Selector.XPATH, $"/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[2]/ng-select/ng-dropdown-panel/div/div[2]/div[{(int)atuacao}]").Click();
    }
    public void chooseMunicipio(int municipio = 88)
    {
      slcMunicipio.Click();
      Thread.Sleep(250);
      FindBy(Selector.XPATH, $"/html/body/ng-dropdown-panel/div/div[2]/div[{(int)municipio}]").Click();
      
      waitAlert();
    }

    public void chooseTipoNorma(int tipoNorma = 3)
    {
      slcTipoNorma.Click();
      Thread.Sleep(250);
      FindBy(Selector.XPATH, $"/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[2]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[{tipoNorma}]").Click();
    }
    public void chooseMeioPublicacao(MeioPublicacao meio = MeioPublicacao.MUNICIPIO)
    {
      slcMeioPublicacao.Click();
      Thread.Sleep(250);
      FindBy(Selector.XPATH, $"/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[3]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[{(int)meio}]").Click();
    }
    public void chooseAno(int ano = 1950)
    {
      txtAno.Click();
      txtAno.Clear();
      txtAno.SendKeys($"{ano}");
    }

    public void chooseDataPublicacao(
      int dia = 01,
      int mes = 01,
      int ano = 1950)
    {
      chooseDate(datPublicacao, dia, mes, ano);
    }

    public void chooseDataInicioVigencia(
      int dia = 01,
      int mes = 01,
      int ano = 1950)
    {
      chooseDate(datInicioVigencia, dia, mes, ano);
    }

    public void chooseDataFimVigencia(
      int dia = 01,
      int mes = 01,
      int ano = 1950)
    {
      chooseDate(datFimVigencia, dia, mes, ano);
    }

    // TODO perform validations
    private void chooseDate(
      IWebElement picker,
      int dia,
      int mes,
      int ano)
    {
      picker.Click();
      picker.Clear();
      picker.SendKeys($"{dia}/{mes}/{ano}");
    }

    public void chooseEmenta(string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum")
    {
      // txtEmenta.Click();
      txtEmenta.Clear();
      txtEmenta.SendKeys(text);
    }

    public void chooseEnderecoEletronico(string text = "https://www.google.com.br/")
    {
      // txtEnderecoEletronico.Click();
      txtEnderecoEletronico.Clear();
      txtEnderecoEletronico.SendKeys(text);
    }

    public void chooseAssuntosNorma(int amount = 3)
    {
      string option = "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[5]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/";
      for (int i = 1; i < amount+1; i++)
      {
          slcAssuntoNorma.Click();
          FindBy(Selector.XPATH, option + $"div[{i}]").Click();
          Thread.Sleep(100);
          btnAddAssuntoNorma.Click();
      }
    }

    public void chooseOrgao(int amount = 3)
    {
      string option = "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[5]/div[3]/ng-select/ng-dropdown-panel/div/div[2]/";
      for (int i = 1; i < amount+1; i++)
      {
          slcOrgaoAssociado.Click();
          FindBy(Selector.XPATH, option + $"div[{i}]").Click();
          Thread.Sleep(100);
          btnAddOrgaoAssociado.Click();
      }
    }

    public void choosePDF(string path = "")
    {
      if(path == "")
      {
        pdfAnexo.SendKeys(findPDF());
      } else
      {
        pdfAnexo.SendKeys(path);
      }
    }

    private string findPDF()
    {
      string osv = System.Environment.OSVersion.VersionString;
      string divider = osv.Contains("Windows") ? "\\" : "/";
      string path = Environment.CurrentDirectory;
      string[] splited = path.Split(divider);
      string toReturn = "";
      for (int i = 0; i < splited.Length - 3; i++)
      {
        toReturn += splited[i] + divider;
      }
      toReturn += "teste.pdf";
      return toReturn;
    }
    public void fetchLegislacao()
    {
      chooseEsfera();
      chooseAreaAtuacao();
      chooseMunicipio();
      chooseTipoNorma();
      chooseAno();
      chooseMeioPublicacao();
      chooseDataPublicacao();
      chooseDataInicioVigencia();
      chooseDataFimVigencia();
      chooseEmenta();
      chooseEnderecoEletronico();
      chooseAssuntosNorma();
      chooseOrgao();
      choosePDF();
    }

    public void submitLegislacao()
    {
      btnSubmit.Click();
    }

    public enum Esfera{
      MUNICIPAL = 1,
      ESTADUAL = 2,
      FEDERAL = 3
    }

    public enum Atuacao{
      CIVIL = 1,
      MILITAR = 2,
      CIVILMILITAR = 3
    }
  }

  public enum MeioPublicacao
  {
    UNIAO = 1,
    ESTADO = 2,
    MUNICIPIO = 3,
    FEMURN = 4,
    FECAM = 5
  }
}