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
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            try
            {
                driver.Navigate().GoToUrl("https://www.pipefy.com");
                driver.Manage().Window.Maximize();

                driver.FindElement(By.LinkText("Entrar")).Click();

                Thread.Sleep(2000);
                driver.FindElement(By.Name("username")).SendKeys("login");
                driver.FindElement(By.Name("password")).SendKeys("senbha");
                driver.FindElement(By.CssSelector(".auth0-label-submit > span")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.StackTrace);
                throw;
            }
            finally
            {
                Thread.Sleep(5000);
                driver.Close();
            }

            Console.WriteLine("finalizado");
        }
    }
}
