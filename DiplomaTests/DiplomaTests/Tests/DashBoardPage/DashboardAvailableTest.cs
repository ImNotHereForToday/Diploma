using DiplomaTests.Utility;

namespace DiplomaTests.Tests.DashBoardPage
{
    [TestFixture(BrowserType.Chrome)]
    class DashboardAvailableTest : TestBase
    {
        public DashboardAvailableTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void ValidateDashboardAccess()
        {
            LoginAsValidUser();
            var validateDashboardAccess = homePage.LMN.CLickDashboardMenu("Dashboard");
            validateDashboardAccess.ValidateThatElementsAreDisplayed();
        }
    }
}
