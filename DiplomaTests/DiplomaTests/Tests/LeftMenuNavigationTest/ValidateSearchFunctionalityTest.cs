using DiplomaTests.Utility;

namespace DiplomaTests.Tests.LeftMenuNavigationTest
{
    [TestFixture(BrowserType.Chrome)]
    class ValidateSearchFunctionalityTest : TestBase
    {
        public ValidateSearchFunctionalityTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void ValidateSearchFunctionality()
        {
            LoginAsValidUser();
            homePage.LMN.SeachForNavigationOption("Admin");
        }
    }
}
