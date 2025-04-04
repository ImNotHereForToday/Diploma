using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Threading;

namespace DiplomaTests.Utility
{
    public class WebElementWrapper
    {
        private readonly IWebElement element;

        public WebElementWrapper(IWebElement element)
        {
            this.element = element ?? throw new ArgumentNullException(nameof(element));
        }

        public WebElementWrapper()
        {
        }

        public void Click()
        {
            if (element.Displayed && element.Enabled && element.Size.Height > 0)
            {
                element.Click();
            }
            else
            {
                throw new InvalidOperationException("Element is not clickable.");
            }
        }

        public void SendKeys(string value)
        {
            if (element.Displayed && element.Enabled)
            {
                //element.Clear();
                if (!string.IsNullOrEmpty(element.GetAttribute("value")))
                {
                    var wait = BrowserFactory.BrowserFactory.GetWait();
                    element.SendKeys(Keys.Control + "a");
                    element.SendKeys(Keys.Delete);
                    wait.Until(driver => string.IsNullOrEmpty(element.GetAttribute("value")));
                }
                element.SendKeys(value);
            }
            else
            {
                throw new InvalidOperationException("Element is not interactable.");
            }
        }

        public string GetText()
        {
            if (element.Displayed && element.Enabled)
            {
                return element.Text;
            }
            else
            {
                throw new InvalidOperationException("Element not found.");
            }
        }

        public bool IsDisplayed()
        {
            if (!element.Displayed)
            {
                throw new Exception("Element is not displayed.");
            }

            return true;
        }

        public void SelectByText(string text)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(text);
        }

        public void SelectByValue(string value)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByValue(value);
        }

        public bool IsElementDisplayed(By by, int timeout = 5)
        {
            try
            {
                var wait = BrowserFactory.BrowserFactory.GetWait(timeout);
                var elements = wait.Until(ExpectedConditions.ElementIsVisible(by));
                return elements.Displayed;
            }
            catch (WebDriverTimeoutException)
            {

                return false;
            }
        }

        public void SelectCustomDropdownOptionByClick(string optionText)
        {
            string xpath = $".//a[@role='menuitem' and normalize-space(text())='{optionText}'] | .//div[@role='option' and .//span[normalize-space(text())='{optionText}']]";
            var wait = BrowserFactory.BrowserFactory.GetWait();
            element.Click();
            IWebElement selectedOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            selectedOption.Click();
        }

        public void SelectCustomDropdownOptionBySendKeys(string optionText)
        {
            string xpath = $".//a[@role='menuitem' and normalize-space(text())='{optionText}'] | .//div[@role='option' and .//span[normalize-space(text())='{optionText}']]";
            var wait = BrowserFactory.BrowserFactory.GetWait();
            element.SendKeys(optionText);
            IWebElement selectedOption = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            selectedOption.Click();
        }

        public WebElementWrapper FindElement(By by)
        {
            var wait = BrowserFactory.BrowserFactory.GetWait();
            wait.Until(ExpectedConditions.ElementIsVisible(by));

            return new WebElementWrapper(element.FindElement(by));
        }

        public bool Selected
        {
            get
            {
                try
                {
                    return element.Selected;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Not selected", ex);
                }
            }
        }
    }
}
