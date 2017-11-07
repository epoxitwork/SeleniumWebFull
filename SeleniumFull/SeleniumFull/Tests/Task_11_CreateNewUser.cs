using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_11 : UserBase
    {
        [Test]
        public void Task_11_CreateNewUser()
        {
            app.Cmhelp.ClickButton(DB.CreateNewUser);
            string resultClass;
            UserData newUser;
            do
            {
                newUser = app.UserMetods.CreateNewUser();
                resultClass = app.UserMetods.FillInFields(newUser);
            }
            while (resultClass != DB.noticeSuccess);
            app.Cmhelp.Output(app.UserMetods.UserInList(newUser),DB.users, true);
            app.Cmhelp.ClickButton(DB.LogoutUser);
            app.Cmhelp.SendKeysToField(DB.NewUsrEmail, newUser.Email);
            app.Cmhelp.SendKeysToField(DB.NewUsrPswd1, newUser.Pswd);
            app.Cmhelp.ClickButton(DB.LoginUser);
            resultClass = app.UserMetods.LogoutUser();
            Assert.AreEqual(resultClass, DB.noticeSuccess);
        }
    }
}
