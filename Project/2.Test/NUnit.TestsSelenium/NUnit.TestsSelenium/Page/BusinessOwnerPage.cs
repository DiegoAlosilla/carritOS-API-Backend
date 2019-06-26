using NUnit.TestsSelenium.Driver;
using OpenQA.Selenium;
using System;
using System.Threading;
/**
* @author Juan Diego Alosilla
* @email diegoalosillagmail.com
*/
namespace NUnit.TestsSelenium.Page
{
    public class BusinessOwnerPage
    {
        private readonly By FirstName = By.Id("FirstName");
        private readonly By LastName = By.Id("LastName");
        private readonly By Dni = By.Id("Dni");
        private readonly By Email = By.Id("Email");
        private readonly By Movil = By.Id("Movil");
        private readonly By Password = By.Id("Password");
        private readonly By City = By.Id("City");
        private readonly By Country = By.Id("Country");

        private IWebDriver webDriver = null;
        private static readonly int MAX_TIME = 3000;


        public BusinessOwnerPage(string driver)
        {
            webDriver = VisorDriver.initDriver(driver);
        }

        public void enterPage(string url)
        {
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            webDriver.Navigate().GoToUrl(url);
            webDriver.Manage().Window.Maximize();
        }

        public void clickOnBusinessOwner()
        {
            webDriver.FindElement(By.XPath("/html/body/nav/div/div[2]/ul/li[4]/a")).Click();
            //Thread.Sleep(MAX_TIME);
        }

        public void clickOnCreateNew()
        {
            webDriver.FindElement(By.XPath("/html/body/div/p/a")).Click();
            Thread.Sleep(MAX_TIME);
        }

        public void setBusinessOwner(string _FirstName,string _LastName, string _Dni,string _Email,
            string _Movil, string _Password, string _City, string _Country)
        {
            webDriver.FindElement(FirstName).SendKeys(_FirstName);
            webDriver.FindElement(LastName).SendKeys(_LastName);
            webDriver.FindElement(Dni).SendKeys(_Dni);
            webDriver.FindElement(Email).SendKeys(_Email);
            webDriver.FindElement(Movil).SendKeys(_Movil);
            webDriver.FindElement(Password).SendKeys(_Password);
            webDriver.FindElement(City).SendKeys(_City);
            webDriver.FindElement(Country).SendKeys(_Country);
            Thread.Sleep(MAX_TIME);
        }

        public void clickOnSave()
        {
            webDriver.FindElement(By.XPath("/html/body/div/div[1]/div/form/div[9]/input")).Click();
            Thread.Sleep(MAX_TIME);
        }

        public IWebDriver getPage()
        {
            return webDriver;
        }

        public void quitPage()
        {
            VisorDriver.quitPage(webDriver);
        }

        

    }
}
