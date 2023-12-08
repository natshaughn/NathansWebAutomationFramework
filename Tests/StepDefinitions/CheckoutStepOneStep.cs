using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;
using NSWebAutomationFramework.Application.Pages;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class CheckoutStepOneStep
    {
        private readonly IWebDriver driver;
        private readonly CheckoutStepOne checkoutStepOne;

        public CheckoutStepOneStep()
        {
            this.driver = DriverManager.GetDriver();
            this.checkoutStepOne = new CheckoutStepOne(driver);
        }
        

        [When(@"I enter information details '([^']*)' '([^']*)' '([^']*)'")]
        public void WhenIEnterInformationDetails(string firstNameValue, string lastNameValue, string postcodeValue)
        {
            checkoutStepOne.EnterDetails(firstNameValue, lastNameValue, postcodeValue);
        }


        [When(@"I click continue")]
        public void WhenIClickContinue()
        {
            checkoutStepOne.ClickContinue();
        }

    }
}
