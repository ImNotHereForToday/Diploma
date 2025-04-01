using DiplomaTests.Utility;

namespace DiplomaTests.Tests.AdminTests
{
    [TestFixture(BrowserType.Chrome)]
    class AddJobTitleTest : TestBase
    {
        public AddJobTitleTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void AddJobTitle()
        {
            var jobTitle = "Job Title";
            LoginAsValidUser();
            var validateAdminFunction = homePage.LMN.CLickAdminMenu("Admin");
            validateAdminFunction.adminPage.UserManagmentNavigationExist();
            validateAdminFunction.adminPage.GoToDropDownLink("span", "Job", "Job Titles");
            validateAdminFunction.adminPage.AssertThatTitleExists("Job Titles");
            validateAdminFunction.adminPage.AddJobTitle();
            validateAdminFunction.adminPage.FillOutJobTitleForm(jobTitle);
            validateAdminFunction.adminPage.SelectJobTitleCheckBox(jobTitle);
            validateAdminFunction.adminPage.DeleteJobTitle();
            validateAdminFunction.adminPage.DoesJobTitleNotExist(jobTitle);

        }
    }
}
