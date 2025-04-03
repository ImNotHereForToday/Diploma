using DiplomaTests.Utility;

namespace DiplomaTests.Tests.RecruitmentTests
{
    [TestFixture(BrowserType.Chrome)]
    class ValidateRecruitmentManagmentFunctionalityTest : TestBase
    {
        public ValidateRecruitmentManagmentFunctionalityTest(BrowserType browser) : base(browser)
        {
        }

        [Test]
        public void ValidateRecruitmentManagment()
        {
            var vacancyName = "AaAaA";
            var navigationName = "Vacancies";
            LoginAsValidUser();
            var recruitmentPage = homePage.LMN.CLickRecruitmentMenu();
            recruitmentPage.GoToRecruitmentNavigators(navigationName);
            recruitmentPage.ClickAddButton();
            recruitmentPage.InputData(vacancyName, "DontDelete DontDelete DontDelete");
            recruitmentPage.SaveData();
            recruitmentPage.WaitForsuccessfulAlert();
            recruitmentPage.GoToRecruitmentNavigators(navigationName);
            recruitmentPage.DoesVacancyExist(vacancyName);
            recruitmentPage.SelectVacancyCheckBox(vacancyName);
            recruitmentPage.DeleteVacancy();
            recruitmentPage.GoToRecruitmentNavigators(navigationName);
            recruitmentPage.DoesVacancyNotExist(vacancyName);
        }
    }
}
