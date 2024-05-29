using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CartSteps
    {
        private readonly IWebDriver driver;
        private readonly Cart cart;

        public CartSteps()
        {
            driver = DriverManager.GetDriver();
            cart = new Cart(driver);
        }
    }
}
