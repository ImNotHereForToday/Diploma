using DiplomaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DiplomaTests.BrowserFactory
{
    public class BrowserFactory
    {
        public static IWebDriver CreateDriver(BrowserType browserType)
        {
            IWebDriver driver;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new ArgumentException($"Browser '{browserType}' is not supported.");
            }

            return driver;
        }
    }
}