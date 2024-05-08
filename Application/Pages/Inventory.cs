﻿using NathansWebAutomationFramework.Application.Elements;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class Inventory
    {
        private readonly IWebDriver driver;

        public Inventory(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ElementWrapper CartButton => new ElementWrapper(driver, By.XPath("//a[@class='shopping_cart_link']"));
        private ElementWrapper InventoryTitle => new ElementWrapper(driver, By.XPath("//span[@class='title']"));
        private ElementWrapper ProductElement(string product) => new ElementWrapper(driver, By.XPath($"//*[@id='add-to-cart-{product}']"));
        private ElementWrapper ProductNames => new ElementWrapper(driver, By.XPath("//div[@class='inventory_item']/div[2]/div/a/div"));
        private ElementWrapper ProductPrices => new ElementWrapper(driver, By.XPath("//div[@class='inventory_item']/div[2]/div[2]/div"));

        public string GetInventoryPageTitle()
        {
            return InventoryTitle.GetText();
        }

        public void AddProductToCart(string product)
        {
            ProductElement(product).Click();
        }

        public void ClickCartButton()
        {
            CartButton.Click();
        }

        // Method to get all product names MAYBE CHANGE THIS ONE 
        public List<string> GetAllProductNames()
        {
            // Uses Selenium to find all elements that match the given XPath for product names,
            // and then converts each element to its text representation (the name of the product).
            //return ProductNames.FindElements().Select(element => element.Text).ToList();
            return ProductNames.GetAllText();
        }

        // Method to get all product prices from the webpage
        public List<decimal> GetAllProductPrices()
        {
            // Uses Selenium to find all elements that match the given XPath for product prices,
            // converts each element's text to a decimal after removing the dollar sign,
            // this allows numerical comparison and operations on the prices.
            return ProductPrices.FindElements().Select(x => decimal.Parse(x.Text.Trim('$'))).ToList();
        }
    }
}
