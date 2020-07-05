// using System;
// using System.Text;
// using System.Text.RegularExpressions;
// using System.Threading;
// using NUnit.Framework;
// using OpenQA.Selenium;
// using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.Support.UI;
// using SeleniumExtras.WaitHelpers;

// namespace LegisTests
// {
//     [TestFixture]
//     public class CadastroAssuntoLegislacao
//     {
//         private IWebDriver driver;
//         public WebDriverWait wait;
//         private StringBuilder verificationErrors;
//         private bool acceptNextAlert = true;

//         private void LimparMemoria()
//         {
//             string comando;
//             comando = "tasklist | grep chromedriver";
//             System.Diagnostics.Process.Start("CMD.exe", comando);

//             comando = "taskkill /F /IM chromedriver.exe /T";
//             System.Diagnostics.Process.Start("CMD.exe", comando);
//         }

//         [SetUp]
//         public void SetupTest()
//         {
//             //this.LimparMemoria();
//             driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory));

//             driver.Manage().Window.Maximize();
//             driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//             this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));

//             verificationErrors = new StringBuilder();
//         }

//         [TearDown]
//         public void TeardownTest()
//         {
//             try
//             {
//                 driver.Quit();
//             }
//             catch (Exception)
//             {
//                 // Ignore errors if unable to close the browser
//             }
//             Assert.AreEqual("", verificationErrors.ToString());
//         }

//         public enum Selector
//         {
//             ID,
//             CLASS,
//             CSS,
//             XPATH,
//             LINK,
//         }

//         public IWebElement FindBy(Selector selector, string refs)
//         {
//             IWebElement toReturn;
//             try
//             {
//                 switch (selector)
//                 {
//                     case Selector.ID:
//                         toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.Id(refs)));
//                         break;
//                     case Selector.CLASS:
//                         toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.ClassName(refs)));
//                         break;
//                     case Selector.CSS:
//                         toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.CssSelector(refs)));
//                         break;
//                     case Selector.XPATH:
//                         // toReturn = wait.Until(ExpectedConditions.ElementExists(By.XPath(refs)));
//                         toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.XPath(refs)));
//                         break;
//                     case Selector.LINK:
//                         toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.LinkText(refs)));
//                         break;
//                     default:
//                         toReturn = null;
//                         break;
//                 }

//             }
//             catch (System.Exception)
//             { toReturn = null; }

//             Thread.Sleep(150);
//             return toReturn;
//         }

//         public void Login()
//         {
//             driver.Navigate().GoToUrl("http://localhost:4200/");

//             IWebElement username = FindBy(Selector.ID, "username");
//             username.Click();
//             username.Clear();
//             username.SendKeys("05510151447");

//             IWebElement password = FindBy(Selector.ID, "password");
//             password.Click();
//             password.Clear();
//             password.SendKeys("tce@123");

//             FindBy(Selector.XPATH, "(//input[@type='text'])[2]").Click();
//             FindBy(Selector.XPATH, "/html/body/app-root/tce-login/div/form/div[3]/ng-select/ng-dropdown-panel/div/div[2]/div[1]").Click();

//             FindBy(Selector.ID, "idEntrarLogin").Click();
//         }



//         [Test]
//         public void testeBemSucedido()
//         {
//           Login();

//           //* go to module
//           FindBy(Selector.LINK, "Módulo de administração do Legis").Click();
//           FindBy(Selector.ID, "AssuntoNorma").Click();

//           Thread.Sleep(1000);

//           FindBy(Selector.XPATH, "//div[@id='consulta']/a/i").Click();


//           IWebElement nomeAssuntoNorma = FindBy(Selector.ID, "nomeAssuntoNorma");
//           if(nomeAssuntoNorma != null){
//             nomeAssuntoNorma.Click();
//             nomeAssuntoNorma.Clear();
//             nomeAssuntoNorma.SendKeys("testando assunto norma");
//           }

//             FindBy(Selector.ID, "idButtonSalvar").Click();
//             Thread.Sleep(200);
//             Assert.AreEqual(FindBy(Selector.ID,"swal2-title").Text, "Sucesso");
//         }

        // [Test]
        // public void testeFalha()
        // {
        //   Login();

        //   //* go to module
        //   FindBy(Selector.LINK, "Módulo de administração do Legis").Click();
        //   FindBy(Selector.ID, "AssuntoNorma").Click();

        //   Thread.Sleep(1000);

        //   FindBy(Selector.XPATH, "//div[@id='consulta']/a/i").Click();

        //   string texto="";
        //   IWebElement nomeAssuntoNorma = FindBy(Selector.ID, "nomeAssuntoNorma");
        //   if(nomeAssuntoNorma != null){
        //       nomeAssuntoNorma.Click();
        //       nomeAssuntoNorma.Clear();
        //       nomeAssuntoNorma.SendKeys(texto);
        //   }

        //   FindBy(Selector.ID, "idButtonSalvar").Click();
        //   Thread.Sleep(200);
        //   Assert.AreEqual(FindBy(Selector.XPATH,"/html/body/app-root/app-dashboard/div/div/main/app-assunto-norma-form/tce-server-error-messages/div[1]/ul/li").Text,"Campo nome Assunto Norma obrigatório");
        // }



//         private bool IsElementPresent(By by)
//         {
//           try
//           {
//             driver.FindElement(by);
//             return true;
//           }
//           catch (NoSuchElementException)
//           {
//             return false;
//           }
//         }

//         private bool IsAlertPresent()
//         {
//             try
//             {
//                 this.driver.SwitchTo().Alert();
//                 return true;
//             }
//             catch (NoAlertPresentException)
//             {
//                 return false;
//             }
//         }

//         private string CloseAlertAndGetItsText()
//         {
//             try
//             {
//                 IAlert alert = this.driver.SwitchTo().Alert();
//                 string alertText = alert.Text;
//                 if (acceptNextAlert)
//                 {
//                     alert.Accept();
//                 }
//                 else
//                 {
//                     alert.Dismiss();
//                 }
//                 return alertText;
//             }
//             finally
//             {
//                 acceptNextAlert = true;
//             }
//         }
//     }
// }
