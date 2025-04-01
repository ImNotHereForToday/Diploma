using DiplomaTests.Utility;

namespace DiplomaTests.Tests.PIMTests
{
    [TestFixture(BrowserType.Chrome)]
    class AddCustomFieldsToEmployee : TestBase
    {
        public AddCustomFieldsToEmployee(BrowserType browser) : base(browser)
        {
        }

        [Test, Order(1)]
        public void AddCustomFieldToEmployee()
        {
            var fieldName = "aAaA";
            LoginAsValidUser();
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu("PIM");
            addNewEmployeePage.EmployeeDetails.GoToCustomFields();
            addNewEmployeePage.EmployeeDetails.ClickAddButton();
            addNewEmployeePage.EmployeeDetails.FillOutCustomFieldForm(fieldName);
            addNewEmployeePage.EmployeeDetails.SubmitDetails();
            addNewEmployeePage.EmployeeDetails.DoesFieldExists(fieldName);
            addNewEmployeePage.EmployeeDetails.DeleteFieldFromList(fieldName);
            addNewEmployeePage.EmployeeDetails.DoesRecordNotExist(fieldName);
        }
    }
}
