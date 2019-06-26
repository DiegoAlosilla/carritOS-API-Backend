// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using NUnit.TestsSelenium.Data;
using NUnit.TestsSelenium.Page;
using OpenQA.Selenium;
using System;

/**
* https://www.youtube.com/watch?v=C1RiUYkSKGw -> reports
* https://www.youtube.com/watch?v=4EGLvQ-2fpc -> reports
* https://www.youtube.com/watch?v=_RfkR8RNMP4 
* @author Juan Diego Alosilla
* @email diegoalosillagmail.com
*/
namespace NUnit.TestsSelenium
{
    [TestFixture]
    public class DeleteBusinessOwner
    {
        private readonly IWebDriver driver;
        public ExtentReports extent;
        public ExtentTest test;
        public ExtentHtmlReporter htmlReporter;
        public int counter = 1;
        private DeleteBusinessOwnerPage businessOwnerPage;

        [SetUp]
        public void OpenBrowser()
        {
            htmlReporter = new ExtentHtmlReporter(@".\Reports\reportDiego.html");
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Test Report | Diego Alosilla";
            htmlReporter.Config.ReportName = "Test Report | Diego Alosilla";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.Flush();

            businessOwnerPage = new DeleteBusinessOwnerPage("chrome");
            businessOwnerPage.enterPage("http://localhost:8080");
            Excel.populateInCollection(@"C:\Users\USUARIO\Documents\GitHub\carritOS-WEB\Data\DeleteBusinessOwner.xlsx");

        }

        [Test]
        public void TestApp()
        {
            try {
                businessOwnerPage.clickOnBusinessOwner();
                for (int i = 1; i <= Excel.getTotalRowCount(); i++)
                {
                    string CurrentId = Excel.ReadData(i, "Id");
                    int Id = System.Convert.ToInt32(CurrentId);
                    businessOwnerPage.clickOnDelete(Id);
                    businessOwnerPage.clickOnConfirm();
                }
            } catch (Exception e){
                Console.WriteLine(e.Message);
            }
            
        }


        [TearDown]
        public void CloseBrowser()
        {
            businessOwnerPage.quitPage();
        }
    }

}