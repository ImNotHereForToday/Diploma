using DiplomaTests.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace DiplomaTests.BrowserFactory
{
    
    public class BrowserFactory
    {
        public static IWebDriver Driver { get; set; }
        public static WebDriverWait GetWait(int timeout = 5) => new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
        
        public static void InitializeDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                    Driver = new ChromeDriver(chromeOptions);
                    break;

                case BrowserType.Firefox:
                    var firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AddArgument("--start-maximized");
                    Driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new ArgumentException($"Browser '{browserType}' is not supported.");
            }
        }
    }
}