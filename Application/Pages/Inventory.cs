using NathansWebAutomationFramework.Application.Elements;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

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
        private ElementWrapper InventoryTitle => new ElementWrapper(driver, By.ClassName("title"));
        private ElementWrapper CartButton => new ElementWrapper(driver, By.ClassName("shopping_cart_link"));
        private ElementWrapper ProductPrice => new ElementWrapper(driver, By.ClassName("inventory_item_price"));
        private ElementWrapper ProductName => new ElementWrapper(driver, By.ClassName("inventory_item_name"));
        private ElementWrapper ProductElement(string product) => new ElementWrapper(driver, By.XPath($"//*[@id='add-to-cart-{product}']"));

        // Verify Inventory page title
        public void FindTitle()
        {
            string actualTitle = InventoryTitle.GetText();
            string expectedTitle = "Products";

            if (!actualTitle.Equals(expectedTitle))
            {
                Console.WriteLine($"Expected title: {expectedTitle}, Actual title: {actualTitle}");
                throw new Exception("Inventory page title mismatch");
            }
        }

        // Add a product to the cart
        public void AddProductToCart(string product)
        {
            // Use ElementWrapper to click the product add-to-cart button
            ProductElement(product).Click();
        }


        // Click on the cart button
        public void ClickCartButton()
        {
            CartButton.Click();
        }

        // Verify the products price
        public void VerifyProductPrice(decimal expectedPrice)
        {
            var productPrices = new List<IWebElement>(ProductPrice.FindElements());

            for (int i = 0; i < productPrices.Count; i++)
            {
                string actualPriceText = productPrices[i].Text;

                // Remove currency symbols, whitespaces, and any other non-numeric characters
                actualPriceText = Regex.Replace(actualPriceText, @"[^\d.]", "");

                if (decimal.TryParse(actualPriceText, out decimal actualPrice))
                {
                    // Use NUnit assertion to check if the actual price matches the expected price
                    if (actualPrice == expectedPrice)
                    {
                        return; // Found a match, exit the loop
                    }
                }
            }

            // If no match is found, throw an exception
            throw new AssertionException($"No matching product price found for {expectedPrice}");
        }

        // Verify the products name
        public void VerifyProductName(string expectedProduct)
        {
            var productNames = ProductName.FindElements();

            foreach (var productNameElement in productNames)
            {
                string actualProductName = productNameElement.Text;

                // Trim extra spaces for comparison
                string cleanedActualProductName = actualProductName.Trim();

                // Use NUnit assertion to check if the cleaned actual product name matches the cleaned expected product name
                if (cleanedActualProductName.Equals(expectedProduct.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return; // Found a match, exit the loop
                }
            }

            // If no match is found, throw an exception
            throw new AssertionException($"No matching product name found for {expectedProduct}");
        }





    }
}

