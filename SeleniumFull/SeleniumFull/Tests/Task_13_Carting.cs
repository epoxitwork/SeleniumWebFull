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
    public class Task_13 : UserBase
    {
        //public string itemsInCart;
        [Test]
        public void Task_13_Carting()
        {
            string itemsInCart = app.Cmhelp.GetTextFromElements(DB.QuantityInCart);
            while (Convert.ToInt16(itemsInCart) < 3)
            {
                itemsInCart = AddItemToCart(itemsInCart);
                app.UserMetods.OpenUserPage();
            }
            Assert.AreEqual(Convert.ToInt16(itemsInCart), 3);
            app.Cmhelp.ClickButton(DB.OpenCart);
            itemsInCart = app.Cmhelp.GetTextFromElements(DB.Empty);
            while (app.Cmhelp.GetTextFromElements(DB.Empty) != "There are no items in your cart.")
                DeletingItems();
            app.UserMetods.OpenUserPage();
            app.Cmhelp.WaitForLoading(DB.QuantityInCart);
            Assert.AreEqual(Convert.ToInt16(app.Cmhelp.GetTextFromElements(DB.QuantityInCart)), 0);
        }

        private void DeletingItems()
        {
            string result = app.Cmhelp.GetTextFromElements(DB.Empty);            
            if (result == "")
            {
                int count = 0;
                var itemsNamesInCart = app.Cmhelp.GetAllElements(DB.ItemsNamesInCart);
                var itemsCountInCart = app.Cmhelp.GetAllElements(DB.ItemsCountInCart);
                do
                {
                    try 
                    {
                        app.Cmhelp.WaitElementToBeClickable(DB.RemoveBtn); 
                        app.Cmhelp.ClickButton(DB.RemoveBtn); 
                    }
                    catch (Exception) { }
                    finally 
                    { 
                        itemsNamesInCart = app.Cmhelp.GetAllElements(DB.ItemsNamesInCart);
                        itemsCountInCart = app.Cmhelp.GetAllElements(DB.ItemsCountInCart);
                    }
                    Thread.Sleep(100);
                    count++;
                    if (count > 100)
                        throw new Exception("Слишком долго ждём!");
                }
                while (itemsNamesInCart == app.Cmhelp.GetAllElements(DB.ItemsNamesInCart) || itemsCountInCart == app.Cmhelp.GetAllElements(DB.ItemsCountInCart));
            }
        }

        private string AddItemToCart(string itemsInCart)
        {            
            app.Cmhelp.ClickButton(DB.Tovar);
            try { app.Cmhelp.SelectElement(DB.SizeItem, DB.Sizes); }
            catch (NoSuchElementException) { }

            app.Cmhelp.ClickButton(DB.AddToCart);
            int count = 0;
            int asd = Convert.ToInt16(itemsInCart);
            while (asd != Convert.ToInt16(itemsInCart)-1)
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
