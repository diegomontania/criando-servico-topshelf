using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PipefyTest
{
    //http://www.macoratti.net/18/05/c_servtop1.htm
    //https://github.com/nlog/nlog/wiki/Tutorial
    //http://www.macoratti.net/20/11/aspc_nlog1.htm

    public class MeuServicoWS
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private IWebDriver _driver = new ChromeDriver();

        //start e stop de serviço
        public void Start() 
        {
            _logger.Info("Iniciando o serviço");

            try
            {
                _logger.Info("Processo inicializado");
                _logger.Info("Abrindo ChromeDriver");

                _driver.Navigate().GoToUrl("https://www.pipefy.com");
                _driver.Manage().Window.Maximize();

                AbreNovaAba();

                _driver.FindElement(By.LinkText("Entrar")).Click();

                Thread.Sleep(2000);
                _driver.FindElement(By.Name("username")).SendKeys("login");
                _driver.FindElement(By.Name("password")).SendKeys("senbha");
                _driver.FindElement(By.CssSelector(".auth0-label-submit > span")).Click();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message, ex.StackTrace);
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
            }
            finally
            {
                Thread.Sleep(5000);
                _driver.Quit();
                _logger.Info("ChromeDriver fechando sucesso");
            }

            //Console.WriteLine("finalizado");
            _logger.Info("Processo finalizado com sucesso");
        }

        public void Stop()
        {
            _driver.Quit();
            _logger.Info("Parando serviço");
        }

        //https://stackoverflow.com/a/41587598/13156642
        private void AbreNovaAba()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.open();");
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
            _driver.Navigate().GoToUrl("http://www.google.com");
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }
    }
}
