using DiplomaTests.Utility;

namespace DiplomaTests.Tests.AdminTests
{
    [TestFixture(BrowserType.Chrome)]
    class ValidateAdminFunction : TestBase
    {
        public ValidateAdminFunction(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void AdminFunction()
        {
            LoginAsValidUser();
            var validateAdminFunction = homePage.LMN.CLickAdminMenu("Admin");
            validateAdminFunction.adminPage.UserManagmentNavigationExist();
            validateAdminFunction.adminPage.GoToDropDownLink("span" , "Job" , "Job Titles");
            validateAdminFunction.adminPage.AssertThatTitleExists("Job Titles");
        }
    }
}
