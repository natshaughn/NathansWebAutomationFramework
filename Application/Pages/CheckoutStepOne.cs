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

        private ElementWrapper ContinueButton => new ElementWrapper(driver, By.XPath("//input[@id='continue']"));
        private ElementWrapper FirstNameInput => new ElementWrapper(driver, By.XPath("//input[@id='first-name']"));
        private ElementWrapper LastNameInput => new ElementWrapper(driver, By.XPath("//input[@id='last-name']"));
        private ElementWrapper PostcodeInput => new ElementWrapper(driver, By.XPath("//input[@id='postal-code']"));
        
        public void EnterCustomerDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            FirstNameInput.SendKeys(firstNameValue);
            LastNameInput.SendKeys(lastNameValue);
            PostcodeInput.SendKeys(postcodeValue);
        }

        public void ClickContinueButton()
        {
            ContinueButton.Click();
        }
    }
}
