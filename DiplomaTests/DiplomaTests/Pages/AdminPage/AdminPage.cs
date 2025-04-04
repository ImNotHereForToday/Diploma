using DiplomaTests.Components;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages
{
    public class AdminPage : PageBase
    {
        private object NavigationName;
        private object Attribute;

        private WebElementWrapper DropDown => FindElement(By.XPath($"//{Attribute}[@class='oxd-topbar-body-nav-tab-item' and normalize-space()='{NavigationName}']"));
        private WebElementWrapper TitleText => FindElement(By.XPath("//div[@class='orangehrm-header-container']//h6"));
        private WebElementWrapper FirstNationality => FindElement(By.XPath("(//div[@role='cell'])[2]"));
        private WebElementWrapper FirstEditNationalityButton => FindElement(By.XPath("(//div[@class='oxd-table-cell-actions'])[1]//button[@type='button'][2]"));
        private WebElementWrapper EditNationalityName => FindElement(By.XPath("//div[@class='orangehrm-card-container']//input[@class='oxd-input oxd-input--active']"));
        private WebElementWrapper InputJobTitle => FindElement(By.XPath("//div[@class='oxd-form-row']//input[@class='oxd-input oxd-input--active']"));
        private WebElementWrapper SearchForAdminUser => FindElement(By.XPath("//div[@class='oxd-table-filter-area']//input[@class='oxd-input oxd-input--active']"));

        readonly By UserManagmentNavigation = By.XPath("//nav[@aria-label='Topbar Menu']");
        private TableComponent _TableComponent = new TableComponent();

        public bool UserManagmentNavigationExist() => new WebElementWrapper().IsElementDisplayed(UserManagmentNavigation);
        

        public void GoToNavigationLink(string attribute , string navName)
        {
            this.Attribute = attribute;
            this.NavigationName = navName;
            DropDown.Click();
        }

        public void GoToDropDownLink(string attribute ,string navName , string optionName)
        {
            this.Attribute = attribute;
            this.NavigationName = navName;
            DropDown.SelectCustomDropdownOptionByClick(optionName);
        }

        public void AssertThatTitleExists(string titleText) => Assert.That(TitleText.GetText(), Is.EqualTo(titleText));

        private string GetNationality() => FirstNationality.GetText().Trim();

        private void EditNationality(string newValue)
        {
            FirstEditNationalityButton.Click();
            EditNationalityName.SendKeys(newValue);
            SaveButton.Click();
        }

        private void AssertNationality(string expectedValue)
        {
            var wait = BrowserFactory.BrowserFactory.GetWait();
            string actualText = wait.Until(driver => FirstNationality.GetText().Trim());

            if (!actualText.Equals(expectedValue))
            {
                throw new Exception($"Nationality update failed! Expected: {expectedValue}, Found: {actualText}");
            }
        }

        public void EditNationalityAndVerify()
        {
            string originalText = GetNationality();
            EditNationality(originalText + "n");
            AssertNationality(originalText + "n");
            EditNationality(originalText);
            AssertNationality(originalText);
        }

        public void AddJobTitle() => AddButton.Click();

        public void FillOutJobTitleForm(string jobTitle)
        {
            InputJobTitle.SendKeys(jobTitle);
            SaveButton.Click();
        }

        public bool DoesJobTitleNotExist(string jobTitle, int timeout = 3)
        {
            try
            {
                var wait = BrowserFactory.BrowserFactory.GetWait(timeout);
                var result = wait.Until(driver =>
                {
                    return !_TableComponent.DoesRowExist(jobTitle);
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

        public void SelectJobTitleCheckBox(string jobTitle) => _TableComponent.SelectCheckboxInRow(jobTitle);

        public void DeleteJobTitle() => _TableComponent.DeleteSelectedRows();

        public void SearchForUser(string userName) => SearchForAdminUser.SendKeys(userName);

        public bool DoesUserExist(string username) => _TableComponent.DoesRowExist(username);
    }
}
