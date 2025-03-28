using DiplomaTests.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaTests.Tests.AdminTests
{
    [TestFixture(BrowserType.Chrome)]
    class ValidateAdminFunction : TestBase
    {
        public ValidateAdminFunction(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void AdminFunction()
        {
            LoginAsValidUser();
            var validateAdminFunction = homePage.LMN.CLickAdminMenu("Admin");
            validateAdminFunction.adminPage.UserManagmentNavigationExist();
            validateAdminFunction.adminPage.GoToDropDownLink("span" , "Job" , "Job Titles");
            validateAdminFunction.adminPage.AssertThatTitleExists("Job Titles");

        }
    }
}
