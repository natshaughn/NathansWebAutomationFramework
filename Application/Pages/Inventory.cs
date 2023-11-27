using NUnit.Framework;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class Inventory
    {
        private IWebDriver driver;
        public Inventory(IWebDriver driver)
        {
            this.driver = driver;
        }

        By inventoryTitle = By.ClassName("title");

        public void FindTitle()
        {
            //driver.FindElement(inventoryTitle).Equals("Products");
            Assert.AreEqual("Products", driver.FindElement(inventoryTitle).Text, "Expected title is not 'Products'.");
        }
    }
}
