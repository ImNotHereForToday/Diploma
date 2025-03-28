using DiplomaTests.Navigation;
using DiplomaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V132.Debugger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaTests.Pages.PIMPage
{
    public class PIMPage : PageBase
    {
        private object NameAndMiddleName;
        private object TabName;

        private WebElementWrapper AddButton => FindElement(By.XPath("//i[@class='oxd-icon bi-plus oxd-button-icon']"));
        private WebElementWrapper InputFirstName => FindElement(By.XPath("//input[@name='firstName']"));
        private WebElementWrapper InputMiddleName => FindElement(By.XPath("//input[@name='middleName']"));
        private WebElementWrapper InputLastName => FindElement(By.XPath("//input[@name='lastName']"));
        public WebElementWrapper SubmitButton => FindElement(By.XPath("//button[@type='submit']"));
        private WebElementWrapper GoToEmployeeList => FindElement(By.XPath("//a[@class='oxd-topbar-body-nav-tab-item' and normalize-space()='Employee List']"));
        private WebElementWrapper SearchForElmployee => FindElement(By.XPath("(//input[@placeholder='Type for hints...'])[1]"));
        private WebElementWrapper DropDownEmployeeName => FindElement(By.XPath($"//div[@role='option']//span[contains(text(), '{NameAndMiddleName}')]"));
        private WebElementWrapper DeleteEmployeeButton => FindElement(By.XPath("//i[@class='oxd-icon bi-trash']"));
        private WebElementWrapper ConfirmDeleteEmployee => FindElement(By.XPath("//i[@class='oxd-icon bi-trash oxd-button-icon']"));
        private WebElementWrapper EditEmployeeButton => FindElement(By.XPath("//i[@class='oxd-icon bi-pencil-fill']"));
        private WebElementWrapper NavigationTab => FindElement(By.XPath($"//div[@role='tab' and normalize-space()='{TabName}']"));
        private WebElementWrapper AddSkillButton => FindElement(By.XPath("//div[@class='orangehrm-action-header' and .//h6[normalize-space()='Skills']]//button"));
        private WebElementWrapper OpenSkillDropDown => FindElement(By.XPath("//div[@class='oxd-select-text oxd-select-text--active']"));

        readonly By AlertOnCreatingEmployee = By.XPath("//div[@class='oxd-toast-start']");
        readonly By AlertNoRecordsFound = By.XPath("//div[@aria-live='assertive']");
        readonly By SkillFound = By.XPath("//div[@role='row' and normalize-space()='Java']");
        public PIMPage EmployeeDetails => new PIMPage();

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

        public void InteractWithEmployeeDetails()
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

        public bool DoesEmployeeExists(string firstAndMiddleName)
        {
            WebElementWrapper wrapper = new WebElementWrapper();
            string xpath = $"//div[@role='row' and .//div[text()='{firstAndMiddleName}']]";
            By employeeRow = By.XPath(xpath);

            return wrapper.IsElementDisplayed(employeeRow);
        }

        public bool DoesNoRecordsFoundExists()
        {
            return new WebElementWrapper().IsElementDisplayed(AlertNoRecordsFound);
        }

        public void DeleteEmployeeFromList()
        {
            DeleteEmployeeButton.Click();
            ConfirmDeleteEmployee.Click();
        }

        public void EditEmployee()
        {
            EditEmployeeButton.Click();
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
            OpenSkillDropDown.SelectCustomDropdownOption(skillName);
        }

        public bool DoesNewSkillExists()
        {
            return new WebElementWrapper().IsElementDisplayed(SkillFound);
        }
    }
}
