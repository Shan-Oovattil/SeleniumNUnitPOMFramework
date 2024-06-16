using OpenQA.Selenium;
using POMdemo.Utils;


namespace POMdemo.Pages
{
    public class HomePage
    {
        readonly IWebDriver driver;

        #region Locators for Home-Page

        readonly By loginButton = By.Id("login");

        #endregion


        #region Constructor
        public HomePage(IWebDriver drv) 
        {
            this.driver = drv;
        }
        #endregion


        #region Public Methods
       
        public void ClickLogin()
        {           
            BasicMethods.ClickAnElement(driver, loginButton);            
        }

        #endregion

    }

}
