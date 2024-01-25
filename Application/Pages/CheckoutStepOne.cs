using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
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
        readonly By firstName = By.Id("first-name");
        readonly By lastName = By.Id("last-name");
        readonly By postcode = By.Id("postal-code");
        readonly By continueBtn = By.Id("continue");

        // Enters the customer details
        public void EnterDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            driver.FindElement(firstName).SendKeys(firstNameValue);
            driver.FindElement(lastName).SendKeys(lastNameValue);
            driver.FindElement(postcode).SendKeys(postcodeValue);
        }

        // Clicks the continue button
        public void ClickContinue()
        {
            driver.FindElement(continueBtn).Click();
        }
    }
}
