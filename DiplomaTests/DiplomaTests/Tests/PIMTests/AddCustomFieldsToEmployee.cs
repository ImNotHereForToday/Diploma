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
            var addNewEmployeePage = homePage.LMN.CLickPIMMenu();
            addNewEmployeePage.GoToCustomFields();
            addNewEmployeePage.ClickAddButton();
            addNewEmployeePage.FillOutCustomFieldForm(fieldName);
            addNewEmployeePage.SubmitDetails();
            addNewEmployeePage.DoesFieldExists(fieldName);
            addNewEmployeePage.DeleteFieldFromList(fieldName);
            addNewEmployeePage.DoesRecordNotExist(fieldName);
        }
    }
}
