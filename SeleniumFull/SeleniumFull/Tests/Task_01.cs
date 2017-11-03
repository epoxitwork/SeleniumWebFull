using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_01 : TestBase
    {
        [Test]
        public void Task_01_OpenSite()
        {
            app.driver.Navigate().GoToUrl("http://google.com");
        }
    }
}
