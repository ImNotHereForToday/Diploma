using DiplomaTests.Utility;

namespace DiplomaTests.Tests.LeaveTests
{
    [TestFixture(BrowserType.Chrome)]
    class AssignLeaveTest : TestBase
    {
        public AssignLeaveTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void AssignLeave()
        {
            LoginAsValidUser();
            var leavePage = homePage.LMN.CLickLeaveMenu();
            leavePage.GoToAssignLeave();
            leavePage.EnterLeaveData("DontDelete DontDelete DontDelete" , "CAN - Vacation");
            leavePage.AssignLeave();
            leavePage.ConfirmLeaveAssignment();
            leavePage.WaitForsuccessfulAlert();
        }
    }
}
