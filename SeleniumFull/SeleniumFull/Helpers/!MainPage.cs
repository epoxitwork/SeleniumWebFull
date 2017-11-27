using System;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Drawing;
using System.Linq;

using System.Threading.Tasks;


namespace SeleniumFull
{
    public class MainPage : HelperBase
    {
        public MainPage(AppManager app)
            : base(app)
        {
        }
        public void OpenUserPage()
        {
            app.driver.Navigate().GoToUrl(DB.baseURL + DB.userURL);
            app.Cmhelp.WaitForLoading(DB.QuantityInCart);
        }
    }
}
