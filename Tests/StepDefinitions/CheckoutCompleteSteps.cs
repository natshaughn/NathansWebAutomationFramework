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
            this.driver = DriverManager.GetDriver();
            this.checkoutComplete = new CheckoutComplete(driver);
        }

        [Then(@"a message will appear confirming my order")]
        public void ThenAMessageWillAppearConfirmingMyOrder()
        {
            string actualMessage = checkoutComplete.GetCheckoutCompleteMessage();
            string expectedMessage = "Thank you for your order!";

            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Expected message: {expectedMessage}, Actual message: {actualMessage}");
        }
    }
}
