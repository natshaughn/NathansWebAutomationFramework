using NUnit.Framework;
using NathansWebAutomationFramework.Utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.Execution
{
    [Binding]
    public class Hooks : ExtentReport
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        // Executed before entire test run
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");

            // Retrieve base URL and browser from TestContext.Parameters
            string baseUrl = TestContext.Parameters["BaseUrl"];
            string browser = TestContext.Parameters["Browser"];

            // Construct the Selenium Grid URL based on the Docker network
            string gridUrl = "http://selenium-hub:4444/wd/hub";

            // Create an instance of AppInfo and set the properties
            Hooks.AppInfo appInfo = new()
            {
                BaseUrl = baseUrl,
                Browser = browser
            };

            // Call ExtentReportInit with the created AppInfo and the Selenium Grid URL
            ExtentReportInit(appInfo, gridUrl);
        }

        // Executed after entire test run
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        // Executed before each feature
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        // Executed before each scenario 
        [BeforeScenario]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running before scenario...");

            // Retrieve browser and base URL from configuration
            string browser = TestContext.Parameters["Browser"];
            string baseUrl = TestContext.Parameters["BaseUrl"];

            Console.WriteLine($"Browser: {browser}, BaseUrl: {baseUrl}");

            // Initialize WebDriver using DriverManager
            DriverManager.Init(browser, baseUrl);

            // Register WebDriver instance with BoDi container
            _container.RegisterInstanceAs<IWebDriver>(DriverManager.GetDriver());

            // Create ExtentReport node for the scenario
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        // Executed after each scenario
        [AfterScenario]
        public static void AfterScenario()
        {
            DriverManager.CloseDriver();

            // Pass AppInfo to ExtentReport class
            ExtentReportTearDown();
        }

        // Executed after each step
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            // When scenario fails
            if (scenarioContext.TestError != null)
            {
                try
                {
                    // Attempt to capture and attach a screenshot to the report
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding screenshot to report: {ex.Message}");
                }
            }
            else // When scenario passed
            {
                // Create nodes based on step type (Given, When, Then, And)
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }
        }
    }
}
