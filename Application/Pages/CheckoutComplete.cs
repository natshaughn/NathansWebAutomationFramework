using NathansWebAutomationFramework.Application.Elements;

namespace NSWebAutomationFramework.Application.Pages
{
    public class CheckoutComplete
    {
        private readonly IWebDriver driver;

        public CheckoutComplete(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ElementWrapper CheckoutCompleteMsg => new ElementWrapper(driver, By.XPath("//div/h2"));

        public string GetCheckoutCompleteMessage()
        {
            return CheckoutCompleteMsg.GetText();
        }
    }
}
