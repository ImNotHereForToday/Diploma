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
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu();
            addNewEmployeePage.ClickAddButton();
            addNewEmployeePage.EnterEmployeeDetails(employee.FirstName, employee.MiddleName, employee.LastName);
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.AssertSuccessfullyAddedEmployeeAlert();
            addNewEmployeePage.GoToEmployeeListPage();
            addNewEmployeePage.SearchForEmployee(employee.FullName);
            addNewEmployeePage.SelectEmployeeFromDropDown();
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesFieldExists(employee.FullName);
        }

        [Test, Order(2)]
        public void AssignSkillToEmployee()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu();
            addNewEmployeePage.GoToEmployeeListPage();
            addNewEmployeePage.SearchForEmployee(employee.FullName);
            addNewEmployeePage.SelectEmployeeFromDropDown();
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesFieldExists(employee.FullName);
            addNewEmployeePage.EditEmployee(employee.FullName);
            addNewEmployeePage.NavigateToTab("Qualifications");
            addNewEmployeePage.AddSkill();
            addNewEmployeePage.SelectSkill("Java");
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesNewSkillExists();
        }

        [Test, Order(3)]
        public void EditEmployeeDetails()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu();
            addNewEmployeePage.GoToEmployeeListPage();
            addNewEmployeePage.SearchForEmployee(employee.FullName);
            addNewEmployeePage.SelectEmployeeFromDropDown();
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesFieldExists(employee.FullName);
            addNewEmployeePage.EditEmployee(employee.FullName);
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.AssertSuccessfullyAddedEmployeeAlert();
        }

        [Test, Order(4)]
        public void SearchForEmployee()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu();
            addNewEmployeePage.GoToEmployeeListPage();
            addNewEmployeePage.SearchForEmployee(employee.FullName);
            addNewEmployeePage.SelectEmployeeFromDropDown();
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesFieldExists(employee.FullName);
            addNewEmployeePage.SearchForEmployee("12345678");
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesNoRecordsFoundExists();
        }

        [Test, Order(5)]
        public void DeleteEmployee()
        {
            Employee employee = EmployeeData.PredefinedEmployee;
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu();
            addNewEmployeePage.GoToEmployeeListPage();
            addNewEmployeePage.SearchForEmployee(employee.FullName);
            addNewEmployeePage.SelectEmployeeFromDropDown();
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesFieldExists(employee.FullName);
            addNewEmployeePage.DeleteFieldFromList(employee.FullName);
            addNewEmployeePage.SearchForEmployee(employee.FullName);
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesNoRecordsFoundExists();
        }
    }
}
