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

        private ElementWrapper CartButton => new ElementWrapper(driver, By.XPath("//a[@class='shopping_cart_link']"));
        private ElementWrapper InventoryTitle => new ElementWrapper(driver, By.XPath("//span[@class='title']"));
        private ElementWrapper ProductElement(string product) => new ElementWrapper(driver, By.XPath($"//*[@id='add-to-cart-{product}']"));
        private ElementWrapper ProductName(string product) => new ElementWrapper(driver, By.XPath($"//div[@id='inventory_container']//div[contains(@class, 'inventory_item') and contains(text(), '{product}')]"));
        private ElementWrapper ProductPrice(string product) => new ElementWrapper(driver, By.XPath($"//div[@id='inventory_container']//div[contains(@class, 'inventory_item') and .//div[contains(text(), '{product}')]]//div[contains(@class, 'inventory_item_price')]"));


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
