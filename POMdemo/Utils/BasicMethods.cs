using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace POMdemo.Utils
{
    public class BasicMethods
    {
        public static void Navigate(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static void QuitWindows(IWebDriver driver)
        {
            driver.Quit();
        }

        public static void MaximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void ApplyImplicitWait(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void FindAnElement(IWebDriver driver, By element)
        {
            driver.FindElement(element);
        }

        public static List<IWebElement> FindAllElements(IWebDriver driver, By element) 
        {
            var elements = driver.FindElements(element);
            return elements.ToList();
        }

        public static void ClickAnElement(IWebDriver driver, By element)
        {
            driver.FindElement(element).Click();
        }

        public static void SendTheKeys(IWebDriver driver, By element, string keys) 
        {           
            driver.FindElement(element).SendKeys(keys);           
        }

        public static bool VisibilityOfElement(IWebDriver driver, By element, int timeOut)
        {
            try
            {
                WebDriverWait wait = new (driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.ElementIsVisible(element));
                return true;
            }
            catch(Exception) 
            {
                return false;
            }
        }

        public static bool AlertIsPresent(IWebDriver driver, By element, int timeOut)
        {
            try
            {
                WebDriverWait wait = new (driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.AlertIsPresent());
                return true;
            }
            catch(Exception) 
            {
                return false;
            }
        }

        public static bool ElementExists(IWebDriver driver, By element, int timeOut)
        {
            try
            {
                WebDriverWait wait = new (driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.ElementExists(element));
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public static bool ElementToBeClickable(IWebDriver driver, By element, int timeOut)
        {
            try
            {
                WebDriverWait wait = new (driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        
        public static bool ElementToBeSelected(IWebDriver driver, By element, int timeOut)
        {
            try
            {
                WebDriverWait wait = new (driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.ElementToBeSelected(element));
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool InvisibilityOfElementLocated(IWebDriver driver, By element, int timeOut)
        {
            try
            {
                WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool InvisibilityOfElementWithText(IWebDriver driver, By element, int timeOut, string text)
        {
            try
            {
                WebDriverWait wait = new (driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.InvisibilityOfElementWithText(element, text));
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static void CaptureScreen(IWebDriver driver, string methodName, string fileName, string fileFormat)
        {           
            string finalScreenshotPath = CaptureScreenshot(methodName, fileName, fileFormat);               
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(finalScreenshotPath);
        }

        private static string CaptureScreenshot(string methodName, string fileName, string fileFormat) 
        {
            string currentDir = Directory.GetCurrentDirectory();            
            string dirWithoutBin = currentDir.Split("bin"[0])[0];
            string folderPath = dirWithoutBin + "Screenshot";
           
            if (!Directory.Exists(folderPath))
            {               
                Directory.CreateDirectory(folderPath);                
            }

            string finalFolderPath = (Path.Combine(folderPath, methodName));
            Directory.CreateDirectory(finalFolderPath);
                       
            Console.WriteLine($"Folder-Path: {finalFolderPath}");           
            Console.WriteLine($"File-Name: {fileName}");
            Console.WriteLine($"File-Extension: {fileFormat}");
            

            string fileFinalPath = Path.Combine(finalFolderPath, fileName + fileFormat);
            Console.WriteLine(fileFinalPath);
            return fileFinalPath;         
        }

        public static void EnterLoginDetails(IWebDriver driver, By userNameElement, By passwordElement, By loginButtonElement,  string webUserName, string webPassword)
        {
            // Highlight Code
            //IWebElement userNameEle = driver.FindElement(userNameElement);
            //AddHighlightElement(driver, userNameEle);
            //userNameEle.SendKeys(webUserName);
            //RemoveHighlightElement(driver, userNameEle);
                        
            BasicMethods.SendTheKeys(driver, userNameElement, webUserName);            
          
            BasicMethods.SendTheKeys(driver, passwordElement, webPassword);
                   
            BasicMethods.ClickAnElement(driver, loginButtonElement);
         
        }

        public static void AddHighlightElement(IWebDriver driver, IWebElement ele)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].setAttribute('style', 'background: yellow; border: 2px solid red;');", ele);
        }

        public static void RemoveHighlightElement(IWebDriver driver, IWebElement ele)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].setAttribute('style', 'border: solid 2px white');", ele);
        }

    }
}
