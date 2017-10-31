using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class TestBase
    {
        public AppManager app;
        [SetUp]
        public void SetupTest()
        {
            app = AppManager.GetInstance();
        }
    }
}
