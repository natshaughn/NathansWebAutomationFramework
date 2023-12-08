using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
{
    public class Cart
    {
        private readonly IWebDriver driver;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
        }

        readonly By checkout = By.Id("checkout");

        public void ClickCheckout()
        {
            driver.FindElement(checkout).Click();
        }
    }
}

