using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.Authentication
{
    public class LogoutPage : PageBase
    {
        private WebElementWrapper BurgerButton => FindElement(By.XPath("//li[@class='oxd-userdropdown']"));
        private WebElementWrapper LogoutButton => FindElement(By.XPath("//a[normalize-space()='Logout']"));
        private WebElementWrapper LoginTitle => FindElement(By.XPath("//h5[@class='oxd-text oxd-text--h5 orangehrm-login-title']"));

        public LogoutPage() : base()
        {
        }

        public void OpenBurgerDropDown() => BurgerButton.Click();
        
        public void ClickLogoutButton() => LogoutButton.Click();
        
        public void VerifyLoginTitle() => Assert.That(LoginTitle.GetText(), Is.EqualTo("Login"));
    }
}
