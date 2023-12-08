using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutStepTwoStep
    {
        private readonly IWebDriver driver;
        private readonly CheckoutStepTwo checkoutStepTwo;

        public CheckoutStepTwoStep()
        {
            this.driver = DriverManager.GetDriver();
            this.checkoutStepTwo = new CheckoutStepTwo(driver);
        }

        [When(@"I click finish")]
        public void WhenIClickFinish()
        {
            checkoutStepTwo.ClickFinish();
        }

    }
}
