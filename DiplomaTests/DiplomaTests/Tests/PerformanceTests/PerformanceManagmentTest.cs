using DiplomaTests.Utility;

namespace DiplomaTests.Tests.PerformanceTests
{
    [TestFixture(BrowserType.Chrome)]
    class PerformanceManagmentTest : TestBase
    {
        public PerformanceManagmentTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void ValidatePerformanceManagment()
        {
            var kpiName = "AaAaA";
            LoginAsValidUser();
            var PerformacePage = homePage.LMN.CLickPerformanceMenu();
            PerformacePage.NavigateToKPIs();
            PerformacePage.AddKPI();
            PerformacePage.AddDetails(kpiName);
            PerformacePage.DoesKPIExist(kpiName);
            PerformacePage.SelectKpiCheckBox(kpiName);
            PerformacePage.DeleteKpi();
            PerformacePage.DoesKPINotExist(kpiName);
        }
    }
}
