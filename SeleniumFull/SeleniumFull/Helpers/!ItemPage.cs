using System;
using System.Threading;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Drawing;
using System.Linq;

using System.Threading.Tasks;


namespace SeleniumFull
{
    public class ItemPage : HelperBase
    {
        public ItemPage(AppManager app)
            : base(app)
        {
        }
        public void AddingItemsToCart()
        {
            string itemsInCart = app.Cmhelp.GetTextFromElements(DB.QuantityInCart);
            while (Convert.ToInt16(itemsInCart) < 3)
            {
                itemsInCart = AddItemToCart(itemsInCart);
                app.MainPage.OpenUserPage();
            }
            Assert.AreEqual(Convert.ToInt16(itemsInCart), 3);
        }
        public string AddItemToCart(string itemsInCart)
        {
            app.Cmhelp.ClickButton(DB.Tovar);
            try { app.Cmhelp.SelectElement(DB.SizeItem, DB.Sizes); }
            catch (NoSuchElementException) { }

            app.Cmhelp.ClickButton(DB.AddToCart);
            int count = 0;
            int asd = Convert.ToInt16(itemsInCart);
            while (asd != Convert.ToInt16(itemsInCart) - 1)
            {
                Thread.Sleep(100);
                count++;
                itemsInCart = app.Cmhelp.GetTextFromElements(DB.QuantityInCart);
                if (count > 200)
                    throw new Exception("Слишком долго ждём!");
            }
            return itemsInCart;
        }
    }
}
