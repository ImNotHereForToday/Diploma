using DiplomaTests.Pages.Authentication;
using DiplomaTests.Pages.HomePage;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected HomePage homePage;
        protected BrowserType browserType;

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
