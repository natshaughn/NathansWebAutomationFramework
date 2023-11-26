/*using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Drivers
{
    public class DriverManager
    {
        private IWebDriver? driver;

        public IWebDriver InitializeDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                // Add more cases for other browsers if needed

                default:
                    throw new ArgumentException($"Invalid browser: {browser}");
            }

            driver.Manage().Window.Maximize();
            return driver;
        }

        public void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}*/
