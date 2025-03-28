using DiplomaTests.Navigation;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.HomePage
{
    public class HomePage : PageBase
    {
        private WebElementWrapper TitleText => FindElement(By.XPath("//div[@class='oxd-topbar-header-title']"));
        private WebElementWrapper QuickLaunchTable => FindElement(By.XPath("//div[@class='oxd-grid-3 orangehrm-quick-launch']"));

        public LeftMenuNavigation LMN => new LeftMenuNavigation();

        public HomePage() : base()
        {
        }

        public string GetTitleText()
        {
            return TitleText.GetText();
        }

        public void ValidateThatElementsAreDisplayed()
        {
            QuickLaunchTable.IsDisplayed();
        }
    }
}
