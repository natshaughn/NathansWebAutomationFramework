using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
{
    public class CheckoutStepOne
    {
        private readonly IWebDriver driver;

        public CheckoutStepOne(IWebDriver driver)
        {
            this.driver = driver;
        }

        readonly By firstName = By.Id("first-name");
        readonly By lastName = By.Id("last-name");
        readonly By postcode = By.Id("postal-code");
        readonly By continueBtn = By.Id("continue");

        public void EnterDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            driver.FindElement(firstName).SendKeys(firstNameValue);
            driver.FindElement(lastName).SendKeys(lastNameValue);
            driver.FindElement(postcode).SendKeys(postcodeValue);
        }

        public void ClickContinue()
        {
            driver.FindElement(continueBtn).Click();
        }
    }
}
