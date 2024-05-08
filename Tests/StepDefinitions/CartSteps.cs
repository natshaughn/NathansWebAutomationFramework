using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CartSteps
    {
        private readonly IWebDriver driver;
        private readonly Cart cart;

        public CartSteps()
        {
            this.driver = DriverManager.GetDriver();
            this.cart = new Cart(driver);
        }

        [When(@"I click the checkout button")]
        public void WhenIClickTheCheckoutButton()
        {
            cart.ClickCheckoutButton();
        }
    }
}
