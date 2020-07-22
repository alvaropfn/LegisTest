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
  public class ListarLegislacaoPage : BaseDriver
  {
    protected IWebElement txtNumeroNorma;
    protected IWebElement txtAno;
    protected IWebElement slcTipoNorma;
    protected IWebElement slcAssuntoNorma;

    protected IWebElement slcMunicipio;
    protected IWebElement slcEsfera;
    protected IWebElement txtEmenta;

    protected IWebElement slcOrgaoCadastrante;
    protected IWebElement datInicioVigencia;
    protected IWebElement datFimVigencia;
    protected IWebElement slcSituacaoLegislacao;

    protected IWebElement slcOrgaoAssociado;
    protected IWebElement btnAddOrgaoAssociado;

    protected IWebElement btnApplyFilter;
    protected IWebElement btnClearFilter;

    public ListarLegislacaoPage (IWebDriver driver) : base(driver)
    {
      txtNumeroNorma = FindBy(Selector.ID, "numeroNorma");
      txtAno = FindBy(Selector.ID, "anoNorma");
      txtNumeroNorma = FindBy(Selector.ID, "numeroNorma");
      slcTipoNorma = FindBy(Selector.ID, "idTipoNorma");
      slcAssuntoNorma = FindBy(Selector.ID, "idAssuntoNorma");

      slcMunicipio = FindBy(Selector.ID, "idCidade");
      slcEsfera = FindBy(Selector.ID, "idEsferaGovernamental");
      txtEmenta = FindBy(Selector.ID, "ementa");

      slcOrgaoCadastrante = FindBy(Selector.ID, "idOrgaoCadastrante");
      datInicioVigencia = FindBy(Selector.ID, "dataInicioVigencia");
      datFimVigencia = FindBy(Selector.ID, "dataFimVigencia");
      slcSituacaoLegislacao = FindBy(Selector.ID, "legislacaoValidada");

      slcOrgaoAssociado = FindBy(Selector.ID, "idOrgaoAssociado");
      btnAddOrgaoAssociado = FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-consulta/div[1]/div[2]/div/form/div[1]/div[13]/button"); //TODO: should have an id

      btnApplyFilter = FindBy(Selector.XPATH, "//html/body/app-root/app-dashboard/div/div/main/app-legislacao-consulta/div[1]/div[2]/div/form/div[2]/button[1]"); //TODO: should have an id
      btnClearFilter = FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-consulta/div[1]/div[2]/div/form/div[2]/button[2]"); //TODO: should have an id
    }

    public void SearchEmenta(string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum")
    {
      txtEmenta.Clear();
      txtEmenta.SendKeys(text);
    }

    public void ClearSearch(){
      btnClearFilter.Click();
    }
    public void SubmitSearch()
    {
      btnApplyFilter.Click();
      Thread.Sleep(5000);
    }

    public IWebElement getDelete()
    {
      return FindBy(Selector.ID, "legislacao-excluir-1");
    }

    public IWebElement getFile()
    {
      return FindBy(Selector.ID, "legislacao-download-1");
    }

    public IWebElement getEdit()
    {
      return FindBy(Selector.ID, "legislacao-view-1");
    }
    public void DeleteLegislacao()
    {
      getDelete().Click();
      Thread.Sleep(250);
      FindBy(Selector.XPATH, "/html/body/div[2]/div/div[3]/button[1]").Click(); // confirm deletation
      Thread.Sleep(250);
    }
  }
}
