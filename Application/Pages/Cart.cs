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
        readonly By checkout = By.Id("checkout");

        // Clicks the checkout button
        public void ClickCheckout()
        {
            driver.FindElement(checkout).Click();
        }
    }
}

