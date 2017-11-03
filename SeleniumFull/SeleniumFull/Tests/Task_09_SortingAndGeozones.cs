using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_09 : AdminBase
    {
        public List<string> textFromItems;
        public List<string> linksCountryWithGeozones;
        public ReadOnlyCollection<IWebElement> arrayFromSite;
        [Test]
        public void Task_09_1_Sorting()
        {
            app.Cmhelp.OpenTargetPage(DB.countryUrl);
            Actions(DB.CountryName);
            Assert.IsTrue(app.AdminMetods.CheckingSorting(textFromItems));

            linksCountryWithGeozones = app.AdminMetods.GetGeoLinkFromSite(arrayFromSite);
            
            for (int j = 0; j < linksCountryWithGeozones.Count; j++)
            {
                app.Cmhelp.OpenTargetPage(linksCountryWithGeozones[j]);
                Actions(DB.GeozoneName);
                Assert.IsTrue(app.AdminMetods.CheckingSorting(textFromItems));
            }
        }
        private void Actions(Llocator locator)
        {
            arrayFromSite = app.Cmhelp.GetAllElements(locator);
            textFromItems = app.AdminMetods.GetTextFromItems(arrayFromSite);
        }
        [Test]
        public void Task_09_2_Geozones()
        {
            app.Cmhelp.OpenTargetPage(DB.zoneUrl);

            arrayFromSite = app.Cmhelp.GetAllElements(DB.GeozoneName);
            linksCountryWithGeozones = app.AdminMetods.GetGeoLinkFromSite(arrayFromSite);
            for (int j = 0; j < linksCountryWithGeozones.Count; j++)
            {
                app.Cmhelp.OpenTargetPage(linksCountryWithGeozones[j]);
                Actions(DB.GeozoneSelect);
                Assert.IsTrue(app.AdminMetods.CheckingSorting(textFromItems));
            }
        }
    }
}
