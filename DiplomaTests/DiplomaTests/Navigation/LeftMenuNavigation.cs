using DiplomaTests.Pages;
using DiplomaTests.Pages.AdminPage;
using DiplomaTests.Pages.HomePage;
using DiplomaTests.Pages.PIMPage;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Navigation
{
    public class LeftMenuNavigation : PageBase
    {
        private string MenuName = string.Empty;

        private WebElementWrapper MenuLinks => FindElement(By.XPath($"//ul[@class='oxd-main-menu']//li[normalize-space()='{MenuName}']"));

        public PIMPage CLickPIMMenu(string menuName)
        {
            this.MenuName = menuName;
            MenuLinks.Click();

            return new PIMPage();
        }

        public AdminPage CLickAdminMenu(string menuName)
        {
            this.MenuName = menuName;
            MenuLinks.Click();

            return new AdminPage();
        }

        public HomePage CLickDashboardMenu(string menuName)
        {
            this.MenuName = menuName;
            MenuLinks.Click();

            return new HomePage();
        }

    }
}
