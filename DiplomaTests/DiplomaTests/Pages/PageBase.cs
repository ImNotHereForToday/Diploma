using DiplomaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DiplomaTests.Pages
{
    public class PageBase
    {
        protected IWebDriver Driver;

        public PageBase(IWebDriver driver)
        {
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));
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

        public bool IsElementDisplayed(By locator, int timeout = 5)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                return element.Displayed;
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
        }
    }
}
