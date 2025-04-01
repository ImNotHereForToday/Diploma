using DiplomaTests.Models;
using DiplomaTests.Utility;

namespace DiplomaTests.Tests.PIMTests
{
    [TestFixture(BrowserType.Chrome)]
    class CRUDEmployee : TestBase
    {
        public CRUDEmployee(BrowserType browser) : base(browser)
        {
        }

        [Test, Order(1)]
        public void AddNewEmployee()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEmployeePage.ClickAddButton();
            addNewEmployeePage.EmployeeDetails.EnterEmployeeDetails(employee.FirstName, employee.MiddleName, employee.LastName);
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.AssertSuccessfullyAddedEmployeeAlert();
            addNewEmployeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEmployeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesFieldExists(employee.FullName);
        }

        [Test, Order(2)]
        public void AssignSkillToEmployee()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEmployeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEmployeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesFieldExists(employee.FullName);
            addNewEmployeePage.EmployeeDetails.EditEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.NavigateToTab("Qualifications");
            addNewEmployeePage.EmployeeDetails.AddSkill();
            addNewEmployeePage.EmployeeDetails.SelectSkill("Java");
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesNewSkillExists();
        }

        [Test, Order(3)]
        public void EditEmployeeDetails()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEmployeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEmployeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesFieldExists(employee.FullName);
            addNewEmployeePage.EmployeeDetails.EditEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.AssertSuccessfullyAddedEmployeeAlert();
        }

        [Test, Order(4)]
        public void SearchForEmployee()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEmployeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEmployeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesFieldExists(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SearchForEmployee("12345678");
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesNoRecordsFoundExists();
        }

        [Test, Order(5)]
        public void DeleteEmployee()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEmployeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEmployeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesFieldExists(employee.FullName);
            addNewEmployeePage.EmployeeDetails.DeleteFieldFromList(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesNoRecordsFoundExists();
        }
    }
}
