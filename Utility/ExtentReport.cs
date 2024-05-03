using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace NathansWebAutomationFramework.Utility
{
    public class ExtentReport
    {
        // Getting the application info  
        public class AppInfo
        {
            public string? BaseUrl { get; set; }
            public string? Browser { get; set; }
        }

        // Static fields for storing extent reports and tests
        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        // Get the path for storing test results report
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        // Method to initialise ExtentReports
        public static void ExtentReportInit(AppInfo appInfo, string gridUrl)
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Web Automation Report";
            htmlReporter.Config.DocumentTitle = "Web Automation Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Start();

            // Initialise ExtentReports and attach the HTML reporter
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
            _extentReports.AddSystemInfo("Application", "Swag Labs");
            _extentReports.AddSystemInfo("BaseUrl", appInfo.BaseUrl);
            _extentReports.AddSystemInfo("Browser", appInfo.Browser);
            // Additional info for docker execution
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
        public string AddScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }
    }
}
