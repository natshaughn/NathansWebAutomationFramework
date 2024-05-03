using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;

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
            inventory.AddProductToCart(product);
        }

        [When(@"I click on the cart button")]
        public void WhenIClickOnTheCartButton()
        {
            // Call the method to click on the cart button
            inventory.ClickCartButton();
        }

        [Then(@"I am on the inventory page")]
        public void ThenIAmOnTheInventoryPage()
        {
            // Get the actual title of the inventory page
            string actualTitle = inventory.GetTitle();

            // Assert that the actual title matches the expected title
            Assert.That(actualTitle, Is.EqualTo("Products"));
        }

        [Then(@"the (.*) of the (.*) will be correct")]
        public void ThenThePriceOfTheProductWillBeCorrect(decimal expectedPrice, string expectedProduct)
        {
            // Retrieve all product names from the page
            var productNames = inventory.GetAllProductNames();
            // Retrieve all product prices from the page
            var productPrices = inventory.GetAllProductPrices();

            // Attempt to find the index of the expected product in the list of product names
            int productIndex = productNames.IndexOf(expectedProduct);
            // Check if the product was not found; if not, fail the test with a message
            if (productIndex == -1)
                Assert.Fail($"Product '{expectedProduct}' not found on the page.");

            // Retrieve the price for the product using the index found above
            decimal actualPrice = productPrices[productIndex];
            // Assert that the actual price matches the expected price,
            // if not, report the discrepancy with a failure message
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), $"Expected price for '{expectedProduct}' is {expectedPrice}, but found {actualPrice}.");
        }
    }
}
