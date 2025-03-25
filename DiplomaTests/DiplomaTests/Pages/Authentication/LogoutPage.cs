using DiplomaTests.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaTests.Pages.Authentication
{
    public class LogoutPage : PageBase
    {
        private WebElementWrapper BurgerButton => FindElement(By.XPath("//li[@class='oxd-userdropdown']"));
        private WebElementWrapper LogoutButton => FindElement(By.XPath("//a[normalize-space()='Logout']"));
        private WebElementWrapper LoginTitle => FindElement(By.XPath("//h5[@class='oxd-text oxd-text--h5 orangehrm-login-title']"));

        public LogoutPage(IWebDriver driver) : base(driver)
        {
        }

        public void OpenBurgerDropDown()
        {
            BurgerButton.Click();
        }

        public void ClickLogoutButton()
        {
            LogoutButton.Click();
        }

        public void VerifyLoginTitle()
        {
            LoginTitle.GetText().Equals("Login");
        }
    }
}
