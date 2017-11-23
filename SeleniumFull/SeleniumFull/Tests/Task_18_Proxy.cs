using AutomatedTester.BrowserMob;
using AutomatedTester.BrowserMob.HAR;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Remote;
//using OpenQA.Selenium.Support.UI;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

namespace SeleniumFull
{
    [TestFixture]
    public class Task_18
    {
        [Test]
        public void Task_18_Proxy()
        {
            Server server = new Server(@"c:\Users\temp1\Documents\Visual Studio 2012\Projects\SeleniumFull\packages\browsermob-proxy-2.1.4\bin\browsermob-proxy.bat");
            server.CreateProxy();
            server.Start();

            var client = server.CreateProxy();
            client.NewHar("Load Test Numbers");

            Proxy proxyy = new Proxy { HttpProxy = client.SeleniumProxy };
            ChromeOptions options = new ChromeOptions();
            options.Proxy = proxyy;
            IWebDriver driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("http://www.google.co.uk");
            HarResult harData = client.GetHar();
            driver.Quit();
            client.Close();
            server.Stop();
        }
    }
}
