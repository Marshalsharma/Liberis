using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Magnitude.Uba.UI.Tests.UI.Utilities
{
    public class WebDriverFactory
    {
        public IWebDriver driver;
        public IWebDriver createInstance(BrowserList browser)
        {
            BrowserList b = browser;
            switch (b)
            {
                case BrowserList.CHROME:
                   driver = new ChromeDriver();
                    break;
             /*   case BrowserList.FIREFOX:
                    driver = new FirefoxDriverManager().createDriver();
                    break;  */
            }
            return driver;
        }

        public enum BrowserList
        {
            CHROME, FIREFOX, EDGE, SAFARI, OPERA, IE //We can use for multiple browsers and define in above method accordingly 
        }

        public void GetHomePage()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.liberis.com/");
        }
    }
}
