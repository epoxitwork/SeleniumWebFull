using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;

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
            app.driver.Navigate().GoToUrl(AllLoc.baseURL);
        }
        
    }
}
