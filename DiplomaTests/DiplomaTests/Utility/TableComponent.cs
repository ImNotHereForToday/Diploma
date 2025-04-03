using DiplomaTests.Pages;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Components
{
    public class TableComponent : PageBase
    {
        private readonly string tableXPath;
        private WebElementWrapper DeleteButton => FindElement(By.XPath("//i[@class='oxd-icon bi-trash-fill oxd-button-icon']"));
        private WebElementWrapper ConfrimDeletion => FindElement(By.XPath("//i[@class='oxd-icon bi-trash oxd-button-icon']"));

        public TableComponent(string customXPath = "//div[@role='table']")
        {
            this.tableXPath = customXPath;
        }

        private WebElementWrapper TableElement => FindElement(By.XPath(tableXPath));

        public WebElementWrapper GetRowByColumnValue(string columnValue)
        {
            string xpath = $".//div[@role='row' and .//div[text()='{columnValue}']]";

            return TableElement.FindElement(By.XPath(xpath));
        }

        public bool DoesRowExist(string columnValue)
        {
            try
            {
                return GetRowByColumnValue(columnValue).IsDisplayed();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickActionButtonInRow(string columnValue, string buttonIconClass)
        {
            var row = GetRowByColumnValue(columnValue);
            WebElementWrapper actionButton = row.FindElement(By.XPath($".//i[contains(@class, '{buttonIconClass}')]"));
            actionButton.Click();
        }

        public void SelectCheckboxInRow(string columnValue)
        {
            var row = GetRowByColumnValue(columnValue);
            WebElementWrapper checkbox = row.FindElement(By.XPath(".//label"));
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }
        }

        public void DeleteSelectedRows()
        {
            DeleteButton.Click();
            ConfrimDeletion.Click();
        }
    }
}
