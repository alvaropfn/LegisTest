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
  class CadastrarAssuntoNormaPage : BaseDriver
  {
    protected IWebDriver driver;

    protected IWebElement txtNomeAssuntoNorma;

    protected IWebElement btnSalvarNorma;

    public CadastrarAssuntoNormaPage(IWebDriver driver) : base(driver)
    {
      txtNomeAssuntoNorma = FindBy(Selector.ID, "nomeAssuntoNorma");
      btnSalvarNorma = FindBy(Selector.ID, "idButtonSalvar");
    }

    public void CadastrarNorma(string text)
    {
      txtNomeAssuntoNorma.Clear();
      txtNomeAssuntoNorma.SendKeys(text);
      btnSalvarNorma.Click();
    }
  }
}