using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using POMdemo.Pages;
using POMdemo.Utils;
using POMdemo.Utils.ReportUtils;
using System.Reflection;

namespace POMdemo.Tests
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [Parallelizable]
    public class LoginTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        readonly string webUserName = "gunjankaushik";
        readonly string webPassword = "Password@123";

        IWebDriver driver; 
        LoginPage login;
        readonly string url = "https://demoqa.com/login";
        readonly ExtentReports extentReports = ExtentService.GetExtent();
        ExtentTest? extentTest;
        readonly string errorMessageOfLogout = "Logout is missing. Invalid Url?";
        readonly string expectedUrl = "https://demoqa.com/profile";

        [SetUp]
        public void RunBeforeTest()
        {
            driver = new TWebDriver();
            BasicMethods.MaximizeWindow(driver);
            BasicMethods.Navigate(driver, url);
            BasicMethods.ApplyImplicitWait(driver);

            login = new LoginPage(driver);
        }

        // set priority
        [Test, Order(1)]
        public void Test001_LoginPage_EnterLoginCredentials()
        {
            string methodName = MethodBase.GetCurrentMethod().Name;

            // Report
            extentTest = extentReports.CreateTest("Test001_LoginPage_EnterLoginCredentials", "Test for Entering Login-Credntials from Login-Page");
            // Log
            extentTest.Log(Status.Info, "Starting..Test001_LoginPage_EnterLoginCredentials..");
            // Screen-Capture
            BasicMethods.CaptureScreen(driver, methodName, "One", ".png");

            //login.EnterLoginDetails(webUserName, webPassword);
            
            
            BasicMethods.EnterLoginDetails(driver, login.userName, login.password, login.login, webUserName, webPassword);
            Validations.ValidateElementIsPresent(driver, login.loggedInStatus, errorMessageOfLogout);

            extentTest.Log(Status.Info, expectedUrl);
            BasicMethods.CaptureScreen(driver, methodName, "Two", ".png");
            extentTest.Log(Status.Info, "Ending..Test001_LoginPage_EnterLoginCredentials..");
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
