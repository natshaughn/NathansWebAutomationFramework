using NathansWebAutomationFramework.Application.Elements;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class CheckoutStepTwo
    {
        private readonly IWebDriver driver;


        public CheckoutStepTwo(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ElementWrapper FinishButton => new(driver, By.Id("finish"));

        public void ClickFinishButton()
        {
            FinishButton.Click();
        }
    }
}
