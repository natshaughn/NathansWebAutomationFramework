using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NathansWebAutomationFramework.Tests.Execution;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Utility
{
    public class ExtentReport
    {
        // Get the app information  
        public class AppInfo
        {
            public string? BaseUrl { get; set; }
            public string? Browser { get; set; }
        }

        // Static fields for storing extent reports and tests
        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        // Method to get the path for storing test results
        public static string GetTestResultPath()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            return dir.Replace("bin\\Debug\\net6.0", "TestResults");
        }

        // Method to delete old screenshots from the test result path
        public static void DeleteOldScreenshots()
        {
            string testResultPath = GetTestResultPath();
            string[] screenshotFiles = Directory.GetFiles(testResultPath, "*.png");

            foreach (var screenshotFile in screenshotFiles)
            {
                try
                {
                    File.Delete(screenshotFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting screenshot file '{screenshotFile}': {ex.Message}");
                }
            }
        }

        // Method to initialize ExtentReports
        public static void ExtentReportInit(Hooks.AppInfo appInfo, string gridUrl)
        {
            // Delete old screenshots before initializing the report
            DeleteOldScreenshots();

            // Specify the report file path without the timestamp
            string reportFilePath = GetTestResultPath() + "\\AutomationReport.html";

            // Delete the existing report file if it exists
            if (File.Exists(reportFilePath))
            {
                File.Delete(reportFilePath);
            }

            // Append the timestamp to the report file path
            reportFilePath = $"{reportFilePath[..^5]}_{DateTime.Now:yyyyMMdd_HHmmss}.html";

            // Configure and start HTML reporter
            var htmlReporter = new ExtentHtmlReporter(reportFilePath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            // Initialize ExtentReports and attach the HTML reporter
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Swag Labs");
            _extentReports.AddSystemInfo("BaseUrl", appInfo.BaseUrl);
            _extentReports.AddSystemInfo("Browser", appInfo.Browser);

            // Additional info for remote execution
            if (appInfo.Browser == "ChromeDocker" || appInfo.Browser == "FirefoxDocker")
            {
                _extentReports.AddSystemInfo("Grid URL", gridUrl);
            }

        }

        // Method to flush and close ExtentReports
        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        // Method to add a screenshot to the test report
        public static string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

            // Set the screenshot location based on scenario title
            string screenshotLocation = Path.Combine(GetTestResultPath(), scenarioContext.ScenarioInfo.Title + ".png");

            try
            {
                File.WriteAllBytes(screenshotLocation, screenshotBytes);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving screenshot: {ex.Message}");
            }

            return screenshotLocation;
        }
    }
}
