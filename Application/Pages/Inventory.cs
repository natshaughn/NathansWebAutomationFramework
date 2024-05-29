using NathansWebAutomationFramework.Application.Elements;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class Inventory
    {
        private readonly IWebDriver driver;

        public Inventory(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ElementWrapper CartButton => new(driver, By.XPath("//a[@class='shopping_cart_link']"));
        private ElementWrapper InventoryTitle => new(driver, By.XPath("//span[@class='title']"));
        private ElementWrapper ProductElement(string product) => new(driver, By.XPath($"//*[@id='add-to-cart-{product}']"));
        private ElementWrapper ProductName(string product) => new(driver, By.XPath($"//div[contains(@class, 'inventory_item') and contains(text(), '{product}')]"));
        private ElementWrapper ProductPrice(string product) => new(driver, By.XPath($"//div[contains(@class, 'inventory_item') and .//div[contains(text(), '{product}')]]//div[contains(@class, 'inventory_item_price')]"));

        public void AddProductToCart(string product)
        {
            ProductElement(product).Click();
        }
        public void ClickCartButton()
        {
            CartButton.Click();
        }

        public string GetInventoryPageTitle()
        {
            return InventoryTitle.GetText();
        }

        public string GetProductName(string product)
        {
            return ProductName(product).GetText();
        }

        public string GetProductPrice(string product)
        {
            return ProductPrice(product).GetText().TrimStart('$');
        }
    }
}
