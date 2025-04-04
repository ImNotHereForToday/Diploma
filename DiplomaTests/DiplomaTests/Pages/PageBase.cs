using DiplomaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DiplomaTests.Pages
{
    public class PageBase
    {
        public WebElementWrapper AddButton => FindElement(By.XPath("//i[@class='oxd-icon bi-plus oxd-button-icon']"));
        public WebElementWrapper SaveButton => FindElement(By.XPath("//button[@type='submit']"));

        protected IWebDriver Driver = BrowserFactory.BrowserFactory.Driver;

        public PageBase()
        {
        }

        public WebElementWrapper FindElement(By locator, int timeoutInSeconds = 10)
        {
            var element = WaitForElementToBeVisible(locator, timeoutInSeconds);

            return new WebElementWrapper(element);
        }

        private IWebElement WaitForElementToBeVisible(By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));

            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
