using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberis.Pages
{
    class HomePage
    {
        public static IWebDriver _webDriver;

        public HomePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public IWebElement demoButton => _webDriver.FindElement(By.XPath("//div[@class='header-cta']//a"));
    }
}
