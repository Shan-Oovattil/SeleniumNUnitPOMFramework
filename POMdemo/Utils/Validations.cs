using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMdemo.Utils
{
    public class Validations
    {        
        public static void ValidateURL(IWebDriver driver, string expectedUrl, string errorMessage)
        {
            string actualUrl = driver.Url;
            Console.WriteLine(actualUrl);
            Assert.That(actualUrl, Is.EqualTo(expectedUrl), errorMessage);
        }

        public static void ValidateElementIsPresent(IWebDriver driver, By element, string errorMessage)
        {           
            IWebElement findElement = driver.FindElement(element);           
            Assert.That(findElement.Displayed, Is.True, errorMessage);
        }

        public static void ValidateTextInElement(IWebDriver driver, By element, string text, string errorMessage)
        {           
            string elementText = driver.FindElement(element).Text;           
            Console.WriteLine(elementText);
            Assert.That(elementText, Is.EqualTo(text), errorMessage);
        }

        

    }
}
