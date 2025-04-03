using DiplomaTests.Utility;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
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
        private WebElementWrapper ForgotPasswordButton => FindElement(By.XPath("//p[@class='oxd-text oxd-text--p orangehrm-login-forgot-header']"));
        private WebElementWrapper ResetPasswordButton => FindElement(By.XPath("//button[@type='submit']"));
        private WebElementWrapper ConfirmationMessageTitle => FindElement(By.XPath("//h6"));
        private WebElementWrapper ErrorMessage => FindElement(By.XPath("//p[text()='Invalid credentials']"));


        public LoginPage() : base()
        {
        }

        public void EnterUsername()
        {
            var username = GetUsername.GetText().Replace("Username : ", "").Trim();
            UsernameField.SendKeys(username);
        }

        public void EnterUsername(string Username) => UsernameField.SendKeys(Username);

        public void EnterPassword()
        {
            var password = GetPassword.GetText().Replace("Password : ", "").Trim();
            PasswordField.SendKeys(password);
        }

        public void EnterPassword(string Password) => PasswordField.SendKeys(Password);
        
        public void ClickLoginButton() => LoginButton.Click();

        public string GetErrorMessage() => ErrorMessage.GetText();

        public void ClickForgotPasswordButton() => ForgotPasswordButton.Click();
        
        public void ClickResetPassword() => ResetPasswordButton.Click();
        
        public void AssertConfirmationMessage(string message)
        {
            Assert.That(ConfirmationMessageTitle.GetText(), Is.EqualTo(message));
        }
    }
}
