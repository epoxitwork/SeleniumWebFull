using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace SeleniumFull
{
    public class UserMetods : HelperBase
    {
        public UserMetods(AppManager app)
            : base(app)
        {
        }
        public void OpenUserPage()
        {
            app.driver.Navigate().GoToUrl(DB.baseURL + DB.userURL);
        }
        public List<string> CheckStickers()
        {
            ReadOnlyCollection<IWebElement> allTovars;
            ReadOnlyCollection<IWebElement> allStickers;
            List<string> stickersResult = new List<string>();
            allTovars = app.Cmhelp.GetAllElements(DB.Tovar);
            for (int i = 0; i < allTovars.Count; i++)
            {
                allStickers = allTovars[i].FindElements(By.XPath(DB.sticker));
                if (allStickers.Count == 1)
                    stickersResult.Add(allTovars[i].GetAttribute(DB.attrTitle) + ": Stickers == 1;");
                else stickersResult.Add(allTovars[i].GetAttribute(DB.attrTitle) + ": Stickers != 1;");
            }
            return stickersResult;
        }
        public bool CheckResult(List<string> result)
        {
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].Contains("!="))
                    return true;                
            }
            return false;
        }

        public UserData CreateNewUser()
        {
            string firstname = app.Cmhelp.GenerateRandomString(8,1); 
            string lastname = app.Cmhelp.GenerateRandomString(8,1);
            string address = app.Cmhelp.GenerateRandomString(8,99);
            string postcode = app.Cmhelp.GenerateRandomString(6, 3);
            string city = app.Cmhelp.GenerateRandomString(8,1);
            string email = firstname + "." + lastname + "@" + "gmail.com";
            string phone = "";
            string pswd = app.Cmhelp.GenerateRandomString(8, 99);
            return new UserData(firstname, lastname, address, postcode, city, email, phone, pswd);
        }
        public string FillInFields(UserData newUser)
        {
            var allCountries = app.Cmhelp.GetAllElements(DB.AllCountries);//app.driver.FindElements(By.XPath(DB.allCountries));
            int randomNum = app.Cmhelp.SimpleRnd(1, allCountries.Count-1);
            string countryName = allCountries[randomNum].Text;
            string countryPhone = allCountries[randomNum].GetAttribute(DB.attrPhonecode);
            newUser.Phone = "+" + countryPhone + app.Cmhelp.GenerateRandomString(8 - countryPhone.Length, 3);
            app.Cmhelp.ClickButton(DB.CountrySelector);
            app.Cmhelp.SendKeysToField(DB.CountryInput, countryName);
            app.Cmhelp.SendKeysToField(DB.CountryInput, Keys.Enter);
            app.Cmhelp.SendKeysToField(DB.NewUsrFirstname, newUser.Firstname);
            app.Cmhelp.SendKeysToField(DB.NewUsrLastname, newUser.Lastname);
            app.Cmhelp.SendKeysToField(DB.NewUsrAddress, newUser.Address);
            app.Cmhelp.SendKeysToField(DB.NewUsrPostcode, newUser.Postcode);
            app.Cmhelp.SendKeysToField(DB.NewUsrCity, newUser.City);
            app.Cmhelp.SendKeysToField(DB.NewUsrEmail, newUser.Email);
            //app.Cmhelp.SendKeysToField(DB.NewUsrEmail, "test.test@test");//для тестов
            app.Cmhelp.SendKeysToField(DB.NewUsrPhone, newUser.Phone);
            app.Cmhelp.SendKeysToField(DB.NewUsrPswd1, newUser.Pswd);
            app.Cmhelp.SendKeysToField(DB.NewUsrPswd2, newUser.Pswd);
            app.Cmhelp.ClickButton(DB.NewUsrCreateBtn);
            var temp = app.driver.FindElement(By.XPath(DB.newUsrNoticeText));
            var text = temp.Text;
            var attrClass = temp.GetAttribute(DB.attrClass);
            var displayed = temp.Displayed;
            var enabled = temp.Enabled;
            return attrClass;
        }
        public List<string> UserInList(UserData newUser)
        {
            List<string> result = new List<string>();
            result.Add(newUser.Email);
            result.Add(newUser.Pswd);
            result.Add("-------------------------");
            return result;
        }
        public string LogoutUser()
        {
            app.Cmhelp.ClickButton(DB.LogoutUser);
            var temp = app.driver.FindElement(By.XPath(DB.newUsrNoticeText));
            var attrClass = temp.GetAttribute(DB.attrClass);
            return attrClass;
        }
    }
}
