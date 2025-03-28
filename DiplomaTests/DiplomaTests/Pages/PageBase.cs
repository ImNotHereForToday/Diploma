using DiplomaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DiplomaTests.Pages
{
    public class PageBase
    {
        protected IWebDriver Driver = BrowserFactory.BrowserFactory.Driver;

        public PageBase()
        {
        }

        protected WebElementWrapper FindElement(By locator, int timeoutInSeconds = 10)
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
