using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    // Represents the Inventory Page of the application
    public class Inventory
    {
        private readonly IWebDriver driver;
        public Inventory(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locating specific elements on the page - if changed, can change here
        readonly By inventoryTitle = By.ClassName("title");
        readonly By cartBtn = By.ClassName("shopping_cart_link");
        readonly By prodPrice = By.ClassName("inventory_item_price");
        readonly By prodName = By.ClassName("inventory_item_name");

        // Find Inventory page title
        public void FindTitle()
        {
            IWebElement titleElement = driver.FindElement(inventoryTitle);
            string actualTitle = titleElement.Text;
            string expectedTitle = "Products"; // Expected title

            if (!actualTitle.Equals(expectedTitle))
            {
                // Fail the test or log the failure
                Console.WriteLine($"Expected title: {expectedTitle}, Actual title: {actualTitle}");
                throw new Exception("Inventory page title mismatch");
            }

        }

        // Add a product to cart
        public void AddProductCart(string product)
        {
            driver.FindElement(By.XPath($"//*[@id='add-to-cart-{product}']")).Click();
        }

        // Click on the cart button
        public void ClickCartBtn()
        {
            driver.FindElement(cartBtn).Click();
        }

        // Find the products price
        public void ProductPrice(decimal price)
        {
            driver.FindElement(prodPrice).Equals(price);
        }

        // Find the products name 
        public void ProductName(string product)
        {
            driver.FindElement(prodName).Equals(product);
        }

    }
}
