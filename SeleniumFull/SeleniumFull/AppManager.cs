using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class AppManager
    {
        #region Variables
        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();
        public IWebDriver driver;
        public CommHelper cmhelp;
        public AdminMetods adminmetods;
        public UserMetods usermetods;

        #endregion
        public AppManager()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Size = new Size(1180, 1000);
            var timeout = new TimeSpan(0, 2, 0);
            driver.Manage().Window.Position = new Point(0, 30);
            driver.Manage().Timeouts().ImplicitWait = timeout;
            driver.Manage().Timeouts().PageLoad = timeout;
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(10);
            cmhelp = new CommHelper(this);
            adminmetods = new AdminMetods(this);
            usermetods = new UserMetods(this);
        }
        #region Property
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public CommHelper Cmhelp
        {
            get
            {
                return cmhelp;
            }
        }
        public AdminMetods AdminMetods
        {
            get
            {
                return adminmetods;
            }
        }
        public UserMetods UserMetods
        {
            get
            {
                return usermetods;
            }
        }
        #endregion
        ~AppManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
            }
        }
        public static AppManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
