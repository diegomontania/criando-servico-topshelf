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
    public class MeuServicoWS
    {
        IWebDriver _driver = new ChromeDriver();

        //start e stop de serviço
        public void Start() 
        {
            try
            {
                _driver.Navigate().GoToUrl("https://www.pipefy.com");
                _driver.Manage().Window.Maximize();

                _driver.FindElement(By.LinkText("Entrar")).Click();

                Thread.Sleep(2000);
                _driver.FindElement(By.Name("username")).SendKeys("login");
                _driver.FindElement(By.Name("password")).SendKeys("senbha");
                _driver.FindElement(By.CssSelector(".auth0-label-submit > span")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
            }
            finally
            {
                Thread.Sleep(5000);
                _driver.Close();
            }

            Console.WriteLine("finalizado");
        }

        public void Stop() 
        {
            _driver.Close();
        }
    }
}
