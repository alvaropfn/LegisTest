using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace LegisTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        public WebDriverWait wait;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        private void LimparMemoria () {
          string comando;
          comando = "tasklist | grep chromedriver";
          System.Diagnostics.Process.Start("CMD.exe", comando);

          comando = "taskkill /F /IM chromedriver.exe /T";
          System.Diagnostics.Process.Start("CMD.exe", comando);
        }

        [SetUp]
        public void SetupTest()
        {
          this.LimparMemoria();
            driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(Environment.CurrentDirectory));

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));

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

        public enum Selector {
            ID,
            CLASS,
            CSS,
            XPATH,
            LINK,
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

        public void Login(){
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
        
        [Test]
        public void TheUntitledTestCaseTest()
        {
            Login();
            
            //* go to module
            FindBy(Selector.LINK, "Módulo de controle de legislações do Legis").Click();
            FindBy(Selector.ID, "LegislacaoCadastro").Click();

            // wait loading
            this.awaitAlert();
            // Thread.Sleep(3000);

            //* Select Esfera
            FindBy(Selector.ID, "idEsferaGovernamental").Click();
            FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[1]").Click();

            //* Select Area Atuacao
            FindBy(Selector.ID, "select_idAreaAtuacao")?.Click();
            FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[2]/ng-select/ng-dropdown-panel/div/div[2]/div[1]")?.Click();

            //* Select Municipio
            FindBy(Selector.ID, "idCidade")?.Click();
            FindBy(Selector.XPATH, "/html/body/ng-dropdown-panel/div/div[2]/div[88]")?.Click();

            //* Select tipo norma
            FindBy(Selector.ID, "select_idTipoNorma")?.Click();
            FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[2]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[3]")?.Click();

            //* Select Ano
            IWebElement anoNorma = FindBy(Selector.ID, "anoNorma");
            if(anoNorma != null){
                anoNorma.Click();
                anoNorma.Clear();
                anoNorma.SendKeys("2019");
            }

            //* Select Numero
            IWebElement numeroNorma = FindBy(Selector.ID, "numeroNorma");
            if(numeroNorma != null){
                numeroNorma.Click();
                numeroNorma.Clear();
                numeroNorma.SendKeys("0123456789");
            }

            //* Select Meio Publicacao
            FindBy(Selector.ID, "select_idMeioPublicacao")?.Click();
            FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[3]/div[1]/ng-select/ng-dropdown-panel/div/div[2]/div[3]")?.Click();

            //* Select Data Publicacao
            IWebElement dataPublicacao = FindBy(Selector.ID, "dataPublicacao");
            dataPublicacao.Click();
            dataPublicacao.Clear();
            dataPublicacao.SendKeys("01/01/1950");

            //* Select Data Inicio Vigencia
            IWebElement dataInicioVigencia = FindBy(Selector.ID, "dataInicioVigencia");
            dataInicioVigencia.Click();
            dataInicioVigencia.Clear();
            dataInicioVigencia.SendKeys("01/01/2020");

            //* Select Data Fim Vigencia
            IWebElement dataFimVigencia = FindBy(Selector.ID, "dataFimVigencia");
            dataFimVigencia.Click();
            dataFimVigencia.Clear();
            dataFimVigencia.SendKeys("01/12/2020");

            //* Select pdf
            IWebElement anexo = FindBy(Selector.ID, "anexo");
            // anexo.Click();
            // anexo.Clear();
            anexo.SendKeys(@"C:/Users/alvaro/Documents/Flutter-Dev-Syllabus.pdf");

            //* Enviar
            FindBy(Selector.XPATH, "//*[@id='legislacaoCadastroForm']/div[8]/button")?.Click();

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
        private void awaitAlert() {
            
            Console.WriteLine("waiting");
            Thread.Sleep(2000);
            this.FindBy(Selector.XPATH, "body > div.swal2-container.swal2-center.swal2-backdrop-show > div");

            wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(5));
            Console.WriteLine("sucess");
        }

        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = this.driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
