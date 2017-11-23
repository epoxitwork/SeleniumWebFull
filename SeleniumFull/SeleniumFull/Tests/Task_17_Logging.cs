using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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
    public class Task_17 : AdminBase
    {
        [Test]
        public void Task_17_Logging()
        {
            //List<string> logs = new List<string>();
            ReadOnlyCollection<IWebElement> allGoods;
            int j = 0;
            do
            {
                allGoods = NewMethod();
                allGoods[j].Click();
                var ert = app.driver.Manage().Logs.GetLog("browser");
                var ertt = app.driver.Manage().Logs.GetLog("driver");
                foreach (LogEntry l in app.driver.Manage().Logs.GetLog("browser"))
                {
                    string gg = l.Message;
                    //logs.Add(l.Message);
                    throw new Exception(string.Format("В логе появилось сообщение: {0}", gg));
                }
                j++;
            }
            while (j < allGoods.Count);
            /*
            var allGoodss = NewMethod();
            for (int i = 0; i < allGoodss.Count; i++ )
            {
                allGoodss[i].Click();
                var ert = app.driver.Manage().Logs.GetLog("browser");
                var ertt = app.driver.Manage().Logs.GetLog("driver");
                foreach (LogEntry l in app.driver.Manage().Logs.GetLog("browser"))
                {
                    string gg = l.Message;
                    //logs.Add(l.Message);
                    throw new Exception(string.Format("В логе появилось сообщение: {0}", gg));
                }
                allGoodss = NewMethod();
            }*/
        }
        private ReadOnlyCollection<IWebElement> NewMethod()
        {
            app.Cmhelp.ClickButton(DB.MenuCatalog);
            app.AdminMetods.OpenAllCategoriesInCatalog();
            var allGoods = app.Cmhelp.GetAllElements(DB.AllGoods);
            return allGoods;
        }
    }
}
