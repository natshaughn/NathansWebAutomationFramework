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
            driver = DriverManager.GetDriver();
            inventory = new Inventory(driver);
        }

        [When(@"I add '([^']*)' to cart")]
        public void WhenIAddToCart(string product)
        {
            inventory.AddProductToCart(product);
        }

        [Then(@"I am on the inventory page"), When(@"I am on the inventory page")]
        public void ThenIAmOnTheInventoryPage()
        {
            string actualTitle = inventory.GetInventoryPageTitle();
            string expectedTitle = "Products";

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Actual title: {actualTitle}, Expected title: {expectedTitle}");
        }

        [Then(@"the (.*) of the (.*) will be correct")]
        public void ThenThePriceOfTheProductWillBeCorrect(string expectedPrice, string product)
        {
            string actualProduct = inventory.GetProductName(product);
            string actualPrice = inventory.GetProductPrice(product);

            Assert.That(actualProduct, Is.EqualTo(product), $" Actual product: '{actualProduct}', Expected product: '{product}'");
            Assert.That(actualPrice, Is.EqualTo(expectedPrice), $"Expected price for '{product}' is {expectedPrice}, but found {actualPrice}");
        }
    }
}
