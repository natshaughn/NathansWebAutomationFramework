using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
{
    public class CheckoutComplete
    {
        private readonly IWebDriver driver;

        public CheckoutComplete(IWebDriver driver)
        {
            this.driver = driver;
        }

        readonly By checkoutCompleteMsg = By.ClassName("complete-header");

        public string GetCheckoutCompleteMessage()
        {
            return driver.FindElement(checkoutCompleteMsg).Text;
        }
    }
}
