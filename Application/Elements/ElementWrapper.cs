using OpenQA.Selenium;

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

        // Find and return single element
        public IWebElement FindElement()
        {
            return driver.FindElement(by);
        }

        // Find and return collection of elements
        public IReadOnlyCollection<IWebElement> FindElements()
        {
            return driver.FindElements(by);
        }

        // Find element and click it
        public void Click()
        {
            FindElement().Click();
        }

        // Find element and send specified text
        public void SendKeys(string text)
        {
            FindElement().SendKeys(text);
        }

        // Find element and retrieves text
        public string GetText()
        {
            return FindElement().Text;
        }
    }
}
