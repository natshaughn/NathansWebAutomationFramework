using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.Execution
{
    public static class DriverManager
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void GoTo(string url)
        {
            driver.Url = url;
        }

        public static void Init(string browser, string url)
        {
            Console.WriteLine($"Initializing WebDriver with browser: {browser}, url: {url}");

            switch (browser)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "Firefox":
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            // Ensure the driver is not null after initialization
            if (driver != null)
            {
                driver.Manage().Window.Maximize();
                GoTo(url);
            }
            else
            {
                throw new Exception("WebDriver is not initialized. Check the browser and url parameters.");
            }
        }
        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
