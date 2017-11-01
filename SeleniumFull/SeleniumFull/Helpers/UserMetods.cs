using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SeleniumFull
{
    public class UserMetods : HelperBase
    {
        public UserMetods(AppManager app)
            : base(app)
        {
        }
        public void OpenUserPage()
        {
            app.driver.Navigate().GoToUrl(DB.baseURL + DB.UserURL);
        }
        public List<string> CheckStickers()
        {
            ReadOnlyCollection<IWebElement> allTovars;
            ReadOnlyCollection<IWebElement> allStickers;
            List<string> stickersResult = new List<string>();
            allTovars = app.Cmhelp.GetAllElements(DB.Tovar);
            for (int i = 0; i < allTovars.Count; i++)
            {
                allStickers = allTovars[i].FindElements(By.XPath(DB.sticker));
                if (allStickers.Count == 1)
                    stickersResult.Add(allTovars[i].GetAttribute(DB.attrTitle) + ": Stickers == 1;");
                else stickersResult.Add(allTovars[i].GetAttribute(DB.attrTitle) + ": Stickers != 1;");
            }
            return stickersResult;
        }

        public bool CheckResult(List<string> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Contains("!="))
                    return true;                
            }
            return false;

        }
    }
}
