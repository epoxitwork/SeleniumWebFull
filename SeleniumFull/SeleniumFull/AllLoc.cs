using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    public class DB
    {
        public static string baseURL = "http://localhost:8080/";        
        public static string attrTitle = "title";
        public static string attrHref = "href";
        public static string attrPostcode = "data-postcode-format";
        public static string attrPhonecode = "data-phone-code";
        public static string attrClass = "class";
        
        public static string h1 = "//h1";
        public static Llocator H1 = new Llocator(Locator.XPath, h1);

        #region Urls
        public static string adminUrl = "litecart/admin/login.php";
        public static string countryUrl = "litecart/admin/?app=countries&doc=countries";
        public static string zoneUrl = "litecart/admin/?app=geo_zones&doc=geo_zones";
        public static string userURL = "litecart/en/";
        #endregion

        #region Admin
        public static string credential = "admin";
        public static string trueLogin = "Logout";

        public static string username = "//input[@name='username']";
        public static Llocator Username = new Llocator(Locator.XPath, username);
        public static string password = "//input[@name='password']";
        public static Llocator Password = new Llocator(Locator.XPath, password); 
        public static string btnLogin = "//button";
        public static Llocator BtnLogin = new Llocator(Locator.XPath, btnLogin); 
        public static string btnLogout = "//a[@title='Logout']/i";
        public static Llocator BtnLogout = new Llocator(Locator.XPath, btnLogout); 
        public static string txtLogout = "//a[@title='Logout']";
        public static Llocator TxtLogout = new Llocator(Locator.XPath, txtLogout); 
        public static string adminMenu1lvl = "//*[@id='app-']/a";
        public static Llocator AdminMenu1lvl = new Llocator(Locator.XPath, adminMenu1lvl); 
        public static string adminMenu2lvl = "//*[@class='selected']//li";
        public static Llocator AdminMenu2lvl = new Llocator(Locator.XPath, adminMenu2lvl);
        public static string countryName = "//*[@class='dataTable']//td[5]/a[contains(@href, 'edit_country')]";
        public static Llocator CountryName = new Llocator(Locator.XPath, countryName);
        public static string geozoneNum = "//*[@class='dataTable']//td[6]";
        public static Llocator GeozoneNum = new Llocator(Locator.XPath, geozoneNum);
        public static string geozoneName = "//*[@id='table-zones']//td[3]";
        public static Llocator GeozoneName = new Llocator(Locator.XPath, geozoneName);
        public static string geozoneSelect = "//*[@id='table-zones']//td[3]//option[@selected='selected']";
        public static Llocator GeozoneSelect = new Llocator(Locator.XPath, geozoneSelect);

        public static string itemImagePath = @"%PUBLIC%\Pictures\Sample Pictures\Desert.jpg";
        public static string filename = "Desert.jpg";

        public static string menuCatalog = "//a[contains(@href,'doc=catalog')]";
        public static Llocator MenuCatalog = new Llocator(Locator.XPath, menuCatalog);
        public static string addNewProduct = "Add New Product";
        public static Llocator AddNewProduct = new Llocator(Locator.LinkText, addNewProduct);
        public static string itemEnabled = "//input[@name='status' and @value='1']";
        public static Llocator ItemEnabled = new Llocator(Locator.XPath, itemEnabled);
        public static string itemName = "//input[@name='name[en]']";
        public static Llocator ItemName = new Llocator(Locator.XPath, itemName);
        public static string itemCategories = "//input[@name='categories[]' and @type='checkbox']";
        public static Llocator ItemCategories = new Llocator(Locator.XPath, itemCategories);
        public static string itemDateFrom = "//input[@name='date_valid_from']";
        public static Llocator ItemDateFrom = new Llocator(Locator.XPath, itemDateFrom);
        public static string itemDateTo = "//input[@name='date_valid_to']";
        public static Llocator ItemDateTo = new Llocator(Locator.XPath, itemDateTo);
        public static string itemImageLocator = "new_images[]";
        public static Llocator ItemImageLocator = new Llocator(Locator.Name, itemImageLocator);
        public static string saveBtn = "//button[@name='save']";
        public static Llocator SaveBtn = new Llocator(Locator.XPath, saveBtn);
        public static string itemLinkInTable = "//td[3]/a[contains(@href,'&product_id=')]";
        public static Llocator ItemLinkInTable = new Llocator(Locator.XPath, itemLinkInTable);
        public static string editPencil = "//i[@class='fa fa-pencil']";
        public static Llocator EditPencil = new Llocator(Locator.XPath, editPencil);
        public static string newCountry = "//*[@id='content']/div/a";
        public static Llocator NewCountry = new Llocator(Locator.XPath, newCountry);
        public static string externalLink = "//i[@class='fa fa-external-link']/..";
        public static Llocator ExternalLink = new Llocator(Locator.XPath, externalLink);
        public static string allSubCategory = "//table[@class='dataTable']//a[contains(@href,'catalog&category')]";
        public static Llocator AllSubCategory = new Llocator(Locator.XPath, allSubCategory);
        public static string allGoods = "//table[@class='dataTable']//td[3]/a[contains(@href,'&product_id=')]";
        public static Llocator AllGoods = new Llocator(Locator.XPath, allGoods);

        #endregion

        #region ItemsPage
        public static string tovar = "//li[starts-with(@class,'product')]//a[@class='link']";
        public static Llocator Tovar = new Llocator(Locator.XPath, tovar);
        public static string addToCart = "//button[@value='Add To Cart']";
        public static Llocator AddToCart = new Llocator(Locator.XPath, addToCart);
        public static string sizeItem = "//table//td[@class='options']/select";
        public static Llocator SizeItem = new Llocator(Locator.XPath, sizeItem);
        public static string sizes = ".//option";
        public static Llocator Sizes = new Llocator(Locator.XPath, sizes);
        public static string removeBtn = "//button[@name='remove_cart_item']";
        public static Llocator RemoveBtn = new Llocator(Locator.XPath, removeBtn);
        public static string emptyCart = "//*[@id='checkout-cart-wrapper']/p[1]/em";
        public static Llocator EmptyCart = new Llocator(Locator.XPath, emptyCart);
        public static string itemsNamesInCart = "//*[@id='order_confirmation-wrapper']//tr/td[@class='item']";
        public static Llocator ItemsNamesInCart = new Llocator(Locator.XPath, itemsNamesInCart);
        public static string itemsCountInCart = "//*[@id='order_confirmation-wrapper']//tr/td[@class='item']";
        public static Llocator ItemsCountInCart = new Llocator(Locator.XPath, itemsCountInCart);
        public static string openCart = @"Checkout »";
        public static Llocator OpenCart = new Llocator(Locator.LinkText, openCart);
        public static string quantityInCart = "//div[@id='cart']/a[@class='content']/span[@class='quantity']";
        public static Llocator QuantityInCart = new Llocator(Locator.XPath, quantityInCart);
        public static string sticker = "//div[@class='image-wrapper']/div[starts-with(@class,'sticker')]";
        public static Llocator Sticker = new Llocator(Locator.XPath, sticker);
        public static string itemNameOnStartPage2 = "//*div[@class='box']//div[@class='name']";
        public static string itemNameOnStartPage = "//*[@id='box-campaigns']//div[@class='name']";
        public static Llocator ItemNameOnStartPage = new Llocator(Locator.XPath, itemNameOnStartPage);
        public static string itemNameOnItemPage = "//*[@id='box-product']//h1";
        public static Llocator ItemNameOnItemPage = new Llocator(Locator.XPath, itemNameOnItemPage);
        public static string itemLinkOnStartPage = "//*[@id='box-campaigns']//li/a[@class='link']";
        public static Llocator ItemLinkOnStartPage = new Llocator(Locator.XPath, itemLinkOnStartPage);
        public static string mainItemLocator = "//*[@id='box-campaigns']";
        public static Llocator MainItemLocator = new Llocator(Locator.XPath, mainItemLocator);
        public static string mainItemLocator2 = "//*[@id='box-product']";
        public static Llocator MainItemLocator2 = new Llocator(Locator.XPath, mainItemLocator2);
        public static string itemRegularPrice = ".//s[@class='regular-price']";
        public static Llocator ItemRegularPrice = new Llocator(Locator.XPath, itemRegularPrice);
        public static string itemCampaignPrice = ".//*[@class='campaign-price']";
        public static Llocator ItemCampaignPrice = new Llocator(Locator.XPath, itemCampaignPrice);
        #endregion

        #region UserLoginLogout
        public static string noticeSuccess = "notice success";

        public static string logoutUser = "Logout";
        public static Llocator LogoutUser = new Llocator(Locator.LinkText, logoutUser);
        public static string loginUser = "//button[@name='login']";
        public static Llocator LoginUser = new Llocator(Locator.XPath, loginUser);        
        #endregion

        #region UserCreation
        public static string createNewUser = "New customers click here";
        public static Llocator CreateNewUser = new Llocator(Locator.LinkText, createNewUser);
        public static string newUsrFirstname = "//input[@name='firstname']";
        public static Llocator NewUsrFirstname = new Llocator(Locator.XPath, newUsrFirstname);
        public static string newUsrLastname = "//input[@name='lastname']";
        public static Llocator NewUsrLastname = new Llocator(Locator.XPath, newUsrLastname);
        public static string newUsrAddress = "//input[@name='address1']";
        public static Llocator NewUsrAddress = new Llocator(Locator.XPath, newUsrAddress);
        public static string newUsrPostcode = "//input[@name='postcode']";
        public static Llocator NewUsrPostcode = new Llocator(Locator.XPath, newUsrPostcode);
        public static string newUsrCity = "//input[@name='city']";
        public static Llocator NewUsrCity = new Llocator(Locator.XPath, newUsrCity);
        public static string newUsrEmail = "//input[@name='email']";
        public static Llocator NewUsrEmail = new Llocator(Locator.XPath, newUsrEmail);
        public static string newUsrPhone = "//input[@name='phone']";
        public static Llocator NewUsrPhone = new Llocator(Locator.XPath, newUsrPhone);
        public static string newUsrPswd1 = "//input[@name='password']";
        public static Llocator NewUsrPswd1 = new Llocator(Locator.XPath, newUsrPswd1);
        public static string newUsrPswd2 = "//input[@name='confirmed_password']";
        public static Llocator NewUsrPswd2 = new Llocator(Locator.XPath, newUsrPswd2);
        public static string newUsrCreateBtn = "//button[@name='create_account']";
        public static Llocator NewUsrCreateBtn = new Llocator(Locator.XPath, newUsrCreateBtn);
        public static string newUsrNoticeText = "//*[@id='notices']/div";
        public static Llocator NewUsrNoticeText = new Llocator(Locator.XPath, newUsrNoticeText);
        public static string allCountries = "//*[@name='country_code']/option[@value and @data-postcode-format='']";
        public static Llocator AllCountries = new Llocator(Locator.XPath, allCountries);
        public static string countrySelector = "//*[@class='select2-selection__rendered']";
        public static Llocator CountrySelector = new Llocator(Locator.XPath, countrySelector);
        public static string countryInput = "//*[@class='select2-search__field']";
        public static Llocator CountryInput = new Llocator(Locator.XPath, countryInput);
        #endregion

        #region Reports
        public static string t_07_report = "Task_07_Report.txt";
        public static string t_08_report = "Task_08_Report.txt";
        public static string t_091_report = "Task_091_Report.txt";
        public static string t_092_report = "Task_092_Report.txt";
        public static string users = "users.txt";
        #endregion
    }
}
