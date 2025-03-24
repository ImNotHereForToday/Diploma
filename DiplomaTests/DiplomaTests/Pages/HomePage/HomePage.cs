using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.HomePage
{
    public class HomePage : PageBase
    {
        private string MenuName = string.Empty;

        public WebElementWrapper TitleText => FindElement(By.XPath("//div[@class='oxd-topbar-header-title']"));
        public WebElementWrapper MenuLinks => FindElement(By.XPath($"//ul[@class='oxd-main-menu']//li[normalize-space()='{MenuName}']"));

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public string GetTitleText()
        {
            return TitleText.GetText();
        }

        public void ClickMenuLinks(string menuName)
        {
            this.MenuName = menuName;
            MenuLinks.Click();
        }
    }
}
