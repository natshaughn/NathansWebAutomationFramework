using OpenQA.Selenium;
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

        // Navigate to url 
        public static void GoTo(string url)
        {
            driver.Url = url;
        }

        // Initializes the WebDriver based on the browser and URL
        public static void Init(string browser, string url)
        {
            Console.WriteLine($"Initialising WebDriver with browser: {browser}, url: {url}");

            switch (browser)
            {
                case "Chrome":
                    ChromeOptions? chromeOptions = new();
                    chromeOptions.AddArgument("headless"); 
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "Firefox":
                    FirefoxOptions? firefoxOptions = new();
                    firefoxOptions.AddArgument("--headless"); 
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "ChromeDocker":
                    Console.WriteLine($"Connecting to Selenium Grid for ChromeDocker");
                    ChromeOptions? dockerOptions = new();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), dockerOptions);
                    break;

                case "FirefoxDocker":
                    Console.WriteLine($"Connecting to Selenium Grid for FirefoxDocker");
                    FirefoxOptions? firefoxDockerOptions = new();
                    driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), firefoxDockerOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            // Ensures the driver is not null after initialization
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

        // Closes the WebDriver instance
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
