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

        private ElementWrapper CheckoutButton => new ElementWrapper(driver, By.XPath("//button[@id='checkout']"));

        public void ClickCheckoutButton()
        {
            CheckoutButton.Click();
        }
    }
}
