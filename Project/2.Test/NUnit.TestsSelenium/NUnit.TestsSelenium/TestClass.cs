// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnit.TestsSelenium
{
    [TestFixture]
    public class TestClass
    {
        private IWebDriver driver;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:8080");
        }

        [Test]
        public void TestApp()
        {
            driver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/li[4]/a")).Click();
            driver.FindElement(By.XPath("/html/body/div/p/a")).Click();
        }


        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
