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
using OpenQA.Selenium.Interactions;

namespace LegisTests
{
    [TestFixture]
    public class ListarLegislacaoTest
    {


        private IWebDriver driver;
        private StringBuilder verificationErrors;

        public WebDriverWait wait;
        private string baseURL;
        private bool acceptNextAlert = true;

        private void LimparMemoria()
        {
            string comando;
            comando = "tasklist | grep chromedriver";
            System.Diagnostics.Process.Start("CMD.exe", comando);

            comando = "taskkill /F /IM chromedriver.exe /T";
            System.Diagnostics.Process.Start("CMD.exe", comando);
        }

        [SetUp]
        public void SetupTest()
        {
            //this.LimparMemoria();
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory));

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));

            verificationErrors = new StringBuilder();
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

        public enum Selector
        {
            ID,
            CLASS,
            CSS,
            XPATH,
            LINK,
        }

        public IWebElement FindBy(Selector selector, string refs)
        {
            IWebElement toReturn;
            try
            {
                switch (selector)
                {
                    case Selector.ID:
                        toReturn = this.wait.Until(ExpectedConditions.ElementExists(By.Id(refs)));
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
            { toReturn = null; }

            Thread.Sleep(150);
            return toReturn;
        }

        public void Login()
        {
            driver.Navigate().GoToUrl("http://localhost:4200/");

            IWebElement username = FindBy(Selector.ID, "username");
            username.Click();
            username.Clear();
            username.SendKeys("05510151447");

            IWebElement password = FindBy(Selector.ID, "password");
            password.Click();
            password.Clear();
            password.SendKeys("tce@123");

            FindBy(Selector.XPATH, "(//input[@type='text'])[2]").Click();
            FindBy(Selector.XPATH, "/html/body/app-root/tce-login/div/form/div[3]/ng-select/ng-dropdown-panel/div/div[2]/div[1]").Click();

            FindBy(Selector.ID, "idEntrarLogin").Click();
        }

        // [Test]
        // public void testeBuscaOrgaoCadastranteDataInicioVigencia()
        // {
        //     Login();

        //     //* go to module
        //     FindBy(Selector.LINK, "Módulo de controle de legislações do Legis").Click();
        //     FindBy(Selector.ID, "LegislacaoConsulta").Click();
        //     Thread.Sleep(16000);

        //     //select Numero Norma
        //     IWebElement numeroNorma = FindBy(Selector.ID, "numeroNorma");
        //     numeroNorma.Click();
        //     numeroNorma.Clear();
        //     numeroNorma.SendKeys("123456789");

        //     //select orgao cadastrante
        //     FindBy(Selector.ID, "select_idOrgaoCadastrante").Click();
        //     FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-consulta/div[1]/div[2]/div/form/div[1]/div[8]/ng-select/ng-dropdown-panel/div/div[2]/div[345]").Click();


        //     //enviar
        //     FindBy(Selector.XPATH,"//div[@id='collapseTwo']/div/form/div[2]/button").Click();
        //     Thread.Sleep(5000);

        //     //validar 

        // }

        [Test]
        public void testeBuscaNormasAnoEsfera()
        {
            Login();

            //* go to module
            FindBy(Selector.LINK, "Módulo de controle de legislações do Legis").Click();
            FindBy(Selector.ID, "LegislacaoConsulta").Click();
            Thread.Sleep(16000);

            //select ano
            IWebElement anoNorma = FindBy(Selector.ID, "anoNorma");
            anoNorma.Click();
            anoNorma.Clear();
            anoNorma.SendKeys("2019");

            //select esferaGovernamental
            FindBy(Selector.ID, "idEsferaGovernamental").Click();
            FindBy(Selector.XPATH, "/html/body/ng-dropdown-panel/div/div[2]/div[1]").Click();

            //enviar
            FindBy(Selector.XPATH,"//div[@id='collapseTwo']/div/form/div[2]/button").Click();
            Thread.Sleep(5000);

            //excluir
            FindBy(Selector.ID,"legislacao-excluir-1").Click();
            

            FindBy(Selector.XPATH,"/html/body/div[2]/div/div[3]/button[1]").Click();
            Thread.Sleep(400);    
            Assert.AreEqual(FindBy(Selector.ID,"swal2-title").Text, "Sucesso");

        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}