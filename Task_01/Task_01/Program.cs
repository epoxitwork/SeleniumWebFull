using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            driver.Manage().Window.Position = new Point(0, 0);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(10);
            driver.Navigate().GoToUrl("http://google.com");
            driver.Quit();
        }
    }
}
