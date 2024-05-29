using NathansWebAutomationFramework.Application.Elements;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class CheckoutStepOne
    {
        private readonly IWebDriver driver;

        public CheckoutStepOne(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ElementWrapper ContinueButton => new(driver, By.Id("continue"));
        private ElementWrapper FirstNameInput => new(driver, By.Id("first-name"));
        private ElementWrapper LastNameInput => new(driver, By.Id("last-name"));
        private ElementWrapper PostcodeInput => new(driver, By.Id("postal-code"));

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }

        public void EnterCustomerDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            FirstNameInput.SendKeys(firstNameValue);
            LastNameInput.SendKeys(lastNameValue);
            PostcodeInput.SendKeys(postcodeValue);
        }
    }
}
