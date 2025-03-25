using DiplomaTests.Pages.Authentication;
using DiplomaTests.Pages.HomePage;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Tests
{
    public class TestBase
    {
        protected BrowserType browserType;
        protected IWebDriver driver;

        protected LoginPage loginPage;
        protected LogoutPage logoutPage;
        protected HomePage homePage;

        public TestBase(BrowserType browser)
        {
            browserType = browser;
        }

        [SetUp] 
        public void SetUp()
        {
            driver = BrowserFactory.BrowserFactory.CreateDriver(browserType);
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            loginPage = new LoginPage(driver);
            logoutPage = new LogoutPage(driver);
            homePage = new HomePage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Dispose();
        }

        protected void LoginAsValidUser()
        {
            loginPage.EnterUsername();
            loginPage.EnterPassword();
            loginPage.ClickLoginButton();
            Assert.That(homePage.GetTitleText(), Is.EqualTo("Dashboard"));
        }
    }
}
