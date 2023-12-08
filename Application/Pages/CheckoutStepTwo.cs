using OpenQA.Selenium;

namespace NSWebAutomationFramework.Application.Pages
{
    public class CheckoutStepTwo
    {
        private readonly IWebDriver driver;

        public CheckoutStepTwo(IWebDriver driver)
        {
            this.driver = driver;
        }

        readonly By finishBtn = By.Id("finish");

        public void ClickFinish()
        {
            driver.FindElement(finishBtn).Click();
        }
    }
}
