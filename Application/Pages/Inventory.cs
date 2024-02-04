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
        private ElementWrapper InventoryTitle => new ElementWrapper(driver, By.XPath("//span[@class='title']"));
        private ElementWrapper CartButton => new ElementWrapper(driver, By.XPath("//a[@class='shopping_cart_link']"));
        private ElementWrapper ProductPrice => new ElementWrapper(driver, By.XPath("//div[@class='inventory_item']/div[2]/div[2]/div"));
        private ElementWrapper ProductName => new ElementWrapper(driver, By.XPath("//div[@class='inventory_item']/div[2]/div/a/div"));
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
            var productPrices = ProductPrice.FindElements();

            foreach (var priceElement in productPrices)
            {
                // Remove currency symbols with Regex.Replace
                string actualPriceText = Regex.Replace(priceElement.Text, @"[^\d.]", "");

                // Parse the cleaned text (without currency symbol) into a decimal value for comparison
                decimal actualPrice = decimal.Parse(actualPriceText);

                if (actualPrice == expectedPrice)
                {
                    return; // Found a match, exit the loop
                }
            }

            // If no match is found, throw an exception
            throw new AssertionException($"No matching product price found for {expectedPrice}");
        }
 
        // Verify the products name
        public void VerifyProductName(string expectedProduct)
        {
            var productNames = ProductName.FindElements();

            foreach (var nameElement in productNames)
            {
                string actualProductName = nameElement.Text;

                if (actualProductName.Equals(expectedProduct))
                {
                    return; // Found a match, exit the loop
                }
            }

            // If no match is found, throw an exception
            throw new AssertionException($"No matching product name found for {expectedProduct}");
        }
    }
}
