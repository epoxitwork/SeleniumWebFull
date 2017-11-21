using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_15
    {
        public string urlHUB = "http://10.10.139.169:4444/wd/hub";
        public string ffPath = @"C:\ForRemote\Mozilla Firefox\firefox.exe";
        public string browserName = "browserName";
        [Test]
        public void Task_15_RemoteSelenium()
        {/*
            IWebDriver driverIE = InitIE();
            GoToUrl(driverIE);
            Closure(driverIE);*/
            IWebDriver driverCh = InitCh();
            GoToUrl(driverCh);
            Closure(driverCh);
            IWebDriver driverFF = InitFF();
            GoToUrl(driverFF);
            Closure(driverFF);
        }

        private void GoToUrl(IWebDriver driver)
        {
 	        driver.Navigate().GoToUrl(DB.baseURL + DB.userURL);
        }
        private IWebDriver InitCh()
        {
            //DesiredCapabilities capability = DesiredCapabilities.Chrome();
            //capability.SetCapability(browserName, "chrome");
            ChromeOptions optCh = new ChromeOptions();
            optCh.AddAdditionalCapability(browserName, "chrome", true);
            //optCh.ToCapabilities();
            IWebDriver driverCh = new RemoteWebDriver(new Uri(urlHUB), optCh);
            Settings(driverCh);
            return driverCh;
        }
        private IWebDriver InitFF()
        {
            DesiredCapabilities capability = DesiredCapabilities.Firefox();
            capability.SetCapability(browserName, "firefox");
            FirefoxOptions optFF = new FirefoxOptions();
            //optFF.AddAdditionalCapability(browserName, "firefox", true);
            optFF.BrowserExecutableLocation = ffPath;
            optFF.UseLegacyImplementation = false;
            optFF.ToCapabilities();
            IWebDriver driverFF = new RemoteWebDriver(new Uri(urlHUB), optFF);
            Settings(driverFF);
            return driverFF;
        }
        private IWebDriver InitIE()
        {
            DesiredCapabilities capability = DesiredCapabilities.Firefox();
            capability.SetCapability(browserName, "internet explorer");
            InternetExplorerOptions optIE = new InternetExplorerOptions();
            optIE.IgnoreZoomLevel = true;
            optIE.RequireWindowFocus = true;
            optIE.ToCapabilities();
            //optIE.AddAdditionalCapability(browserName, "internet explorer", true);
            IWebDriver driverIE = new RemoteWebDriver(new Uri(urlHUB), optIE);
            Settings(driverIE);
            return driverIE;
        }
        private void Settings(IWebDriver driver)
        {
            driver.Manage().Window.Size = new Size(1180, 1000);
            var timeout = new TimeSpan(0, 2, 0);
            driver.Manage().Window.Position = new Point(0, 30);
            driver.Manage().Timeouts().ImplicitWait = timeout;
            driver.Manage().Timeouts().PageLoad = timeout;
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(10);
        }
        private void Closure(IWebDriver driver)
        {
            try
            {
                //driver.Close();
                driver.Quit();
            }
            catch (Exception)
            {
            }
        }
    }
}
