using DiplomaTests.Pages.Authentication;
using DiplomaTests.Pages.HomePage;
using DiplomaTests.Pages.PIMPage;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Tests
{
    public class TestBase
    {
        protected BrowserType browserType;
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
            BrowserFactory.BrowserFactory.InitializeDriver(browserType);
            BrowserFactory.BrowserFactory.Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            loginPage = new LoginPage();
            logoutPage = new LogoutPage();
            homePage = new HomePage();
        }

        [TearDown]
        public void TearDown()
        {
            BrowserFactory.BrowserFactory.Driver.Dispose();
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
