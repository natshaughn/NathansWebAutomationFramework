using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class Inventory
    {
        private readonly IWebDriver driver;
        public Inventory(IWebDriver driver)
        {
            this.driver = driver;
        }

        readonly By inventoryTitle = By.ClassName("title");
        readonly By cartBtn = By.ClassName("shopping_cart_link");
        readonly By prodPrice = By.ClassName("inventory_item_price");
        readonly By prodName = By.ClassName("inventory_item_name");

        public void FindTitle()
        {
            IWebElement titleElement = driver.FindElement(inventoryTitle);
            string actualTitle = titleElement.Text;
            string expectedTitle = "Products"; // Adjust this to your expected title

            if (!actualTitle.Equals(expectedTitle))
            {
                // Fail the test or log the failure
                Console.WriteLine($"Expected title: {expectedTitle}, Actual title: {actualTitle}");
                throw new Exception("Title mismatch");
            }

        }
        public void AddProductCart(string product)
        {
            driver.FindElement(By.XPath($"//*[@id='add-to-cart-{product}']")).Click();
        }

        public void ClickCartBtn()
        {
            driver.FindElement(cartBtn).Click();
        }

        public void ProductPrice(decimal price)
        {
            driver.FindElement(prodPrice).Equals(price);
        }

        public void ProductName(string product)
        {
            driver.FindElement(prodName).Equals(product);
        }

    }
}
