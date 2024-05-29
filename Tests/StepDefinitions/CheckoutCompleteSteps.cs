using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutCompleteSteps
    {
        private readonly IWebDriver driver;
        private readonly CheckoutComplete checkoutComplete;

        public CheckoutCompleteSteps()
        {
            driver = DriverManager.GetDriver();
            checkoutComplete = new CheckoutComplete(driver);
        }

        [When(@"I complete the checkout process")]
        public void WhenICompleteTheCheckoutProcess()
        {
            string firstName = Guid.NewGuid().ToString();  
            string lastName = Guid.NewGuid().ToString();
            string postcode = Guid.NewGuid().ToString();

            checkoutComplete.CompleteCheckoutProcess(firstName, lastName, postcode);
        }


        [Then(@"a message will appear confirming my order")]
        public void ThenAMessageWillAppearConfirmingMyOrder()
        {
            string actualMessage = checkoutComplete.GetCheckoutCompleteMessage();
            string expectedMessage = "Thank you for your order!";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Actual message: {actualMessage}, Expected message: {expectedMessage}");
        }
    }
}
