using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
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
        readonly By finishBtn = By.Id("finish");

        // Clicks on the finish button
        public void ClickFinish()
        {
            driver.FindElement(finishBtn).Click();
        }
    }
}
