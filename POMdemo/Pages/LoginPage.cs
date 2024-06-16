using OpenQA.Selenium;
using POMdemo.Utils;

namespace POMdemo.Pages
{
    public class LoginPage
    {
        readonly IWebDriver driver;

        #region Locators

        public By userName = By.Id("userName");
        public By password = By.Id("password");
        public By login = By.Id("login");
        public By loggedInStatus = By.XPath("//button[@id='submit' and text()='Log out']");

        #endregion


        #region Constructor
        
        public LoginPage(IWebDriver drv)
        {
            this.driver = drv;
        }

        #endregion


        #region Public Methods

        //public void EnterLoginDetails(string webUserName, string webPassword)
        //{
        //    BasicMethods.SendTheKeys(driver, userName, webUserName);
        //    BasicMethods.SendTheKeys(driver, password, webPassword);
        //    BasicMethods.ClickAnElement(driver, login);            
        //}

        //public void EnterNewUserDetails()
        //{

        //}

        #endregion


    }
}
