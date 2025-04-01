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
            var VacancyName = "AaAaA";
            var navigationName = "Vacancies";
            LoginAsValidUser();
            var recruitmentPage = homePage.LMN.CLickRecruitmentMenu("Recruitment");
            recruitmentPage.Recruitment.GoToRecruitmentNavigators(navigationName);
            recruitmentPage.Recruitment.ClickAddButton();
            recruitmentPage.Recruitment.InputData(VacancyName , "DontDelete DontDelete DontDelete");
            recruitmentPage.Recruitment.SaveData();
            recruitmentPage.Recruitment.WaitForsuccessfulAlert();
            recruitmentPage.Recruitment.GoToRecruitmentNavigators(navigationName);
            recruitmentPage.Recruitment.DoesVacancyExist(VacancyName);
            recruitmentPage.Recruitment.SelectVacancyCheckBox(VacancyName);
            recruitmentPage.Recruitment.DeleteVacancy();
            recruitmentPage.Recruitment.GoToRecruitmentNavigators(navigationName);
            recruitmentPage.Recruitment.DoesVacancyNotExist(VacancyName);

        }
    }
}
