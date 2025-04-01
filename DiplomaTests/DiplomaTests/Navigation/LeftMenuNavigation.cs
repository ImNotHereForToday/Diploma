using DiplomaTests.Pages;
using DiplomaTests.Pages.AdminPage;
using DiplomaTests.Pages.HomePage;
using DiplomaTests.Pages.LeavePage;
using DiplomaTests.Pages.PerformancePage;
using DiplomaTests.Pages.PIMPage;
using DiplomaTests.Pages.RecruitmentPage;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Navigation
{
    public class LeftMenuNavigation : PageBase
    {
        private string MenuName = string.Empty;

        private WebElementWrapper MenuLinks => FindElement(By.XPath($"//ul[@class='oxd-main-menu']//li[normalize-space()='{MenuName}']"));
        private WebElementWrapper NavigationSearch => FindElement(By.XPath($"//nav//input[@placeholder='Search']"));

        public void SeachForNavigationOption(string menuName)
        {
            MenuName = menuName;
            NavigationSearch.SendKeys(menuName);
            Assert.That(MenuLinks.GetText(), Is.EqualTo(menuName));
        }

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

        public PerformacePage CLickPerformanceMenu(string menuName)
        {
            this.MenuName = menuName;
            MenuLinks.Click();

            return new PerformacePage();
        }

        public RecruitmentPage CLickRecruitmentMenu(string menuName)
        {
            this.MenuName = menuName;
            MenuLinks.Click();

            return new RecruitmentPage();
        }

        public LeavePage CLickLeaveMenu(string menuName)
        {
            this.MenuName = menuName;
            MenuLinks.Click();

            return new LeavePage();
        }
    }
}
