using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.TestsSelenium.Driver
{
    public class VisorDriver
    {
        public static IWebDriver initDriver(string driver)
        {
            IWebDriver webDriver = null;
            switch (driver.ToLower())
            {
                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "opera":
                    webDriver = new OperaDriver();
                    break;

            }
            return webDriver;

        }


        public static void quitPage(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

    }
}
