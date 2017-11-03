using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class CommHelper : HelperBase
    {
        public CommHelper(AppManager app)
            : base(app)
        {
        }
        public void SendKeysToField(Llocator locator, string value)
        {
            By typeByAndValue = GetTypeByLocator(locator);
            app.driver.FindElement(typeByAndValue).Clear();
            app.driver.FindElement(typeByAndValue).SendKeys(value);
        }
        public void ClickButton(Llocator locator)
        {
            WaitForLoading(locator);
            By typeByAndValue = GetTypeByLocator(locator);
            app.driver.FindElement(typeByAndValue).Click();
        }
        public string GetAttributeFromField(Llocator locator, string value)
        {
            By typeByAndValue = GetTypeByLocator(locator);
            return app.driver.FindElement(typeByAndValue).GetAttribute(value);
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
        public void WaitForLoading(Llocator locator)
        {
            while (!IsElementPresent(locator))
            {
                Thread.Sleep(50);
            }
        }
        public bool IsElementPresent(Llocator locator)
        {
            try
            {
                By typeByAndValue = GetTypeByLocator(locator);
                app.driver.FindElement(typeByAndValue);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public ReadOnlyCollection<IWebElement> GetAllElements(Llocator locator)
        {
            By typeByAndValue = GetTypeByLocator(locator);
            var tmp = app.driver.FindElements(typeByAndValue);
            return app.driver.FindElements(typeByAndValue);
        }
        public void Output(List<string> result, string filename)
        {
            StreamWriter writer = new StreamWriter(filename, false);
            for (int j = 0; j < result.Count; j++)
            {
                writer.WriteLine(result[j]);
            }
            writer.Close();
        }
        public void OpenTargetPage(string targetUrl)
        {
            app.driver.Navigate().GoToUrl(DB.baseURL + targetUrl);
        }
    }
}
