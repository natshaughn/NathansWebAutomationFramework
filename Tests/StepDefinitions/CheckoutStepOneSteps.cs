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
            this.driver = DriverManager.GetDriver();
            this.checkoutStepOne = new CheckoutStepOne(driver);
        }

        [When(@"I enter information details '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEnterInformationDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            checkoutStepOne.EnterCustomerDetails(firstNameValue, lastNameValue, postcodeValue);
        }

        [When(@"I click continue")]
        public void WhenIClickContinue()
        {
            checkoutStepOne.ClickContinueButton();
        }
    }
}
