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

    public void performSearch()
    {
      // FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-consulta/div[1]/div[2]/div/form/div[1]/div[8]/ng-select/ng-dropdown-panel/div/div[2]/div[345]").Click();

    }
  }
}
