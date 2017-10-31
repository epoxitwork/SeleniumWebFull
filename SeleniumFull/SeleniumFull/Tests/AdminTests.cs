using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class AdminTests : AuthBase
    {
        [Test]
        public void Task_07_ClickMenuAndFindH1()
        {
            var result = app.AdminMetods.ClickLeftMenu();
            app.AdminMetods.Output(result);
        }
    }
}
