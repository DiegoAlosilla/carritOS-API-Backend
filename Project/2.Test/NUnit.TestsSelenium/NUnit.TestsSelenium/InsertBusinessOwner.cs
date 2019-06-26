// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
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
    public class InsertBusinessOwner
    {
        public ExtentReports extent;
        public ExtentHtmlReporter htmlReporter;
        public int counter = 1;
        private BusinessOwnerPage businessOwnerPage;

        [SetUp]
        public void OpenBrowser()
        {
            htmlReporter = new ExtentHtmlReporter(@".\Reports\Insert\reportDiego.html");
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.DocumentTitle = "Test Report | Diego Alosilla";
            htmlReporter.Config.ReportName = "Test Report | Diego Alosilla";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
           

            businessOwnerPage = new BusinessOwnerPage("chrome");
            businessOwnerPage.enterPage("http://localhost:8080");
            Excel.populateInCollection(@"C:\Users\USUARIO\Documents\GitHub\carritOS-WEB\Data\DeleteBusinessOwner.xlsx");

        }

        [Test]
        public void Insert()
        {
            try {
                
                businessOwnerPage.clickOnBusinessOwner();
                for (int i = 1; i <= Excel.getTotalRowCount(); i++)
                {
                    var test = extent.CreateTest("Insert BusinessOwner Test" + i);
                    var features = extent.CreateTest<Feature>("Insert BusinessOwner Feature"+1);
                    var scenario = features.CreateNode<Scenario>("Insert BusinessOwner Scenario"+1);

                    string currentFistName = Excel.ReadData(i, "FirstName");
                    string currentLastName = Excel.ReadData(i, "LastName");
                    string currentDni = Excel.ReadData(i, "Dni");
                    string currentEmail = Excel.ReadData(i, "Email");
                    string currentMovil = Excel.ReadData(i, "Movil");
                    string currentPassword = Excel.ReadData(i, "Password");
                    string currentCity = Excel.ReadData(i, "City");
                    string currentCountry = Excel.ReadData(i, "Country");

                    
                    businessOwnerPage.clickOnCreateNew();
                    businessOwnerPage.setBusinessOwner(
                        currentFistName,
                        currentLastName,
                        currentDni,
                        currentEmail,
                        currentMovil,
                        currentPassword,
                        currentCity,
                        currentCountry);
                    businessOwnerPage.clickOnSave();
                }
            } catch (Exception e){
                Console.WriteLine(e.Message);
            }
            
        }


        [TearDown]
        public void CloseBrowser()
        {
            extent.Flush();
            businessOwnerPage.quitPage();
        }
    }

}