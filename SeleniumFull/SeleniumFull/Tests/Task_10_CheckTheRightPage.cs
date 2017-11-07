using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_10
    {
        public IWebDriver driverFF;
        public IWebDriver driverIE;
        public IWebDriver driverCh;
        [Test]
        public void Task_10_CheckTheRightPage()
        {
            InitCh();
            try { Actions(driverCh); } 
            finally { Closure(driverCh);}
            InitIE();
            try { Actions(driverIE); }
            finally { Closure(driverIE); }            
            InitFF();
            try { Actions(driverFF); }
            finally { Closure(driverFF); }
        }
        #region Metods
        private void Actions(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(DB.baseURL + DB.userURL);
            Thread.Sleep(1000);
            var arrayNamesMainPage = driver.FindElements(By.XPath(DB.itemNameOnStartPage));
            var arrayLinksMainPage = driver.FindElements(By.XPath(DB.itemLinkOnStartPage));
            var textFromItems = GetTextFromItems(arrayNamesMainPage);
            var allLinks = GetAllLinksFromArray(arrayLinksMainPage);
            for (int j = 0; j < allLinks.Count; j++)
            {
                driver.Navigate().GoToUrl(DB.baseURL + allLinks[j]);
                Assert.IsTrue(ComparingNames(driver, textFromItems[j]));
            }
        }

        public void WaitForLoading(IWebDriver driver, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(DB.itemNameOnStartPage)));
        }
        public void WaitForLoading(IWebDriver driver, Llocator locator)
        {
            while (!IsElementPresent(driver, locator))
            {
                Thread.Sleep(50);
            }
        }
        public bool IsElementPresent(IWebDriver driver, Llocator locator)
        {
            try
            {
                By typeByAndValue = GetTypeByLocator(locator);
                driver.FindElement(typeByAndValue);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static By GetTypeByLocator(Llocator locator)
        {
            By typeByAndValue;
            switch (locator.Type)
            {
                case Locator.Name:
                    typeByAndValue = By.Name(locator.TargetText);
                    break;
                case Locator.LinkText:
                    typeByAndValue = By.LinkText(locator.TargetText);
                    break;
                case Locator.CssSelector:
                    typeByAndValue = By.CssSelector(locator.TargetText);
                    break;
                case Locator.XPath:
                    typeByAndValue = By.XPath(locator.TargetText);
                    break;
                case Locator.TagName:
                    typeByAndValue = By.XPath(locator.TargetText);
                    break;
                default:
                    throw new Exception(string.Format("Locator type #{0} not supported", locator.Type));
            }
            return typeByAndValue;
        }
        public List<string> GetTextFromItems(ReadOnlyCollection<IWebElement> arrayFromSite)
        {
            List<string> listFromSite = new List<string>();
            for (int j = 0; j < arrayFromSite.Count; j++)
            {
                if (arrayFromSite[j].Text != "")
                    listFromSite.Add(arrayFromSite[j].Text);
            }
            return listFromSite;
        }
        public List<string> GetAllLinksFromArray(ReadOnlyCollection<IWebElement> arrayFromSite)
        {
            List<string> links = new List<string>();
            for (int j = 0; j < arrayFromSite.Count; j++)
            {
                links.Add(arrayFromSite[j].GetAttribute(DB.attrHref).Substring(22));
            }
            return links;
        }
        public bool ComparingNames(IWebDriver driver, string textFromItems)
        {
            var gg = driver.FindElement(By.XPath(DB.itemNameOnItemPage)).Text;
            if (textFromItems == driver.FindElement(By.XPath(DB.itemNameOnItemPage)).Text)
                return true;
            return false;
        }
        #endregion
        #region InitAndQuit
        private void InitCh()
        {
            driverCh = new ChromeDriver();
            Settings(driverCh);
        }
        private void InitFF()
        {
            FirefoxOptions optionsFF = new FirefoxOptions();
            optionsFF.Profile = new FirefoxProfile(@"C:\Users\temp1\AppData\Roaming\Mozilla\Firefox\Profiles\bt366gsb.LastVersion");
            optionsFF.BrowserExecutableLocation = @"C:\Mozilla Firefox\firefox.exe";
            optionsFF.UseLegacyImplementation = false;
            driverFF = new FirefoxDriver(optionsFF);
            Settings(driverFF);
        }
        private void InitIE()
        {
            InternetExplorerOptions optionsIE = new InternetExplorerOptions();
            optionsIE.IgnoreZoomLevel = true;            
            optionsIE.RequireWindowFocus = true;
            driverIE = new InternetExplorerDriver(optionsIE);
            Settings(driverIE);
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
                driver.Close();
                driver.Quit();                
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
