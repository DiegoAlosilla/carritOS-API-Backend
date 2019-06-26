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
    public class DeleteBusinessOwnerPage
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


        public DeleteBusinessOwnerPage(string driver)
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

        public void clickOnDelete(int id)
        {
            webDriver.Navigate().GoToUrl("http://localhost:8080/BusinessOwner/Delete/" + id);
            Thread.Sleep(MAX_TIME);
        }

         public void clickOnConfirm()
        {
            webDriver.FindElement(By.XPath("/html/body/div/div/form/input[1]")).Click();
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
