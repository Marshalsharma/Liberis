using Liberis.Pages;
using Magnitude.Uba.UI.Tests.UI.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using static Magnitude.Uba.UI.Tests.UI.Utilities.WebDriverFactory;

namespace Liberis
{
    [TestClass]
    public class Testclass
    {
        public IWebDriver driver;
        DemoPage pageDemo;
        HomePage pageHome;
        [TestInitialize]
        public void BrowserSetup()
        {
            WebDriverFactory brower = new WebDriverFactory();
            driver = brower.createInstance(BrowserList.CHROME);
            brower.GetHomePage();
            pageDemo = new DemoPage(driver);
            pageHome = new HomePage(driver);
        }

        [TestMethod]
        public void TypesofPartners()
        {
            var actualValues = new List<string>() //Actual values to compare with UI values
                    {
                        "I'm a Broker",
                        "I'm an ISO",
                        "I'm a Strategic Partner"
                    };

            pageHome.demoButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(abc => pageDemo.title.Displayed);

            Assert.AreEqual("Type of partner", pageDemo.title.Text); //Validate partner page is loaded
            List<string> uiValues = pageDemo.GetRadioButtons(); //UI Values
            for (int i = 0; i < uiValues.Count; i++)
            {
                Assert.AreEqual(actualValues[i], uiValues[i]); //Comparison
            }
        }

        [TestMethod]
        public void VerifyErrorMessageOnPartnerPage()
        {
            pageHome.demoButton.Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(abc => pageDemo.title.Displayed);

            Assert.AreEqual("Type of partner", pageDemo.title.Text); //Validate partner page is loaded

            pageDemo.demoButton.Click(); //Click on demo button without selecting radio button
            Assert.AreEqual("Please select a type of partner", pageDemo.errorMsg.Text); //Error message validation
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
