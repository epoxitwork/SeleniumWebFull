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
            try 
            { 
                CheckingText(driverCh); 
            } 
            finally { Closure(driverCh);}
            InitFF();
            try 
            { 
                CheckingText(driverFF); 
            }
            finally { Closure(driverFF); }
            InitIE();
            try
            {
                CheckingText(driverIE);
            }
            finally { Closure(driverIE); }
        }
        #region Metods
        private void CheckingText(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(DB.baseURL + DB.userURL);
            Thread.Sleep(1000);
            string NameMainPage = driver.FindElement(By.XPath(DB.itemNameOnStartPage)).Text;
            string firstItemLink = driver.FindElement(By.XPath(DB.itemLinkOnStartPage)).GetAttribute(DB.attrHref).Substring(22);
            var itemBase = driver.FindElement(By.XPath(DB.mainItemLocator));
            string RegularCostMainPage = itemBase.FindElement(By.XPath(DB.itemRegularPrice)).Text;
            string CmpCostMainPage = itemBase.FindElement(By.XPath(DB.itemCampaignPrice)).Text;

            CompareTextSize(itemBase);
            CompareColor(itemBase);
            CompareStyle(itemBase);

            driver.Navigate().GoToUrl(DB.baseURL + firstItemLink);
            Thread.Sleep(1000);
            var itemBase2 = driver.FindElement(By.XPath(DB.mainItemLocator2));
            Assert.IsTrue(ComparingNames(driver, NameMainPage));

            CompareTextSize(itemBase2);
            CompareColor(itemBase2);
            CompareStyle(itemBase2);

            CompareCost(RegularCostMainPage, CmpCostMainPage, itemBase2);
        }
        private static void CompareCost(string RegularCostMainPage, string CmpCostMainPage, IWebElement itemBase2)
        {
            var one = itemBase2.FindElement(By.XPath(DB.itemCampaignPrice)).Text;
            var two = itemBase2.FindElement(By.XPath(DB.itemRegularPrice)).Text;
            Assert.AreEqual(one, CmpCostMainPage);
            Assert.AreEqual(two, RegularCostMainPage);
        }
        private void CompareStyle(IWebElement itemBase)
        {
            var one = GetCss(itemBase, DB.ItemRegularPrice, "text-decoration");
            var two = GetCss(itemBase, DB.ItemCampaignPrice, "font-weight");
            Assert.IsTrue(one.Contains("line-through"));
            Assert.Less(400, Convert.ToDouble(two));//если больше 400, то bold
        }
        private void CompareColor(IWebElement element)
        {
            var one = GetColor(GetCss(element, DB.ItemRegularPrice, "color"));
            var two = GetColor(GetCss(element, DB.ItemCampaignPrice, "color"));
            Assert.AreEqual(one, "gray");
            Assert.AreEqual(two, "red");
        }
        private void CompareTextSize(IWebElement element)
        {
            double regularSize = GetTextSize(GetCss(element, DB.ItemRegularPrice, "font-size"));
            double campaignSize = GetTextSize(GetCss(element, DB.ItemCampaignPrice, "font-size"));
            Assert.Less(regularSize, campaignSize);
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
        public string GetColor(string css)
        {
            string[] nums = css.Split(new Char[] { ',', ')', '(', ' ' });
            string[] colorsRGB = new string[3];
            int j = 0;
            int lenght =0;
            if (nums[0]=="rgb")
                lenght = nums.Length-1;
            else lenght = nums.Length-3;
            for (int i = 1; i < lenght; i++ )
            {
                string ggg = nums[i];
                if (nums[i] != "")
                {
                    colorsRGB[j] = nums[i];
                    j++;
                }
            }
            if (colorsRGB[0] == colorsRGB[1] && colorsRGB[0] == colorsRGB[2])
                return "gray";
            else if (colorsRGB[1] == "0" && colorsRGB[2] == "0")
                return "red";
            return "ColorIsUnknown";
        }
        public double GetTextSize(string size)
        {
            double sizee = 0;
            double sizeAfterPoint = 0;
            string[] text = size.Split(new Char[] { '.'});
            if (text.Length > 1)
            {
                sizee = Convert.ToDouble(text[0]);
                sizeAfterPoint = Convert.ToDouble(text[1].Substring(0, text[1].Length-2));
                sizee = sizee + sizeAfterPoint / 10;
            }
            else
                sizee = Convert.ToDouble(text[0].Substring(0, text[0].Length - 2));

            return sizee;
        }
        public string GetCss(IWebElement element, Llocator locator, string css)
        {
            By typeByAndValue = GetTypeByLocator(locator);
            var cssValue = element.FindElement(typeByAndValue).GetCssValue(css);
            return cssValue;
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
