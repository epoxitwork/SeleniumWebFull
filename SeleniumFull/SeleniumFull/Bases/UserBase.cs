using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class UserBase : TestBase
    {
        [SetUp]
        public void UserOpenPage()
        {
            app = AppManager.GetInstance();
            app.UserMetods.OpenUserPage();
        }
    }
}
