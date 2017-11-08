using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_12 : AdminBase
    {
        [Test]
        public void Task_12_AddItemInCatalog()
        {
            app.Cmhelp.ClickButton(DB.MenuCatalog);
            List<string> productsNamesBefore = app.Cmhelp.GetAllTextFromElements(DB.ItemLinkInTable);

            app.Cmhelp.ClickButton(DB.AddNewProduct);
            string productName = app.Cmhelp.GenerateRandomString(8,1);

            app.AdminMetods.FillInItem(productName);
            app.Cmhelp.ClickButton(DB.SaveBtn);

            List<string> productsNamesAfter = app.Cmhelp.GetAllTextFromElements(DB.ItemLinkInTable);

            Assert.Contains(productName, productsNamesAfter);
            Assert.AreEqual(productsNamesBefore.Count+1, productsNamesAfter.Count);
        }
    }
}
