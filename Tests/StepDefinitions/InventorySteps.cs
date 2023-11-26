using OpenQA.Selenium;
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
            this.driver = Hooks.GetDriver();
            this.inventory = new Inventory(driver);
        }

        [Then(@"I am on the inventory page")]
        public void ThenIAmOnTheInventoryPage()
        {
            inventory.FindTitle();
        }
    }
}