using DiplomaTests.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaTests.Tests.AdminTests
{
    [TestFixture(BrowserType.Chrome)]
    class CheckIfEditNationalityWorks : TestBase
    {
        public CheckIfEditNationalityWorks(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void EditNationality()
        {
            LoginAsValidUser();
            var validateAdminFunction = homePage.LMN.CLickAdminMenu("Admin");
            validateAdminFunction.adminPage.UserManagmentNavigationExist();
            validateAdminFunction.adminPage.GoToNavigationLink("a" , "Nationalities");
            validateAdminFunction.adminPage.EditNationalityAndVerify();
        }
    }
}
