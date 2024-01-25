using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class InventorySteps
    {
        private readonly IWebDriver driver;
        private readonly Inventory inventory;

        public InventorySteps()
        {
            this.driver = DriverManager.GetDriver();
            this.inventory = new Inventory(driver);
        }

        [When(@"I add '([^']*)' to cart")]
        public void WhenIAddToCart(string product)
        {
            // Call the method to add the specified product to the cart
            inventory.AddProductCart(product);
        }

        [When(@"I click on the cart button")]
        public void WhenIClickOnTheCartButton()
        {
            // Call the method to click on the cart button
            inventory.ClickCartBtn();
        }

        [Then(@"I am on the inventory page")]
        public void ThenIAmOnTheInventoryPage()
        {
            // Verify that the title on the page indicates it's the inventory page
            inventory.FindTitle();
        }

        [Then(@"the (.*) of the (.*) will be correct")]
        public void ThenThePriceOfTheProductWillBeCorrect(decimal price, string product)
        {
            // Verify that the displayed price matches the expected price for the specified product
            inventory.ProductPrice(price);

            // Verify that the displayed product name matches the expected product name
            inventory.ProductName(product);
        }

    }
}
