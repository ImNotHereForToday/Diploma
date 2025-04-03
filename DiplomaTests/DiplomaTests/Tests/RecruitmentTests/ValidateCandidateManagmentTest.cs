using DiplomaTests.Models;
using DiplomaTests.Pages.PIMPage;
using DiplomaTests.Utility;

namespace DiplomaTests.Tests.RecruitmentTests
{
    [TestFixture(BrowserType.Chrome)]
    class ValidateCandidateManagmentTest : TestBase
    {
        public ValidateCandidateManagmentTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void ValidateCandidateMangamnet()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            PIMPage addEmployee = new PIMPage();
            LoginAsValidUser();
            var recruitmentPage = homePage.LMN.CLickRecruitmentMenu();
            recruitmentPage.ClickAddButton();
            addEmployee.EnterEmployeeDetails(employee.FirstName, employee.MiddleName, employee.LastName);
            recruitmentPage.InputEmailData("email@email.com");
            recruitmentPage.SaveData();
            recruitmentPage.WaitForsuccessfulAlert();
            recruitmentPage.GoToRecruitmentNavigators("Candidates");
            addEmployee.DoesFieldExists(employee.WholeName);
            addEmployee.DeleteFieldFromList(employee.WholeName);
            addEmployee.SearchForEmployee(employee.FullName);
            addEmployee.SubmitDetails();
            addEmployee.DoesNoRecordsFoundExists();
        }
    }
}
