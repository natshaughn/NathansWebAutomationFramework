using NathansWebAutomationFramework.Application.Elements;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    // Represents the second stage of the checkout on the application
    public class CheckoutStepTwo
    {
        private readonly IWebDriver driver;

        public CheckoutStepTwo(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locating specific elements on the page - if changed, can change here
        private ElementWrapper FinishButton => new ElementWrapper(driver, By.XPath("//button[@id='finish']"));

        // Clicks on the finish button
        public void ClickFinish()
        {
            FinishButton.Click();
        }
    }
}
