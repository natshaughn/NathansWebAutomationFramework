using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CartStep
    {
        private readonly IWebDriver driver;
        private readonly Cart cart;

        public CartStep()
        {
            this.driver = DriverManager.GetDriver();
            this.cart = new Cart(driver);
        }

        [When(@"I click the checkout button")]
        public void WhenIClickTheCheckoutButton()
        {
            // Call the method to click on the checkout button
            cart.ClickCheckout();
        }

    }
}
