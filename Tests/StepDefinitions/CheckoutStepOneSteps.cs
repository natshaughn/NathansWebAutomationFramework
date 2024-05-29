using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutStepOneSteps
    {
        private readonly IWebDriver driver;
        private readonly CheckoutStepOne checkoutStepOne;

        public CheckoutStepOneSteps()
        {
            driver = DriverManager.GetDriver();
            checkoutStepOne = new CheckoutStepOne(driver);
        }
    }
}
