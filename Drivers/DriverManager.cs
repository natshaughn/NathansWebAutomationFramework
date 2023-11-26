using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NathansWebAutomationFramework.Tests.Execution
{
    public static class DriverManager
    {
        private static IWebDriver driver;

        public static void InitializeDriver(string browserType)
        {
            if (driver != null)
            {
                throw new InvalidOperationException("Driver is already initialized.");
            }

            if (browserType.Equals("Chrome", StringComparison.OrdinalIgnoreCase))
            {
                driver = new ChromeDriver();
            }
            else if (browserType.Equals("Firefox", StringComparison.OrdinalIgnoreCase))
            {
                driver = new FirefoxDriver();
            }
            else
            {
                throw new NotSupportedException($"Browser type '{browserType}' is not supported.");
            }
        }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                throw new InvalidOperationException("Driver is not initialized. Call InitializeDriver first.");
            }

            return driver;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}

