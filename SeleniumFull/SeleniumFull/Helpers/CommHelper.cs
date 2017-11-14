using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
            //app.driver.FindElement(typeByAndValue).Clear();
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
        public List<string> GetAllTextFromElements(Llocator locator)
        {
            var allItems = GetAllElements(locator);
            List<string> itemsNames = new List<string>();
            for (int j = 0; j < allItems.Count; j++)
            {
                itemsNames.Add(allItems[j].Text);
            }
            return itemsNames;
        }
        public string GetTextFromElements(Llocator locator)
        {
            By typeByAndValue = GetTypeByLocator(locator);
            string text = "";
            try { text = app.driver.FindElement(typeByAndValue).Text; }
            catch (NoSuchElementException) { }
            return text;
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
                    typeByAndValue = By.TagName(locator.TargetText);
                    break;
                case Locator.Id:
                    typeByAndValue = By.Id(locator.TargetText);
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
        public void Output(List<string> result, string filename, bool NoOverWrite)
        {
            StreamWriter writer = new StreamWriter(filename, NoOverWrite);
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
        public string GenerateRandomString(int length, int type)
        {
            if (type == 99)
                return Path.GetRandomFileName().Substring(0, length);
            else
            {
                var rng = RandomNumberGenerator.Create();
                var gg = RandomGenerator(rng, length, type);
                return gg;
            }
            //Внутри себя метод Path.GetRandomFileName() получает случайные байты из «криптографически правильного» генератора случайных чисел RNGCryptoServiceProvider. 
            //А потом он использует побитовые И чтобы заполнить StringBuilder символами основанными на этих байтах.
        }
        public static string RandomGenerator(RandomNumberGenerator rng, int length, int type)
        {
            string validAllChars = "qwertyuiopasdfghjklzxcvbnm1234567890-=~!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL:|ZXCVBNM<>?йцукенгшщзхъфывапролджэячсмитьбю.ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            string validEnChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            string validRuChars = "йцукенгшщзхъфывапролджэячсмитьбюЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮ";
            string validNum = "1234567890";
            string[] validChars = new string[4];
            validChars[0] = validAllChars;
            validChars[1] = validEnChars;
            validChars[2] = validRuChars;
            validChars[3] = validNum;
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                byte[] bytes = new byte[1];
                rng.GetBytes(bytes);
                Random rnd = new Random(bytes[0]);
                chars[i] = validChars[type][rnd.Next(0, validChars[type].Length - 1)];
            }
            return (new string(chars));
        }

        public int SimpleRnd(int min, int max)
        {
            Random rand = new Random();
            int output = rand.Next(min, max);
            return output;
        }
        public bool IsElementChanged(Llocator locator, string oldValue)
        {
            By typeByAndValue = GetTypeByLocator(locator);
            string newValue = app.driver.FindElement(typeByAndValue).Text;
            if (newValue != oldValue)
                return true;
            else return false;            
        }

        internal void SelectElement(Llocator locator1, Llocator locator2)
        {
            By typeByAndValue = GetTypeByLocator(locator1);
            var element = driver.FindElement(typeByAndValue);
            var allitems = GetAllTextFromElements(locator2);
            new SelectElement(element).SelectByText(allitems[1]);
        }

        internal void Wait(Llocator locator)
        {
            By typeByAndValue = GetTypeByLocator(locator);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(typeByAndValue));
        }
    }
}
