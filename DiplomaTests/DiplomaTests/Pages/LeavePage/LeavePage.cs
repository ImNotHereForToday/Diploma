using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.LeavePage
{
    public class LeavePage : PageBase
    {
        string currentDay = DateTime.Now.Day.ToString();

        public WebElementWrapper AssignLeaveNav => FindElement(By.XPath("//li[@class='oxd-topbar-body-nav-tab' and normalize-space()='Assign Leave']"));
        public WebElementWrapper InputEmployeeName => FindElement(By.XPath("//input[@placeholder='Type for hints...']"));
        public WebElementWrapper LeaveTypeDropDown => FindElement(By.XPath("//div[@class='oxd-select-text-input']"));
        public WebElementWrapper OpenFromDateCalendar => FindElement(By.XPath("(//input[@placeholder='yyyy-dd-mm'])[1]"));
        private WebElementWrapper SelectCurrentDay => FindElement(By.XPath($"//div[text()='{currentDay}']"));
        private WebElementWrapper ConfirmLeaveButton => FindElement(By.XPath($"//div[@class='orangehrm-modal-footer']//button[@type='button' and normalize-space()='Ok']"));

        readonly By AlertOnCreatingLeave = By.XPath("//div[@class='oxd-toast-start']");

        public LeavePage Leave => new LeavePage();

        public void GoToAssignLeave()
        {
            AssignLeaveNav.Click();
        }

        public void EnterLeaveData(string employeeName , string leaveType)
        {
            InputEmployeeName.SelectCustomDropdownOptionBySendKeys(employeeName);
            LeaveTypeDropDown.SelectCustomDropdownOptionByClick(leaveType);
            OpenFromDateCalendar.Click();
            SelectCurrentDay.Click();
        }

        public void AssignLeave()
        {
            SaveButton.Click();
        }

        public void ConfirmLeaveAssignment()
        {
            ConfirmLeaveButton.Click();
        }

        public void WaitForsuccessfulAlert()
        {
            new WebElementWrapper().IsElementDisplayed(AlertOnCreatingLeave);
        }
    }
}
