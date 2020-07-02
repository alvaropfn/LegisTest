using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

// namespace LegisTests
// {
//      [TestFixture]
//     public class UntitledTestCase
//     {
//         private IWebDriver driver;
//         private StringBuilder verificationErrors;
//         private string baseURL;
//         private bool acceptNextAlert = true;
        
//         [SetUp]
//         public void SetupTest()
//         {
//             this.LimparMemoria();
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

//         [Test]
//         public void TheUntitledTestCaseTest()
//         {
//             driver.Navigate().GoToUrl("http://localhost:4200/#/dashboard/legislacaoconsulta");
//             driver.FindElement(By.XPath("(//a[contains(text(),'Módulo de controle de legislações do Legis')])[2]")).Click();
//             driver.FindElement(By.XPath("(//a[contains(text(),'Consultar Legislação')])[2]")).Click();
//             driver.FindElement(By.XPath("(//input[@type='text'])[5]")).Click();
//             driver.FindElement(By.XPath("//div[@id='a15b7dbf955f-62']/span")).Click();
//             driver.FindElement(By.XPath("//div[@id='collapseTwo']/div/form/div[2]/button")).Click();
//         }
//         private bool IsElementPresent(By by)
//         {
//             try
//             {
//                 driver.FindElement(by);
//                 return true;
//             }
//             catch (NoSuchElementException)
//             {
//                 return false;
//             }
//         }
        
//         private bool IsAlertPresent()
//         {
//             try
//             {
//                 driver.SwitchTo().Alert();
//                 return true;
//             }
//             catch (NoAlertPresentException)
//             {
//                 return false;
//             }
//         }
        
//         private string CloseAlertAndGetItsText() {
//             try {
//                 IAlert alert = driver.SwitchTo().Alert();
//                 string alertText = alert.Text;
//                 if (acceptNextAlert) {
//                     alert.Accept();
//                 } else {
//                     alert.Dismiss();
//                 }
//                 return alertText;
//             } finally {
//                 acceptNextAlert = true;
//             }
//         }
//     }
// }