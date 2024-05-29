using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace NathansWebAutomationFramework.Tests.Execution
{
    public static class DriverManager
    {
        private static IWebDriver? driver;

        public static IWebDriver? GetDriver()
        {
            return driver;
        }

        public static void GoTo(string url)
        {
            driver.Url = url;
        }

        public static void Init(string browser, string url)
        {
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions chromeOptions = new();
                    chromeOptions.AddArgument("headless"); 
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "Firefox":
                    FirefoxOptions firefoxOptions = new();
                    firefoxOptions.AddArgument("--headless"); 
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "ChromeDocker":
                    ChromeOptions dockerChromeOptions = new();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), dockerChromeOptions);
                    break;

                case "FirefoxDocker":
                    FirefoxOptions dockerFirefoxOptions = new();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), dockerFirefoxOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            if (driver != null)
            {
                driver.Manage().Window.Maximize();
                GoTo(url);
            }
            else
            {
                throw new Exception("Check the browser and url parameters.");
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
