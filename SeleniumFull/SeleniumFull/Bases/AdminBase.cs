using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class AdminBase : TestBase
    {
        [SetUp]
        public void AdminAuth()
        {
            app = AppManager.GetInstance();
            app.Cmhelp.OpenTargetPage(DB.adminUrl);
            string loginResult = app.AdminMetods.Login();
        }
    }
}
