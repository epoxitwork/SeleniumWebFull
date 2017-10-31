using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class AuthBase : TestBase
    {
        [SetUp]
        public void Auth()
        {
            app = AppManager.GetInstance();
            app.AdminMetods.OpenAdminPage();
            string loginResult = app.AdminMetods.Login();
        }
    }
}
