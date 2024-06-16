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
    public class HomeTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        IWebDriver driver;
        HomePage home;
        readonly string url = "https://demoqa.com/books";   
        readonly ExtentReports extentReports = ExtentService.GetExtent();
        ExtentTest? extentTest;
        readonly string errorMessageOfUrl = "Navigated URL is Wrong.";
        readonly string expectedUrl = "https://demoqa.com/login";


        [SetUp]
        public void RunBeforeTest()
        {
            driver = new TWebDriver();
            BasicMethods.MaximizeWindow(driver);
            BasicMethods.Navigate(driver, url);           
            BasicMethods.ApplyImplicitWait(driver);

            home = new HomePage(driver);
        }

        // set priority
        [Test, Order(1)] 
        public void Test001_HomePage_LoginLinkClick() 
        {
            string methodName = MethodBase.GetCurrentMethod().Name;

            // Report
            extentTest = extentReports.CreateTest("Test001_HomePage_LoginLinkClick", "Test for Login from Home Page");
            // Log
            extentTest.Log(Status.Info, "Starting..Test001_HomePage_LoginLinkClick..");
            // Screen-Capture
            BasicMethods.CaptureScreen(driver, methodName,"One", ".png");
                                   
            home.ClickLogin();            
            Validations.ValidateURL(driver, expectedUrl, errorMessageOfUrl);

            extentTest.Log(Status.Info, expectedUrl);
            BasicMethods.CaptureScreen(driver, methodName, "Two", ".png");            
            extentTest.Log(Status.Info, "Ending..Test001_HomePage_LoginLinkClick..");                       
            extentReports.Flush();                       
        }

        [TearDown] 
        public void RunAfterTest() 
        {           
            BasicMethods.QuitWindows(driver);
        }
    }
}
