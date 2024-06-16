using OpenQA.Selenium;
using POMdemo.Utils;

namespace POMdemo.Pages
{
    public class DashboardPage
    {
        readonly IWebDriver driver;

        public By userName = By.Id("userName");
        public By password = By.Id("password");
        public By login = By.Id("login");
        public By loggedInStatus = By.XPath("//button[@id='submit' and text()='Log out']");
        public By books = By.XPath("//div[@class='rt-tr-group']");
        public By logOutClick = By.XPath("//button[@id='submit' and text()='Log out']");

        public DashboardPage(IWebDriver drv)
        {
            this.driver = drv;
        }

        //public void EnterLoginDetails(string webUserName, string webPassword)
        //{
        //    BasicMethods.SendTheKeys(driver, userName, webUserName);
        //    BasicMethods.SendTheKeys(driver, password, webPassword);
        //    BasicMethods.ClickAnElement(driver, login);
        //}

        public bool CheckDashboardPageResultsBooksList()
        {           
            List<IWebElement> listOfBooks = BasicMethods.FindAllElements(driver, books);           

            if (listOfBooks.Count > 0)
                return true;
            else
                return false;
            
        }

        public void ClickLogOut()
        {            
            BasicMethods.ClickAnElement(driver, logOutClick);          
        }


    }
}
