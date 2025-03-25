using DiplomaTests.Utility;

namespace DiplomaTests.Tests.AuthenticationsTests
{
    [TestFixture(BrowserType.Chrome)]
    class LogoutTest : TestBase
    {

        public LogoutTest(BrowserType browser) : base(browser)
        {
        }

        [Test, Order(1)]
        public void Logout()
        {
            LoginAsValidUser();
            logoutPage.OpenBurgerDropDown();
            logoutPage.ClickLogoutButton();
            logoutPage.VerifyLoginTitle();
        }
    }
}
