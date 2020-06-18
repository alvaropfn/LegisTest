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
  public class SelectEsfera : BaseTest{
    public IWebElement choseEsfera(Esfera esfera) {
      //* Select Esfera
      IWebElement select_idAssuntoNorma = FindBy(Selector.ID, "select_idAssuntoNorma");

      int result;
      switch (esfera)
      {
        case Esfera.MUNICIPAL:
          result = 1;
          break;
        case Esfera.ESTADUAL:
          result = 2;
          break;
        case Esfera.FEDERAL:
          result = 3;
          break;
        default:
          result = 1;
          break;
      }

      FindBy(Selector.XPATH, $"/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[{result}]").Click();

      return select_idAssuntoNorma;
    }
  }
}