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
            var jobTitle = "AaAa";
            LoginAsValidUser();
            var validateAdminFunction = homePage.LMN.CLickAdminMenu();
            validateAdminFunction.UserManagmentNavigationExist();
            validateAdminFunction.GoToDropDownLink("span", "Job", "Job Titles");
            validateAdminFunction.AssertThatTitleExists("Job Titles");
            validateAdminFunction.AddJobTitle();
            validateAdminFunction.FillOutJobTitleForm(jobTitle);
            validateAdminFunction.SelectJobTitleCheckBox(jobTitle);
            validateAdminFunction.DeleteJobTitle();
            validateAdminFunction.DoesJobTitleNotExist(jobTitle);
        }
    }
}
