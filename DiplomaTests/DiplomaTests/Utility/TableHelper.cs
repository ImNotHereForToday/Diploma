using DiplomaTests.Pages;
using OpenQA.Selenium;

namespace DiplomaTests.Utility
{
    class TableHelper : PageBase
    {
        private WebElementWrapper DeleteButton => FindElement(By.XPath("//i[@class='oxd-icon bi-trash-fill oxd-button-icon']"));
        private WebElementWrapper ConfrimDeletion => FindElement(By.XPath("//i[@class='oxd-icon bi-trash oxd-button-icon']"));

        public WebElementWrapper GetRowByColumnValue(string columnValue)
        {
            string xpath = $"//div[@role='row' and .//div[text()='{columnValue}']]";

            return FindElement(By.XPath(xpath));
        }

        public bool DoesRowExist(string columnValue)
        {
            try
            {
                var value = GetRowByColumnValue(columnValue).IsDisplayed();

                return value;
            }
            catch (NoSuchElementException)
            {

                return false;
            }
        }

        public void ClickActionButtonInRow(string columnValue, string buttonIconClass)
        {
            var row = GetRowByColumnValue(columnValue);
            if (row != null)
            {
                WebElementWrapper actionButton = row.FindElement(By.XPath($".//i[contains(@class, '{buttonIconClass}')]"));
                actionButton.Click();
            }
            else
            {
                throw new Exception($"Row with value '{columnValue}' not found.");
            }
        }

        public void SelectCheckboxInRow(string columnValue)
        {
            var row = GetRowByColumnValue(columnValue);
            if (row != null)
            {
                WebElementWrapper checkbox = row.FindElement(By.XPath(".//label"));
                if (checkbox != null)
                {
                    if (!checkbox.Selected)
                    {
                        checkbox.Click();
                    }
                }
            }
            else
            {
                throw new Exception($"Row with value '{columnValue}' not found.");
            }
        }

        public void DeleteSelectedRows()
        {
            DeleteButton.Click();
            ConfrimDeletion.Click();
        }
    }
}
