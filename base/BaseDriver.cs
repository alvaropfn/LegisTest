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

using LegisTests.pages;

namespace LegisTests
{
  public class BaseDriver
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    protected Actions actions;

    protected int spanTime;

    public BaseDriver(IWebDriver driver, int spanTime = 10)
    {
      this.driver = driver;

      this.actions = new Actions(driver);

      this.spanTime = spanTime;
      this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(this.spanTime));
    }

    public IWebElement FindBy(Selector selector, string refs, WebDriverWait waiter = null){
      IWebElement toReturn;
      try
      {
        switch (selector)
        {
          case Selector.ID:
            toReturn = waiter != null ?
            waiter.Until(ExpectedConditions.ElementExists(By.Id(refs))) :
            this.wait.Until(ExpectedConditions.ElementExists(By.Id(refs)));
            break;
          case Selector.CLASS:
            toReturn = waiter != null ?
            waiter.Until(ExpectedConditions.ElementExists(By.ClassName(refs))) :
            this.wait.Until(ExpectedConditions.ElementExists(By.ClassName(refs)));
            break;
          case Selector.CSS:
              toReturn = waiter != null ?
              waiter.Until(ExpectedConditions.ElementExists(By.CssSelector(refs))) :
              this.wait.Until(ExpectedConditions.ElementExists(By.CssSelector(refs)));
              break;
          case Selector.XPATH:
              toReturn = waiter != null ?
              waiter.Until(ExpectedConditions.ElementExists(By.XPath(refs))) :
              this.wait.Until(ExpectedConditions.ElementExists(By.XPath(refs)));
              break;
          case Selector.LINK:
              toReturn = waiter != null ?
              waiter.Until(ExpectedConditions.ElementExists(By.LinkText(refs))) :
              this.wait.Until(ExpectedConditions.ElementExists(By.LinkText(refs)));
              break;
          default:
              toReturn = null;
              break;
        }
      
      }
      catch (System.Exception)
      {toReturn = null;}

      Thread.Sleep(250);
      return toReturn;
    }

    public enum Selector {
      ID,
      CLASS,
      CSS,
      XPATH,
      LINK,
    }

  }
}