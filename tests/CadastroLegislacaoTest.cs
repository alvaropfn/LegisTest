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

        public enum Selector {
            ID,
            CLASS,
            CSS,
            XPATH,
            LINK,
        }

        public IWebElement FindBy(Selector selector, string refs){
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
            {toReturn = null;}

            Thread.Sleep(150);
            return toReturn;
        }

        public void Login(){
            driver.Navigate().GoToUrl("http://legisint.tce.govrn/#/login");

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
        
        [Test]
        public void TheUntitledTestCaseTest()
        {
            Login();
            
            //* go to module
            FindBy(Selector.LINK, "Módulo de controle de legislações do Legis").Click();
            FindBy(Selector.ID, "LegislacaoCadastro").Click();

            
            //* Select tipo norma
            IWebElement tipoNorma =  FindBy(Selector.XPATH, "//*[@id='select_idTipoNorma']/div/div/div[2]/input");
            tipoNorma.SendKeys("Decreto");
            tipoNorma.SendKeys(OpenQA.Selenium.Keys.Return);

            //* Select Ano
            IWebElement anoNorma = FindBy(Selector.ID, "anoNorma");
            if(anoNorma != null){
                anoNorma.Clear();
            }
            anoNorma.SendKeys("2019");
            
            //* Select Numero
            IWebElement numeroNorma = FindBy(Selector.ID, "numeroNorma");
            if(numeroNorma != null){
                numeroNorma.Clear();
            }
            numeroNorma.SendKeys("0123456789");

            //* Select Meio Publicacao
            IWebElement meioPublicacao = FindBy(Selector.XPATH, "//*[@id='select_idMeioPublicacao']/div/div/div[2]/input");
            meioPublicacao.SendKeys("Diário Oficial da União");
            meioPublicacao.SendKeys(OpenQA.Selenium.Keys.Return);

            //* Select Data Publicacao
            IWebElement dataPublicacao = FindBy(Selector.ID, "dataPublicacao");
            dataPublicacao.SendKeys("01/01/1950");

            //* Select Assunto Norma
            IWebElement assuntoNorma =  FindBy(Selector.XPATH, "//*[@id='idAssuntoNorma']/div/div/div[2]/input");
            assuntoNorma.SendKeys("Plano de Cargos, Carreiras e Remuneração");
            assuntoNorma.SendKeys(OpenQA.Selenium.Keys.Return);

            //* Botao Acao
            IWebElement addAcao = FindBy(Selector.ID, "acao");
            addAcao.Click();
            
            //* Select pdf
            IWebElement anexo = FindBy(Selector.ID, "anexo");
            string pdfFile = Directory.GetCurrentDirectory() + "//teste.pdf";
            anexo.SendKeys(pdfFile);
            Thread.Sleep(2000);
            // anexo.Click();
            // anexo.Clear();
//            anexo.SendKeys(@"C:/Users/alvaro/Documents/Flutter-Dev-Syllabus.pdf");
/*
            //* Select Area Atuacao
            FindBy(Selector.ID, "select_idAreaAtuacao").Click();
            FindBy(Selector.XPATH, "/html/body/app-root/app-dashboard/div/div/main/app-legislacao-cadastro/div/fieldset/form/div[1]/div[2]/ng-select/ng-dropdown-panel/div/div[2]/div[1]").Click();

            //* Select Municipio
            FindBy(Selector.ID, "idCidade").Click();
            FindBy(Selector.XPATH, "/html/body/ng-dropdown-panel/div/div[2]/div[88]").Click();

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
*/ 

            //* Enviar
            FindBy(Selector.XPATH, "//*[@id='legislacaoCadastroForm']/div[7]/button").Click();
            Assert.AreEqual(FindBy(Selector.CLASS,"swal2-title").Text, "Sucesso");
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
                this.driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
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
