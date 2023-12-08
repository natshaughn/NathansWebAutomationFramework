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
            inventory.AddProductCart(product);
        }

        [When(@"I click on the cart button")]
        public void WhenIClickOnTheCartButton()
        {
            inventory.ClickCartBtn();
        }

        [Then(@"I am on the inventory page")]
        public void ThenIAmOnTheInventoryPage()
        {
            inventory.FindTitle();
        }

        [Then(@"the (.*) of the (.*) will be correct")]
        public void ThenThePriceOfTheProductWillBeCorrect(decimal price, string product)
        {
            inventory.ProductPrice(price);
            inventory.ProductName(product);
        }

    }
}
