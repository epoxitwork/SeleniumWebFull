using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_19 : TestBase
    {
        [Test]
        public void Task_19_Carting()
        {
            app.MainPage.OpenUserPage();                
            app.ItemPage.AddingItemsToCart();
            app.CartPage.DeletingItemsInCart();
            app.MainPage.OpenUserPage();
            Assert.AreEqual(Convert.ToInt16(app.Cmhelp.GetTextFromElements(DB.QuantityInCart)), 0);
        }
    }
}
