using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutStepTwoSteps
    {
        private readonly IWebDriver driver;
        private readonly CheckoutStepTwo checkoutStepTwo;

        public CheckoutStepTwoSteps()
        {
            this.driver = DriverManager.GetDriver();
            this.checkoutStepTwo = new CheckoutStepTwo(driver);
        }

        [When(@"I click finish")]
        public void WhenIClickFinish()
        {
            checkoutStepTwo.ClickFinishButton();
        }
    }
}
