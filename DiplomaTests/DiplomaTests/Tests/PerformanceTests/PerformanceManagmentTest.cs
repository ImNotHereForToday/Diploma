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
            var PerformacePage = homePage.LMN.CLickPerformanceMenu("Performance");
            PerformacePage.Performance.NavigateToKPIs();
            PerformacePage.Performance.AddKPI();
            PerformacePage.Performance.AddDetails(kpiName);
            PerformacePage.Performance.DoesKPIExist(kpiName);
            PerformacePage.Performance.SelectKpiCheckBox(kpiName);
            PerformacePage.Performance.DeleteKpi();
            PerformacePage.Performance.DoesKPINotExist(kpiName);
        }
    }
}
