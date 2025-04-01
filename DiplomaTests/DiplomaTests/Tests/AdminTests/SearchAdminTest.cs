﻿using DiplomaTests.Utility;

namespace DiplomaTests.Tests.AdminTests
{
    [TestFixture(BrowserType.Chrome)]
    class SearchAdminTest : TestBase
    {
        public SearchAdminTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void SearchAdmin()
        {
            var username = "aaaaa";
            LoginAsValidUser();
            var validateAdminFunction = homePage.LMN.CLickAdminMenu("Admin");
            validateAdminFunction.adminPage.SearchForUser(username);
            validateAdminFunction.adminPage.DoesUserExist(username);

        }
    }
}
