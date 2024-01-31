using NathansWebAutomationFramework.Application.Elements;
using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
{
    // Represents the completion of the checkout on the application
    public class CheckoutComplete
    {
        private readonly IWebDriver driver;

        public CheckoutComplete(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locating specific elements on the page - if changed, can change here
        private ElementWrapper CheckoutCompleteMsg => new ElementWrapper(driver, By.ClassName("complete-header"));

        // Gets the checkout complete message
        public void VerifyCheckoutCompleteMessage()
        {
            string expectedMessage = "Thank you for your order!";
            string actualMessage = CheckoutCompleteMsg.GetText();

            if (!actualMessage.Equals(expectedMessage))
            {
                Console.WriteLine($"Expected message: {expectedMessage}, Actual message: {actualMessage}");
                throw new Exception("Checkout complete message mismatch");
            }
        }
    }
}

