using NathansWebAutomationFramework.Utility;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace NathansWebAutomationFramework.Tests.Execution
{
    [Binding]
    public class Hooks : ExtentReport
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            string baseUrl = TestContext.Parameters["BaseUrl"];
            string browser = TestContext.Parameters["Browser"];
            string gridUrl = "http://selenium-hub:4444/wd/hub";

            AppInfo appInfo = new()
            {
                BaseUrl = baseUrl,
                Browser = browser
            };

            ExtentReportInit(appInfo, gridUrl);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTearDown(); 
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) 
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            string browser = TestContext.Parameters["Browser"];
            string baseUrl = TestContext.Parameters["BaseUrl"];
            DriverManager.Init(browser, baseUrl);

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            DriverManager.CloseDriver();
            ExtentReportTearDown();
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            IWebDriver driver = DriverManager.GetDriver();

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
            } else {
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
