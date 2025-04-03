using DiplomaTests.Utility;

namespace DiplomaTests.Tests.AuthenticationTests
{
    [TestFixture(BrowserType.Chrome)]
    class ForgotPasswordTest : TestBase
    {
        public ForgotPasswordTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void ForgotPassword()
        {
            const string ForgotPasswordSuccess = "Reset Password link sent successfully";
            loginPage.ClickForgotPasswordButton();
            loginPage.EnterUsername("admin123");
            loginPage.ClickResetPassword();
            loginPage.AssertConfirmationMessage(ForgotPasswordSuccess);
        }
    }
}
