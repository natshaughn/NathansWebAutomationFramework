using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutStepOneStep
    {
        private readonly IWebDriver driver;
        private readonly CheckoutStepOne checkoutStepOne;

        public CheckoutStepOneStep()
        {
            this.driver = DriverManager.GetDriver();
            this.checkoutStepOne = new CheckoutStepOne(driver);
        }


        [When(@"I enter information details '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEnterInformationDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            // Call the method to enter details on the Checkout Step One page
            checkoutStepOne.EnterDetails(firstNameValue, lastNameValue, postcodeValue);
        }

        [When(@"I click continue")]
        public void WhenIClickContinue()
        {
            // Call the method to click on the 'Continue' button in the Checkout Step One page
            checkoutStepOne.ClickContinue();
        }

    }
}
