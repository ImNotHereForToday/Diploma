using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.RecruitmentPage
{
    public class RecruitmentPage : PageBase
    {
        private object RecruitmentNavigationName;

        public WebElementWrapper NavigateToVacancies => FindElement(By.XPath($"//nav[@aria-label='Topbar Menu']//li[normalize-space()='{RecruitmentNavigationName}']"));
        public WebElementWrapper InputVacancieName => FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and .//label[contains(text(),'Vacancy Name')]]//input"));
        public WebElementWrapper InputHiringManager => FindElement(By.XPath("//input[@placeholder='Type for hints...']"));
        private WebElementWrapper OpenJobTitleDropDown => FindElement(By.XPath("//div[@class='oxd-select-text-input']"));
        private WebElementWrapper InputEmail => FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and .//label[contains(text(),'Email')]]//input"));

        readonly By AlertOnCreatingVacancy = By.XPath("//div[@class='oxd-toast-start']");

        public RecruitmentPage Recruitment => new RecruitmentPage();
        private TableHelper _tableHelper = new TableHelper();

        public void GoToRecruitmentNavigators(string navigationName)
        {
            this.RecruitmentNavigationName = navigationName;
            NavigateToVacancies.Click();
        }

        public void ClickAddButton()
        {
            AddButton.Click();
        }

        public void InputData(string vacancieName, string hiringManager)
        {
            InputVacancieName.SendKeys(vacancieName);
            InputHiringManager.SelectCustomDropdownOptionBySendKeys(hiringManager);
            OpenJobTitleDropDown.SelectCustomDropdownOptionByClick("Automaton Tester");
        }

        public void SaveData()
        {
            SaveButton.Click();
        }

        public void WaitForsuccessfulAlert()
        {
            new WebElementWrapper().IsElementDisplayed(AlertOnCreatingVacancy);
        }

        public bool DoesVacancyExist(string vacancyName)
        {
            var result = _tableHelper.DoesRowExist(vacancyName);

            return result;
        }

        public void SelectVacancyCheckBox(string vacancyName)
        {
            _tableHelper.SelectCheckboxInRow(vacancyName);
        }

        public void DeleteVacancy()
        {
            _tableHelper.DeleteSelectedRows();
        }

        public bool DoesVacancyNotExist(string vacancyName, int timeout = 3)
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

        public void InputEmailData(string email)
        {
            InputEmail.SendKeys(email);
        }
    }
}
