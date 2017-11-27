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
    public class CartPage : HelperBase
    {
        public CartPage(AppManager app)
            : base(app)
        {
        }
        public void DeletingItemsInCart()
        {
            app.Cmhelp.ClickButton(DB.OpenCart);
            while (app.Cmhelp.GetTextFromElements(DB.EmptyCart) != "There are no items in your cart.")
                DeletingItems();
        }
        public void DeletingItems()
        {
            string result = app.Cmhelp.GetTextFromElements(DB.EmptyCart);
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
                while (Checking(itemsNamesInCart, itemsCountInCart));
            }
        }
        public bool Checking(ReadOnlyCollection<IWebElement> itemsNamesInCart, ReadOnlyCollection<IWebElement> itemsCountInCart)
        {
            bool firstCondition = itemsNamesInCart == app.Cmhelp.GetAllElements(DB.ItemsNamesInCart);
            bool secondCondition = itemsCountInCart == app.Cmhelp.GetAllElements(DB.ItemsCountInCart);
            return firstCondition || secondCondition;
        }
    }
}
