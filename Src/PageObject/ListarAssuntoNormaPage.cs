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
  class ListarAssuntoNormaPage : BaseDriver
  {
    protected IWebDriver driver;

    protected IWebElement txtSearchInput;
    protected IWebElement btnNovo;
    public ListarAssuntoNormaPage(IWebDriver driver) : base(driver)
    {
      txtSearchInput = FindBy(Selector.XPATH, "//*[@id='DataTables_Table_7_filter']/label/input");
      btnNovo = FindBy(Selector.XPATH, "//*[@id='consulta']/a");
    }
  }
}