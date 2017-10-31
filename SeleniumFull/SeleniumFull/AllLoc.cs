using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class AllLoc
    {
        public static string baseURL = "http://localhost:8080/";
        public static string attrTitle = "title";
        public static string h1 = "//h1";
        public static Llocator H1 = new Llocator(Locator.XPath, h1);
        #region Admin        
        public static string adminUrl = "litecart/admin/login.php";
        public static string username = "//input[@name='username']";
        public static Llocator Username = new Llocator(Locator.XPath, username); 
        public static string password = "//input[@name='password']";
        public static Llocator Password = new Llocator(Locator.XPath, password); 
        public static string credential = "admin";
        public static string btnLogin = "//button";
        public static Llocator BtnLogin = new Llocator(Locator.XPath, btnLogin); 
        public static string btnLogout = "//a[@title='Logout']/i";
        public static Llocator BtnLogout = new Llocator(Locator.XPath, btnLogout); 
        public static string txtLogout = "//a[@title='Logout']";
        public static Llocator TxtLogout = new Llocator(Locator.XPath, txtLogout); 
        public static string trueLogin = "Logout";
        public static string adminMenu1lvl = "//*[@id='app-']/a";
        public static Llocator AdminMenu1lvl = new Llocator(Locator.XPath, adminMenu1lvl); 
        public static string adminMenu2lvl = "//*[@class='selected']//li";
        public static Llocator AdminMenu2lvl = new Llocator(Locator.XPath, adminMenu2lvl);
        #endregion

        #region User

        #endregion
    }
}
