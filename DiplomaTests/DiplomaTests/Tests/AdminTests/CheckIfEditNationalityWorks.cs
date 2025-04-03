using DiplomaTests.Utility;

namespace DiplomaTests.Tests.AdminTests
{
    [TestFixture(BrowserType.Chrome)]
    class CheckIfEditNationalityWorks : TestBase
    {
        public CheckIfEditNationalityWorks(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void EditNationality()
        {
            LoginAsValidUser();
            var validateAdminFunction = homePage.LMN.CLickAdminMenu();
            validateAdminFunction.UserManagmentNavigationExist();
            validateAdminFunction.GoToNavigationLink("a" , "Nationalities");
            validateAdminFunction.EditNationalityAndVerify();
        }
    }
}
