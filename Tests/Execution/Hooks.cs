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

        [BeforeTestRun]
        public new static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");

            // Retrieve base URL and browser from TestContext.Parameters
            string baseUrl = TestContext.Parameters["BaseUrl"];
            string browser = TestContext.Parameters["Browser"];

            // Create an instance of AppInfo and set the properties
            Hooks.AppInfo appInfo = new Hooks.AppInfo
            {
                BaseUrl = baseUrl, // Sets actual base URL
                Browser = browser   // Sets actual browser
            };

            // Call ExtentReportInit with the created AppInfo
            ExtentReportInit(appInfo);
        }


        [AfterTestRun]
        public new static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown();
        }

        [BeforeFeature]
        public new static void BeforeFeature(FeatureContext featureContext)
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public new static void AfterFeature()
        {
            Console.WriteLine("Running after feature...");
        }

        [BeforeScenario(Order = 1)]
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


        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.CloseDriver();

            // Pass AppInfo to ExtentReport class
            ExtentReportTearDown();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            // When scenario passed
            if (scenarioContext.TestError == null)
            {
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

            // When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
            }
        }
    }
}
