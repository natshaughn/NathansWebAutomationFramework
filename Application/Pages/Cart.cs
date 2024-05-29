using NathansWebAutomationFramework.Application.Elements;

namespace NSWebAutomationFramework.Application.Pages
{
    public class Cart
    {
        private readonly IWebDriver driver;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ElementWrapper CheckoutButton => new(driver, By.Id("checkout"));

        public void ClickCheckoutButton()
        {
            CheckoutButton.Click();
        }
    }
}
