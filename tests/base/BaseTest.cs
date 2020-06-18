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
  public class BaseTest
  {
    private String BaseUrl;
    public IWebDriver driver;
    public WebDriverWait  wait;
    private StringBuilder verificationErrors;

    [OneTimeSetUp]
    public void SetupTest() {
      BaseUrl = "http://localhost:4200/";
      
      LimparMemoria();
      
      driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory));

      driver.Manage().Window.Maximize();
      driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
      wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

      verificationErrors = new StringBuilder();

      Login();
    }

    private void LimparMemoria () {
      string comando;
      comando = "tasklist | grep chromedriver";
      System.Diagnostics.Process.Start("CMD.exe", comando);

      comando = "taskkill /F /IM chromedriver.exe /T";
      System.Diagnostics.Process.Start("CMD.exe", comando);
    }

      public void Login() {
        driver.Navigate().GoToUrl(BaseUrl);

        IWebElement username = FindBy(Selector.ID, "username");
        username.Click();
        username.Clear();
        username.SendKeys("01208021478");

        IWebElement password = FindBy(Selector.ID, "password");
        password.Click();
        password.Clear();
        password.SendKeys("dev@123");

        FindBy(Selector.XPATH, "(//input[@type='text'])[2]").Click();
        FindBy(Selector.XPATH, "/html/body/app-root/tce-login/div/form/div[3]/ng-select/ng-dropdown-panel/div/div[2]/div[1]").Click();

        FindBy(Selector.ID, "idEntrarLogin").Click();
    }

    
    public IWebElement FindBy(Selector selector, string refs){
      IWebElement toReturn;
      try
      {
        switch (selector)
        {
          case Selector.ID:
            Console.WriteLine(refs);
            toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.Id(refs)));
            Console.WriteLine(refs);
            break;
        case Selector.CLASS:
            toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.ClassName(refs)));
            break;
          case Selector.CSS:
            toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.CssSelector(refs)));
            break;
          case Selector.XPATH:
            // toReturn = wait.Until(ExpectedConditions.ElementExists(By.XPath(refs)));
            toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.XPath(refs)));
            break;
          case Selector.LINK:
            toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.LinkText(refs)));
            break;
          default:
            toReturn = null;
            break;
        }
      }
      catch (System.Exception)
      {toReturn = null;}

      Thread.Sleep(150);
      return toReturn;
    }


    [TearDown]
    public void TeardownTest()
    {
      try
      {
        driver.Quit();
      }
      catch (Exception)
      {
        // Ignore errors if unable to close the browser
      }
      Assert.AreEqual("", verificationErrors.ToString());
    }
  }
}