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
            var leavePage = homePage.LMN.CLickLeaveMenu("Leave");
            leavePage.Leave.GoToAssignLeave();
            leavePage.Leave.EnterLeaveData("DontDelete DontDelete DontDelete" , "CAN - Vacation");
            leavePage.Leave.AssignLeave();
            leavePage.Leave.ConfirmLeaveAssignment();
            leavePage.Leave.WaitForsuccessfulAlert();
        }
    }
}
