using DiplomaTests.Pages;
using DiplomaTests.Pages;
using DiplomaTests.Pages.HomePage;
using DiplomaTests.Pages.LeavePage;
using DiplomaTests.Pages.PerformancePage;
using DiplomaTests.Pages.PIMPage;
using DiplomaTests.Pages.RecruitmentPage;
using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Navigation
{
    public static class MenuConstants
    {
        public const string PIM = "PIM";
        public const string ADMIN = "Admin";
        public const string DASHBOARD = "Dashboard";
        public const string PERFORMANCE = "Performance";
        public const string RECRUITMENT = "Recruitment";
        public const string LEAVE = "Leave";
    }

    public class LeftMenuNavigation : PageBase
    {
        private const string menuItem = "//ul[@class='oxd-main-menu']//li[normalize-space()='{0}']";
        private const string NavigationSearchXPath = "//nav//input[@placeholder='Search']";

        private WebElementWrapper GetMenuElement(string menuName) => FindElement(By.XPath(string.Format(menuItem, menuName)));
        
        public void SeachForNavigationOption(string menuName)
        {
            var navigationSearch = FindElement(By.XPath(NavigationSearchXPath));
            navigationSearch.SendKeys(menuName);
            Assert.That(GetMenuElement(menuName).GetText(), Is.EqualTo(menuName));
        }

        public PIMPage CLickPIMMenu()
        {
            GetMenuElement(MenuConstants.PIM).Click();

            return new PIMPage();
        }

        public AdminPage CLickAdminMenu()
        {
            GetMenuElement(MenuConstants.ADMIN).Click();

            return new AdminPage();
        }

        public HomePage CLickDashboardMenu()
        {
            GetMenuElement(MenuConstants.DASHBOARD).Click();

            return new HomePage();
        }

        public PerformacePage CLickPerformanceMenu()
        {
            GetMenuElement(MenuConstants.PERFORMANCE).Click();

            return new PerformacePage();
        }

        public RecruitmentPage CLickRecruitmentMenu()
        {
            GetMenuElement(MenuConstants.RECRUITMENT).Click();

            return new RecruitmentPage();
        }

        public LeavePage CLickLeaveMenu()
        {
            GetMenuElement(MenuConstants.LEAVE).Click();

            return new LeavePage();
        }
    }
}
