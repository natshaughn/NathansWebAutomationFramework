using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace NathansWebAutomationFramework.Tests.Execution
{
    [Binding]
    public class Hooks
    {
        private static IWebDriver? driver;

        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            // You can pass the browser type as a configuration or use a default value
            string browserType = "Chrome"; // or "Firefox"

            // Initialize the WebDriver based on the browser type
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

        [AfterScenario]
        public void AfterScenario()
        {
            // Perform cleanup, close the browser, etc.
            if (driver != null)
            {
                driver.Quit();
            }
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
