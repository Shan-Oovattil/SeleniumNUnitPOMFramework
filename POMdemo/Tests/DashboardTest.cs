using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using POMdemo.Pages;
using POMdemo.Utils;
using POMdemo.Utils.ReportUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POMdemo.Tests
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [Parallelizable]
    public class DashboardTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        readonly string webUserName = "gunjankaushik";
        readonly string webPassword = "Password@123";

        IWebDriver driver;       
        DashboardPage dashboard;
        readonly string initialUrl = "https://demoqa.com/login";       
        readonly ExtentReports extentReports = ExtentService.GetExtent();
        ExtentTest? extentTest;
        readonly string errorMessageOfLogout = "Logout is missing. Invalid Url?";
        readonly string expectedUrl = "https://demoqa.com/login";

        [SetUp]
        public void RunBeforeTest()
        {
            driver = new TWebDriver();
            BasicMethods.MaximizeWindow(driver);
            BasicMethods.Navigate(driver, initialUrl);            
            BasicMethods.ApplyImplicitWait(driver);

            dashboard = new DashboardPage(driver);
        }

        // set priority
        [Test, Order(1)]
        public void Test001_DashboardPage_ListOfBooks()
        {
            string methodName = MethodBase.GetCurrentMethod().Name;

            // Report
            extentTest = extentReports.CreateTest("Test001_DashboardPage_ListOfBooks", "Test for List-Of-Books from Dashboard Page");
            // Log
            extentTest.Log(Status.Info, "Starting..Test001_DashboardPage_ListOfBooks..");
            // Screen-Capture
            BasicMethods.CaptureScreen(driver, methodName,"One", ".png");

            //dashboard.EnterLoginDetails(webUserName, webPassword);
            BasicMethods.EnterLoginDetails(driver, dashboard.userName, dashboard.password, dashboard.login, webUserName, webPassword);
            Validations.ValidateElementIsPresent(driver, dashboard.loggedInStatus, errorMessageOfLogout);

           // BasicMethods.Navigate(driver, url);

            if (dashboard.CheckDashboardPageResultsBooksList())
            {
                Console.WriteLine(dashboard.CheckDashboardPageResultsBooksList());
            }

            extentTest.Log(Status.Info, expectedUrl);
            BasicMethods.CaptureScreen(driver, methodName, "Two", ".png");
            extentTest.Log(Status.Info, "Ending..Test001_DashboardPage_ListOfBooks..");
            extentReports.Flush();
        }

        [Test, Order(2)]
        public void Test002_DashboardPage_ClickLogOutLink()
        {
            string methodName = MethodBase.GetCurrentMethod().Name;

            // Report
            extentTest = extentReports.CreateTest("Test002_DashboardPage_ClickLogOutLink", "Test for LogOut from Dashboard Page");
            // Log
            extentTest.Log(Status.Info, "Starting..Test002_DashboardPage_ClickLogOutLink..");
            // Screen-Capture
            BasicMethods.CaptureScreen(driver, methodName, "One", ".png");

            //dashboard.EnterLoginDetails(webUserName, webPassword);
            BasicMethods.EnterLoginDetails(driver, dashboard.userName, dashboard.password, dashboard.login, webUserName, webPassword);
            Validations.ValidateElementIsPresent(driver, dashboard.loggedInStatus, errorMessageOfLogout);

            Thread.Sleep(2000);

            if (dashboard.CheckDashboardPageResultsBooksList())
            {
                dashboard.ClickLogOut();
                Thread.Sleep(2000);
            }

            extentTest.Log(Status.Info, expectedUrl);
            BasicMethods.CaptureScreen(driver, methodName, "Two", ".png");
            extentTest.Log(Status.Info, "Ending..Test002_DashboardPage_ClickLogOutLink..");
            extentReports.Flush();
        }


        [TearDown]
        public void RunAfterTest()
        {
            Thread.Sleep(5000);           
            BasicMethods.QuitWindows(driver);
        }



    }
}
