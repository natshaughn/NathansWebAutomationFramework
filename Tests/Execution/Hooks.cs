using NUnit.Framework;

namespace NathansWebAutomationFramework.Tests.Execution
{
    [Binding]
    public class Hooks
    {
        public class AppInfo
        {
            public string BaseUrl { get; set; }
            public string Browser { get; set; }
        }

        [BeforeScenario(Order = 1)]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            string baseUrl = TestContext.Parameters["BaseUrl"];
            string browser = TestContext.Parameters["Browser"];

            Console.WriteLine($"BaseUrl: {baseUrl}, Browser: {browser}");

            AppInfo appInfo = new AppInfo()
            {
                BaseUrl = baseUrl,
                Browser = browser
            };

            DriverManager.Init(appInfo.Browser, appInfo.BaseUrl);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.CloseDriver();
        }
    }
}
