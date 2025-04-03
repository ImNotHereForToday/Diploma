using DiplomaTests.Components;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.PerformancePage
{
    public class PerformacePage : PageBase
    {
        private WebElementWrapper ConfigureDropDown => FindElement(By.XPath("//span[@class='oxd-topbar-body-nav-tab-item' and normalize-space()='Configure']"));
        private WebElementWrapper InputKPI => FindElement(By.XPath("//div[@class='oxd-input-group oxd-input-field-bottom-space' and .//label[contains(text(),'Key')]]//input"));
        private WebElementWrapper OpenJobTitleDropDown => FindElement(By.XPath("//div[@class='oxd-select-text-input']"));

        private TableComponent _TableComponent = new TableComponent();

        public void NavigateToKPIs() => ConfigureDropDown.SelectCustomDropdownOptionByClick("KPIs");
        
        public void AddKPI() => AddButton.Click();
        

        public void AddDetails(string kpiName)
        {
            InputKPI.SendKeys(kpiName);
            OpenJobTitleDropDown.SelectCustomDropdownOptionByClick("Automation Tester");
            SaveButton.Click();
        }

        public bool DoesKPIExist(string kpiName) => _TableComponent.DoesRowExist(kpiName);

        public bool DoesKPINotExist(string kpiName, int timeout = 3)
        {
            try
            {
                var wait = BrowserFactory.BrowserFactory.GetWait(timeout);
                var result = wait.Until(driver =>
                {
                    return !_TableComponent.DoesRowExist(kpiName);
                });

                return result;
            }
            catch (WebDriverTimeoutException)
            {

                return true;
            }
            catch(Exception)
            {

                return false;
            }
        }

        public void SelectKpiCheckBox(string kpiName) => _TableComponent.SelectCheckboxInRow(kpiName);

        public void DeleteKpi() => _TableComponent.DeleteSelectedRows();
    }
}
