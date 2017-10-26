using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using OpenQA.Selenium;

namespace Task_03
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*.
            Компоненты ставил через консоль так:
            Install-Package NUnit -Version 2.6.4
            Install-Package Selenium.WebDriver
            Install-Package Selenium.Support
            */
            IWebDriver driver;
            driver = new ChromeDriver();
            try
            {
                driver.Manage().Window.Position = new Point(0, 0);
                driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 2, 0);
                driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 2, 0);
                //driver.Manage().Timeouts().SetPageLoadTimeout = new TimeSpan(0, 2, 0);
                driver.Navigate().GoToUrl("http://localhost:8080/litecart/admin/login.php");
                string locUserName = "//input[@name='username']";
                string locPassword = "//input[@name='password']";
                string txtCredential = "admin";
                //string locLoginBtn = "//button";
                WaitForLoading(driver, locUserName);
                driver.FindElement(By.XPath(locUserName)).SendKeys(txtCredential);
                driver.FindElement(By.XPath(locPassword)).SendKeys(txtCredential);
                try
                {
                    driver.FindElement(By.XPath(locPassword)).SendKeys(Keys.Enter);
                }
                catch (Exception)
                {

                }
                Thread.Sleep(5000);
                driver.Navigate().GoToUrl("http://localhost:8080/litecart/admin/?app=appearance&doc=template");
                
                //driver.FindElement(By.XPath(locLoginBtn)).Click();
            }
            finally
            {
                driver.Quit();
            }
        }
        private static void WaitForLoading(IWebDriver driver, string target)
        {
            while (!IsElementPresent(driver, target))
            {
                Thread.Sleep(50);
            }
        }

        private static bool IsElementPresent(IWebDriver driver, string target)
        {
            try
            {
                driver.FindElement(By.XPath(target));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
