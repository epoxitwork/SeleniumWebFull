using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_03 : TestBase
    {
        [Test]
        public void Task_03_AdminLogin()
        {
            app.Cmhelp.OpenTargetPage(DB.adminUrl);
            string loginResult = app.AdminMetods.Login();
            Assert.AreEqual(loginResult, DB.trueLogin);
        }
    }
}
