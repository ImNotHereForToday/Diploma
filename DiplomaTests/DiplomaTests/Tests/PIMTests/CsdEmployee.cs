using DiplomaTests.Navigation;
using DiplomaTests.Pages.PIMPage;
using DiplomaTests.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DiplomaTests.Tests.PIMTests
{
    [TestFixture(BrowserType.Chrome)]
    class CsdEmployee : TestBase
    {
        // CSD = Create , search , delete

        public Employee employee;

        public class Employee
        {
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }
        }

        public CsdEmployee(BrowserType browser) : base(browser)
        {

            employee = new Employee
            {
                FirstName = "John",
                MiddleName = "Doe",
                LastName = "Smith",
                FullName = "John Doe"
            };
        }

        [Test, Order(1)]
        public void AddNewEmployee()
        {
            LoginAsValidUser();
            var addNewEplmoyeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEplmoyeePage.ClickAddButton();
            addNewEplmoyeePage.EmployeeDetails.EnterEmployeeDetails(employee.FirstName, employee.MiddleName, employee.LastName);
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.AssertSuccessfullyAddedEmployeeAlert();
            addNewEplmoyeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEplmoyeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.DoesEmployeeExists(employee.FullName);
        }

        [Test, Order(2)]
        public void AssignSkillToEmployee()
        {
            LoginAsValidUser();
            var addNewEplmoyeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEplmoyeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEplmoyeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.DoesEmployeeExists(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.EditEmployee();
            addNewEplmoyeePage.EmployeeDetails.NavigateToTab("Qualifications");
            addNewEplmoyeePage.EmployeeDetails.AddSkill();
            addNewEplmoyeePage.EmployeeDetails.SelectSkill("Java");
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.DoesNewSkillExists();
        }

        [Test, Order(3)]
        public void SearchForEmployee()
        {
            LoginAsValidUser();
            var addNewEplmoyeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEplmoyeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEplmoyeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.DoesEmployeeExists(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.SearchForEmployee("12345678");
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.DoesNoRecordsFoundExists();
        }

        [Test, Order(4)]
        public void DeleteEmployee()
        {
            LoginAsValidUser();
            var addNewEplmoyeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEplmoyeePage.EmployeeDetails.GoToEmployeeListPage();
            addNewEplmoyeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.SelectEmployeeFromDropDown();
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.DoesEmployeeExists(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.DeleteEmployeeFromList();
            addNewEplmoyeePage.EmployeeDetails.SearchForEmployee(employee.FullName);
            addNewEplmoyeePage.EmployeeDetails.InteractWithEmployeeDetails();
            addNewEplmoyeePage.EmployeeDetails.DoesNoRecordsFoundExists();
        }
    }
}
