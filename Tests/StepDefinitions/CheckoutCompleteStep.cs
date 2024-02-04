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
            // Call the method to verify the checkout complete message
            checkoutComplete.VerifyCheckoutCompleteMessage();
        }
    }
}
