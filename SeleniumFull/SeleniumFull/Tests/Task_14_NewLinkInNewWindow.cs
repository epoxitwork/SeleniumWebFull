using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_14 : AdminBase
    {
        [Test]
        public void Task_14_NewLinkInNewWindow()
        {            
            app.Cmhelp.OpenTargetPage(DB.countryUrl);            
            if (app.Cmhelp.SimpleRnd(1, 2) == 1)
            {
                Edit();
            }
            else            
            {
                New();
            }
            Checking();
        }

        private void Checking()
        {
            var all = app.Cmhelp.GetAllElements(DB.ExternalLink);
            var allWindows = app.driver.WindowHandles;
            var newAllWindows = allWindows;
            string mainWindow = allWindows[0];
            for (int i = 0; i<all.Count; i++)
            {
                all[i].Click();
                do
                {
                    newAllWindows = app.driver.WindowHandles;
                }
                while (allWindows.Count == newAllWindows.Count);
                string newWindow = newAllWindows.Last();
                Assert.AreNotEqual(mainWindow, newWindow);
                app.driver.SwitchTo().Window(newWindow);
                var temp = app.driver.FindElements(By.TagName("body"));
                app.driver.Close();
                app.driver.SwitchTo().Window(mainWindow);
                all = app.Cmhelp.GetAllElements(DB.ExternalLink);
            }
        }
        private string GetWindowHandle(int num)
        {
            var AllWindows = app.driver.WindowHandles;
            return AllWindows[num];
        }
        private void New()
        {
            app.Cmhelp.ClickButton(DB.NewCountry);
        }
        private void Edit()
        {
            var all = app.Cmhelp.GetAllElements(DB.EditPencil);
            all[app.Cmhelp.SimpleRnd(0, all.Count)].Click();
        }
    }
}
