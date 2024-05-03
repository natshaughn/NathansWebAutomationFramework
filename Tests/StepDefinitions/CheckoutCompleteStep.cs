using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutCompleteStep
    {
        private readonly IWebDriver driver;
        private readonly CheckoutComplete checkoutComplete;

        public CheckoutCompleteStep()
        {
            this.driver = DriverManager.GetDriver();
            this.checkoutComplete = new CheckoutComplete(driver);
        }

        [Then(@"a message will appear confirming my order")]
        public void ThenAMessageWillAppearConfirmingMyOrder()
        {
            // Call the method to get the checkout complete message
            string actualMessage = checkoutComplete.GetCheckoutCompleteMessage();
            string expectedMessage = "Thank you for your order!";

            // Assert that the actual message matches the expected message
            Assert.That(actualMessage, Is.EqualTo(expectedMessage), $"Expected message: {expectedMessage}, Actual message: {actualMessage}");
        }
    }
}
