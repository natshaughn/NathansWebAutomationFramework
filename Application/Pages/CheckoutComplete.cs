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
        readonly By checkoutCompleteMsg = By.ClassName("complete-header");

        // Gets the checkout complete message
        public string GetCheckoutCompleteMessage()
        {
            return driver.FindElement(checkoutCompleteMsg).Text;
        }
    }
}
