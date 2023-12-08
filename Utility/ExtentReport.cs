using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NathansWebAutomationFramework.Tests.Execution;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Utility
{
    public class ExtentReport
    {
        public class AppInfo
        {
            public string? BaseUrl { get; set; }
            public string? Browser { get; set; }
        }

        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        public static string GetTestResultPath()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            return dir.Replace("bin\\Debug\\net6.0", "TestResults");
        }

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

            var htmlReporter = new ExtentHtmlReporter(reportFilePath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Swag Labs");
            _extentReports.AddSystemInfo("BaseUrl", appInfo.BaseUrl);
            _extentReports.AddSystemInfo("Browser", appInfo.Browser);

            // Additional info for remote execution
            if (appInfo.Browser == "ChromeDocker")
            {
                _extentReports.AddSystemInfo("Grid URL", gridUrl); // Updated line
            }
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public static string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            byte[] screenshotBytes = screenshot.AsByteArray;

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
