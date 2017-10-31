using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
//using System.Collections.Generic;

namespace SeleniumFull
{
    public class AdminMetods : HelperBase
    {
        public AdminMetods(AppManager app)
            : base(app)
        {
        }
        public void OpenAdminPage()
        {
            app.driver.Navigate().GoToUrl(AllLoc.baseURL + AllLoc.adminUrl);
        }
        public string Login()
        {
            app.Cmhelp.WaitForLoading(AllLoc.Username);
            app.Cmhelp.SendKeysToField(AllLoc.Username, AllLoc.credential);
            app.Cmhelp.SendKeysToField(AllLoc.Password, AllLoc.credential);
            try
            {
                app.Cmhelp.ClickButton(AllLoc.BtnLogin);
            }
            catch (Exception)
            {
                Thread.Sleep(100);
            }
            app.Cmhelp.WaitForLoading(AllLoc.TxtLogout);
            return app.Cmhelp.GetAttributeFromField(AllLoc.TxtLogout, AllLoc.attrTitle);
        }
        public List<string> ClickLeftMenu()
        {
            ReadOnlyCollection<IWebElement> allElements1lvl;
            ReadOnlyCollection<IWebElement> allElements2lvl;
            List<string> h1NoExist = new List<string>();
            string btnText;
            string hh1;            
            allElements1lvl = app.Cmhelp.GetAllElements(AllLoc.AdminMenu1lvl);
            for (int i = 0; i < allElements1lvl.Count; i++)
            {
                Checking(allElements1lvl[i], h1NoExist, out btnText, out hh1, "lvl1. ");
                allElements2lvl = app.Cmhelp.GetAllElements(AllLoc.AdminMenu2lvl);
                for (int j = 0; j < allElements2lvl.Count; j++)
                {
                    Checking(allElements2lvl[j], h1NoExist, out btnText, out hh1, "lvl2. ");
                    allElements2lvl = app.Cmhelp.GetAllElements(AllLoc.AdminMenu2lvl);
                    Thread.Sleep(500);
                }
                allElements1lvl = app.Cmhelp.GetAllElements(AllLoc.AdminMenu1lvl);
                Thread.Sleep(500);
            }
            return h1NoExist;
        }
        private void Checking(IWebElement allElements1lvl, List<string> h1NoExist, out string btnText, out string hh1, string lvl)
        {
            string result = "";
            btnText = allElements1lvl.Text;
            allElements1lvl.Click();
            hh1 = driver.FindElement(By.XPath(AllLoc.h1)).Text;
            if (btnText != hh1)
            {
                if (hh1 == "null") result = lvl + "btnText:'" + btnText + "'; h1 = null";
                else result = lvl + "btnText:'" + btnText + "' != h1:" + hh1 + "'";
            }
            else result = lvl + "btnText:'" + btnText + "' == h1:'" + hh1 + "'";
            h1NoExist.Add(result);
        }

        public void Output(List<string> result)
        {
            StreamWriter writer = new StreamWriter("Task_07_Report.txt", false);
            for (int j = 0; j < result.Count; j++)
            {
                writer.WriteLine(result[j]);
            }
            writer.Close();
        }
    }
}
