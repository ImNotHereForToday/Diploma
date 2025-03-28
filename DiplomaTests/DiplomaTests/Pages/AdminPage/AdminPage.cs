using DiplomaTests.Pages.PIMPage;
using DiplomaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaTests.Pages.AdminPage
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
        private WebElementWrapper SaveButton => FindElement(By.XPath("//button[@type='submit']"));

        readonly By UserManagmentNavigation = By.XPath("//nav[@aria-label='Topbar Menu']");

        public AdminPage adminPage => new AdminPage();

        public bool UserManagmentNavigationExist()
        {
            return new WebElementWrapper().IsElementDisplayed(UserManagmentNavigation);
        }

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
            DropDown.SelectCustomDropdownOption(optionName);
        }

        public void AssertThatTitleExists(string titleText)
        {
            Assert.That(TitleText.GetText(), Is.EqualTo(titleText));
        }

        private string GetNationality()
        {
            return FirstNationality.GetText().Trim();
        }

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
    }
}
