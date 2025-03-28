using DiplomaTests.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
