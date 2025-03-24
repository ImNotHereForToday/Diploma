using DiplomaTests.Utility;
using OpenQA.Selenium;

namespace DiplomaTests.Pages.Authentication
{
    public class LoginPage : PageBase
    {
        private WebElementWrapper GetUsername => FindElement(By.XPath("(//p[@class='oxd-text oxd-text--p'])[1]"));
        private WebElementWrapper GetPassword => FindElement(By.XPath("(//p[@class='oxd-text oxd-text--p'])[2]"));
        private WebElementWrapper UsernameField => FindElement(By.XPath("//input[@name='username']"));
        private WebElementWrapper PasswordField => FindElement(By.XPath("//input[@name='password']"));
        private WebElementWrapper LoginButton => FindElement(By.XPath("//button[normalize-space()='Login']"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterUsername()
        {
            var username = GetUsername.GetText().Replace("Username : ", "").Trim();
            UsernameField.SendKeys(username);
        }

        public void EnterUsername(string Username)
        {
            UsernameField.SendKeys(Username);
        }

        public void EnterPassword()
        {
            var password = GetPassword.GetText().Replace("Password : ", "").Trim();
            PasswordField.SendKeys(password);
        }

        public void EnterPassword(string Password)
        {
            PasswordField.SendKeys(Password);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public void GetInvalidLoginMessage()
        {
            IsElementDisplayed(By.XPath("//p[text()='Invalid credentials']"));
        }
    }
}
