namespace NathansWebAutomationFramework.Tests.Execution
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario(Order = 1)]
        public void BeforeScenario()
        {
            // You can pass the browser type as a configuration or use a default value
            string browserType = "Chrome"; // or "Firefox"

            DriverManager.InitializeDriver(browserType);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            DriverManager.QuitDriver();
        }
    }
}
