using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.PIMPage
{
    public class PIMPage : PageBase
    {
        private object NameAndMiddleName;
        private object TabName;

        private WebElementWrapper InputFirstName => FindElement(By.XPath("//input[@name='firstName']"));
        private WebElementWrapper InputMiddleName => FindElement(By.XPath("//input[@name='middleName']"));
        private WebElementWrapper InputLastName => FindElement(By.XPath("//input[@name='lastName']"));
        private WebElementWrapper SubmitButton => FindElement(By.XPath("//button[@type='submit']"));
        private WebElementWrapper GoToEmployeeList => FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and normalize-space()='Employee List']"));
        private WebElementWrapper SearchForElmployee => FindElement(By.XPath("(//input[@placeholder='Type for hints...'])[1]"));
        private WebElementWrapper DropDownEmployeeName => FindElement(By.XPath($"//div[@role='option']//span[contains(text(), '{NameAndMiddleName}')]"));
        private WebElementWrapper ConfirmDeleteEmployee => FindElement(By.XPath("//i[@class='oxd-icon bi-trash oxd-button-icon']"));
        private WebElementWrapper NavigationTab => FindElement(By.XPath($"//div[@role='tab' and normalize-space()='{TabName}']"));
        private WebElementWrapper AddSkillButton => FindElement(By.XPath("//div[@class='orangehrm-action-header' and .//h6[normalize-space()='Skills']]//button"));
        private WebElementWrapper OpenSkillDropDown => FindElement(By.XPath("//div[@class='oxd-select-text oxd-select-text--active']"));
        private WebElementWrapper ConfigurationDropDown => FindElement(By.XPath("//span[@class='oxd-topbar-body-nav-tab-item']"));
        private WebElementWrapper InputFieldName => FindElement(By.XPath("//div[@class='orangehrm-card-container']//input"));
        private WebElementWrapper ScreenDropDown => FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and .//label[contains(text(),'Screen')]]//div[@class='oxd-select-text-input']"));
        private WebElementWrapper TypeDropDown => FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and .//label[contains(text(),'Type')]]//div[@class='oxd-select-text-input']"));

        readonly By AlertOnCreatingEmployee = By.XPath("//div[@class='oxd-toast-start']");
        readonly By AlertNoRecordsFound = By.XPath("//div[@aria-live='assertive']");
        readonly By SkillFound = By.XPath("//div[@role='row' and normalize-space()='Java']");

        public PIMPage EmployeeDetails => new PIMPage();

        private TableHelper _tableHelper = new TableHelper();

        public PIMPage() : base()
        {
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public void EnterEmployeeDetails(string FirstName, string MiddleName, string LastName)
        {
            InputFirstName.SendKeys(FirstName);
            InputMiddleName.SendKeys(MiddleName);
            InputLastName.SendKeys(LastName);
        }

        public void SubmitDetails()
        {
            SubmitButton.Click();
        }

        public bool AssertSuccessfullyAddedEmployeeAlert()
        {
            return new WebElementWrapper().IsElementDisplayed(AlertOnCreatingEmployee);
        }

        public void GoToEmployeeListPage()
        {
            GoToEmployeeList.Click();
        }

        public void SearchForEmployee(string EmployeeName)
        {
            NameAndMiddleName = EmployeeName;
            SearchForElmployee.SendKeys(EmployeeName);
        }

        public void SelectEmployeeFromDropDown()
        {
            DropDownEmployeeName.Click();
        }

        public bool DoesFieldExists(string firstAndMiddleName)
        {
            return _tableHelper.DoesRowExist(firstAndMiddleName);
        }

        public bool DoesNoRecordsFoundExists()
        {
            return new WebElementWrapper().IsElementDisplayed(AlertNoRecordsFound);
        }

        public bool DoesRecordNotExist(string vacancyName, int timeout = 3)
        {
            try
            {
                var wait = BrowserFactory.BrowserFactory.GetWait(timeout);
                var result = wait.Until(driver =>
                {
                    return !_tableHelper.DoesRowExist(vacancyName);
                });

                return result;
            }
            catch (WebDriverTimeoutException)
            {
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void DeleteFieldFromList(string employeeFullName)
        {
            _tableHelper.ClickActionButtonInRow(employeeFullName, "bi-trash");
            ConfirmDeleteEmployee.Click();
        }

        public void EditEmployee(string employeeFullName)
        {
            _tableHelper.ClickActionButtonInRow(employeeFullName, "bi-pencil-fill");
        }

        public void NavigateToTab(string tabName)
        {
            this.TabName = tabName;
            NavigationTab.Click();
        }

        public void AddSkill()
        {
            AddSkillButton.Click();
        }

        public void SelectSkill(string skillName)
        {
            OpenSkillDropDown.SelectCustomDropdownOptionByClick(skillName);
        }

        public bool DoesNewSkillExists()
        {
            return new WebElementWrapper().IsElementDisplayed(SkillFound);
        }

        public void GoToCustomFields()
        {
            ConfigurationDropDown.SelectCustomDropdownOptionByClick("Custom Fields");
        }

        public void FillOutCustomFieldForm(string fieldName)
        {
            InputFieldName.SendKeys(fieldName);
            ScreenDropDown.SelectCustomDropdownOptionByClick("Personal Details");
            TypeDropDown.SelectCustomDropdownOptionByClick("Text or Number");
        }
    }
}
