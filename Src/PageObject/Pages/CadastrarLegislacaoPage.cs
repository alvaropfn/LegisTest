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
  class CadastrarLegislacaoPage : BaseDriver
  {
    protected IWebDriver driver;

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
    protected IWebElement btnSendAnexo;


    public CadastrarLegislacaoPage(IWebDriver driver) : base(driver)
    {
      slcEsfera = FindBy(Selector.ID, "idEsferaGovernamental");
      slcAreaAtuacao = FindBy(Selector.ID, "select_idAreaAtuacao");
      slcMunicipio = FindBy(Selector.ID, "idCidade");

      slcTipoNorma = FindBy(Selector.ID, "idTipoNorma");
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
      btnSendAnexo = FindBy(Selector.XPATH, "//*[@id='legislacaoCadastroForm']/div[8]/button").Click();

    }

    public void submitForm()
    {
      
    }
  }

}