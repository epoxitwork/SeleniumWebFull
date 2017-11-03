using System;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;


namespace SeleniumFull
{
    public class AdminMetods : HelperBase
    {
        public AdminMetods(AppManager app)
            : base(app)
        {
        }
        public string Login()
        {
            app.Cmhelp.WaitForLoading(DB.Username);
            app.Cmhelp.SendKeysToField(DB.Username, DB.credential);
            app.Cmhelp.SendKeysToField(DB.Password, DB.credential);
            try
            {
                app.Cmhelp.ClickButton(DB.BtnLogin);
            }
            catch (WebDriverException)//(Exception)
            {
                Thread.Sleep(100);
            }
            app.Cmhelp.WaitForLoading(DB.TxtLogout);
            return app.Cmhelp.GetAttributeFromField(DB.TxtLogout, DB.attrTitle);
        }
        public List<string> ClickLeftMenu()
        {
            ReadOnlyCollection<IWebElement> allElements1lvl;
            ReadOnlyCollection<IWebElement> allElements2lvl;
            List<string> h1NoExist = new List<string>();
            string btnText;
            string h1;            
            allElements1lvl = app.Cmhelp.GetAllElements(DB.AdminMenu1lvl);
            for (int i = 0; i < allElements1lvl.Count; i++)
            {
                Checking(allElements1lvl[i], h1NoExist, out btnText, out h1, "lvl1. ");
                allElements2lvl = app.Cmhelp.GetAllElements(DB.AdminMenu2lvl);
                for (int j = 0; j < allElements2lvl.Count; j++)
                {
                    Checking(allElements2lvl[j], h1NoExist, out btnText, out h1, "lvl2. ");
                    allElements2lvl = app.Cmhelp.GetAllElements(DB.AdminMenu2lvl);
                    Thread.Sleep(100);
                }
                allElements1lvl = app.Cmhelp.GetAllElements(DB.AdminMenu1lvl);
                Thread.Sleep(100);
            }
            return h1NoExist;
        }
        public void Checking(IWebElement allElements1lvl, List<string> h1NoExist, out string btnText, out string h1, string lvl)
        {
            string result = "";
            btnText = allElements1lvl.Text;
            allElements1lvl.Click();
            h1 = driver.FindElement(By.XPath(DB.h1)).Text;
            if (btnText != h1)
            {
                if (h1 == "null") result = lvl + "btnText:'" + btnText + "'; h1 = null";
                else result = lvl + "btnText:'" + btnText + "' != h1:" + h1 + "'";
            }
            else result = lvl + "btnText:'" + btnText + "' == h1:'" + h1 + "'";
            h1NoExist.Add(result);
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
        public bool CheckingSorting(List<string> listFromSite)
        {
            List<string> sortedlist = listFromSite;
            sortedlist.Sort();
            var asd = sortedlist.Equals(listFromSite);
            return sortedlist.Equals(listFromSite);
        }
        public List<string> GetGeoLinkFromSite(ReadOnlyCollection<IWebElement> arrayFromSite)
        {
            var arrayGeozones = app.Cmhelp.GetAllElements(DB.GeozoneNum);
            List<string> linksCountryWithGeozones = new List<string>();
            for (int j = 0; j < arrayFromSite.Count; j++)
            {                
                if (arrayGeozones[j].Text != "0")
                    linksCountryWithGeozones.Add(arrayFromSite[j].GetAttribute("href").Substring(22));
            }
            return linksCountryWithGeozones;
        }
    }
}
