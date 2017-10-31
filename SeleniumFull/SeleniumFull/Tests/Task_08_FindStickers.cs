using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_08 : UserBase
    {
        [Test]
        public void Task_08_FindStickers()
        {            
            var result =  app.UserMetods.CheckStickers();
            app.Cmhelp.Output(result, "Task_08_Report.txt");
        }
    }
}
