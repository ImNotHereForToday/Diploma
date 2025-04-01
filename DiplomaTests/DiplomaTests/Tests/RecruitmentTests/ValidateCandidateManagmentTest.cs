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
            var recruitmentPage = homePage.LMN.CLickRecruitmentMenu("Recruitment");
            recruitmentPage.Recruitment.ClickAddButton();
            addEmployee.EmployeeDetails.EnterEmployeeDetails(employee.FirstName, employee.MiddleName, employee.LastName);
            recruitmentPage.Recruitment.InputEmailData("email@email.com");
            recruitmentPage.Recruitment.SaveData();
            recruitmentPage.Recruitment.WaitForsuccessfulAlert();
            recruitmentPage.Recruitment.GoToRecruitmentNavigators("Candidates");
            addEmployee.EmployeeDetails.DoesFieldExists(employee.WholeName);
            addEmployee.EmployeeDetails.DeleteFieldFromList(employee.WholeName);
            addEmployee.EmployeeDetails.SearchForEmployee(employee.FullName);
            addEmployee.EmployeeDetails.SubmitDetails();
            addEmployee.EmployeeDetails.DoesNoRecordsFoundExists();
        }
    }
}
