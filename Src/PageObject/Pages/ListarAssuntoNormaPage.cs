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

    protected IWebElement table;
    public ListarAssuntoNormaPage(IWebDriver driver) : base(driver)
    {
      txtSearchInput = FindBy(Selector.XPATH, "//*[@id='DataTables_Table_7_filter']/label/input");
      
      btnNovo = FindBy(Selector.XPATH, "//*[@id='consulta']/a");

      table = FindBy(Selector.XPATH, "//*[@id='DataTables_Table_13']/tbody");
    }

    public void performSearch(string text)
    {
      txtSearchInput.Click();
      txtSearchInput.SendKeys(text);
      txtSearchInput.Submit();
    }

    // //*[@id="DataTables_Table_13"]/tbody/tr[1]/td[2]/small

    // //*[@id="DataTables_Table_13"]/tbody/tr[1]
  }
}