using NathansWebAutomationFramework.Application.Elements;
using NathansWebAutomationFramework.Application.Pages;

namespace NSWebAutomationFramework.Application.Pages
{
    public class CheckoutComplete
    {
        private readonly IWebDriver driver;
        private readonly Inventory inventory;
        private readonly Cart cart;
        private readonly CheckoutStepOne checkoutStepOne;
        private readonly CheckoutStepTwo checkoutStepTwo;

        public CheckoutComplete(IWebDriver driver)
        {
            this.driver = driver;
            inventory = new Inventory(driver);
            cart = new Cart(driver);
            checkoutStepOne = new CheckoutStepOne(driver);
            checkoutStepTwo = new CheckoutStepTwo(driver);
        }

        private ElementWrapper CheckoutCompleteMsg => new(driver, By.XPath("//div/h2"));

        public void CompleteCheckoutProcess(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            inventory.ClickCartButton();
            cart.ClickCheckoutButton();
            checkoutStepOne.EnterCustomerDetails(firstNameValue, lastNameValue, postcodeValue);
            checkoutStepOne.ClickContinueButton();
            checkoutStepTwo.ClickFinishButton();        
        }

        public string GetCheckoutCompleteMessage()
        {
            return CheckoutCompleteMsg.GetText();
        }
    }
}
