using OpenQA.Selenium;

namespace DiplomaTests.Utility
{
    public class WebElementWrapper
    {
        private readonly IWebElement element;

        public WebElementWrapper(IWebElement element)
        {
            this.element = element ?? throw new ArgumentNullException(nameof(element));
        }

        public void Click()
        {
            if (element.Displayed && element.Enabled)
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
                element.Clear();
                element.SendKeys(value);
            }
            else
            {
                throw new InvalidOperationException("Element is not interactable.");
            }
        }

        public string GetText()
        {
            return element.Text;
        }

        public bool IsDisplayed()
        {
            return element.Displayed;
        }
    }
}
