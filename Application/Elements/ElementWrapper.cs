namespace NathansWebAutomationFramework.Application.Elements
{
    public class ElementWrapper
    {
        private readonly IWebDriver driver;
        private readonly By by;

        public ElementWrapper(IWebDriver driver, By by)
        {
            this.driver = driver;
            this.by = by;
        }

        public IWebElement FindElement()
        {
            return driver.FindElement(by);
        }

        public void Click()
        {
            FindElement().Click();
        }

        public void SendKeys(string text)
        {
            FindElement().SendKeys(text);
        }

        public string GetText()
        {
            return FindElement().Text;
        }
    }
}
