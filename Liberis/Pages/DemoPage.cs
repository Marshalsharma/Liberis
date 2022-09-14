using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberis.Pages
{
    class DemoPage
    {
        public static IWebDriver _webDriver;

        public DemoPage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement title => _webDriver.FindElement(By.XPath("//div[@class='inner-content']//h4"));
        public IList<IWebElement> radioButtons => _webDriver.FindElements(By.XPath("//div[@class='radio_container']//div//label"));
        public IWebElement demoButton => _webDriver.FindElement(By.XPath("//a[@href='#0']"));
        public IWebElement errorMsg => _webDriver.FindElement(By.XPath("//div[@class='ph-error-inner']"));
        
        public List<string> GetRadioButtons()
        {
            List<string> allText = new List<string>();
            foreach (IWebElement element in radioButtons)
            {
                allText.Add(element.Text);
            }
            return allText;
        }
    }
}
