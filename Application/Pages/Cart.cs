using NathansWebAutomationFramework.Application.Elements;
using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
{
    // Represents the cart page on the application
    public class Cart
    {
        private readonly IWebDriver driver;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locating specific elements on the page - if changed, can change here
        private ElementWrapper CheckoutButton => new ElementWrapper(driver, By.XPath("//button[@id='checkout']"));

        // Clicks the checkout button
        public void ClickCheckout()
        {
            CheckoutButton.Click();
        }
    }
}
