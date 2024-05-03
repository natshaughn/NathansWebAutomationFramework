using NathansWebAutomationFramework.Application.Elements;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    // Represents the first stage of the checkout on the application
    public class CheckoutStepOne
    {
        private readonly IWebDriver driver;

        public CheckoutStepOne(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locating specific elements on the page - if changed, can change here
        private ElementWrapper ContinueButton => new ElementWrapper(driver, By.XPath("//input[@id='continue']"));
        private ElementWrapper FirstNameInput => new ElementWrapper(driver, By.XPath("//input[@id='first-name']"));
        private ElementWrapper LastNameInput => new ElementWrapper(driver, By.XPath("//input[@id='last-name']"));
        private ElementWrapper PostcodeInput => new ElementWrapper(driver, By.XPath("//input[@id='postal-code']"));
        
        // Enters the customer details
        public void EnterDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            FirstNameInput.SendKeys(firstNameValue);
            LastNameInput.SendKeys(lastNameValue);
            PostcodeInput.SendKeys(postcodeValue);
        }

        // Clicks the continue button
        public void ClickContinue()
        {
            ContinueButton.Click();
        }
    }
}
