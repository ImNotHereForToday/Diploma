﻿using DiplomaTests.Utility;

namespace DiplomaTests.Tests
{

    [TestFixture(BrowserType.Chrome)]
    public class LoginTest : TestBase
    {
        public LoginTest(BrowserType browser) : base(browser)
        {
        }

        [Test , Order(1)]
        public void ValidUserCanLogin()
        {
            LoginAsValidUser();
        }

        [Test, Order(2)]
        public void InvalidUserCannotLogin()
        {
            loginPage.EnterUsername("aaaa");
            loginPage.EnterPassword("bbbb");
            loginPage.ClickLoginButton();
            loginPage.GetInvalidLoginMessage();
        }
    }
}
