using AventStack.ExtentReports.Reporter.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NathansWebAutomationFramework.Tests.Execution;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Utility
{
    public class ExtentReport
    {
        public class AppInfo
        {
            public string BaseUrl { get; set; }
            public string Browser { get; set; }
        }

        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static string GetTestResultPath()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            return dir.Replace("bin\\Debug\\net6.0", "TestResults");
        }

        public static void ExtentReportInit(Hooks.AppInfo appInfo)
        {
            // Specify the report file path without the timestamp
            string reportFilePath = GetTestResultPath() + "\\AutomationReport.html";

            // Delete the existing report file if it exists
            if (File.Exists(reportFilePath))
            {
                File.Delete(reportFilePath);
            }

            // Append the timestamp to the report file path
            reportFilePath = $"{reportFilePath.Substring(0, reportFilePath.Length - 5)}_{DateTime.Now:yyyyMMdd_HHmmss}.html";

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
        }

        public static void ExtentReportTearDown()
        {
            _extentReports.Flush();
        }

        public static string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(GetTestResultPath(), scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }
    }
}
