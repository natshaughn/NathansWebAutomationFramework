using NathansWebAutomationFramework.Utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;

namespace NathansWebAutomationFramework.Tests.Execution
{
    [Binding]
    public class Hooks : ExtentReport
    {
        private readonly IObjectContainer ObjectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            ObjectContainer = objectContainer;
        }

        // Executed before entire test run
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("Running before test run...");

            // Retrieve base URL and browser from configuration
            string baseUrl = TestContext.Parameters["BaseUrl"];
            string browser = TestContext.Parameters["Browser"];

            // Construct the Selenium Grid URL based on the Docker network
            string gridUrl = "http://selenium-hub:4444/wd/hub";

            // Create an instance of AppInfo and set the properties
            AppInfo appInfo = new AppInfo()
            {
                BaseUrl = baseUrl,
                Browser = browser
            };

            // Call ExtentReportInit with the created AppInfo properties and the Selenium Grid URL
            ExtentReportInit(appInfo, gridUrl);
        }

        // Executed after entire test run
        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Running after test run...");
            ExtentReportTearDown(); // Flushing/ creating report
        }

        // Executed before each feature
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) // feature context reference variable - can get feature name 
        {
            Console.WriteLine("Running before feature...");
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            // extent reports object - calling CreateTest method <Feature> = Gherkin keyword - get feature name, getting the title will get title of any feature file
            // Create test, assign to _feature
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

            // Initialise WebDriver using DriverManager
            DriverManager.Init(browser, baseUrl);

            // Register WebDriver instance with BoDi container - iWebDriver return driver
            ObjectContainer.RegisterInstanceAs<IWebDriver>(DriverManager.GetDriver());

            // Create ExtentReport node for the scenario
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            // After creating _feature, then do same with scenario, get scenario name
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
            IWebDriver driver = ObjectContainer.Resolve<IWebDriver>();

            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

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
                // Attach the screenshot to the test results using TestContext
                string screenshotPath = AddScreenshot(driver, scenarioContext);
                TestContext.AddTestAttachment(screenshotPath, "FailureScreenshot");

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
