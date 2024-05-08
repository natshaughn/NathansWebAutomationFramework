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

        // Return single element
        public IWebElement FindElement()
        {
            return driver.FindElement(by);
        }

        // Return a group of elements
        public IReadOnlyCollection<IWebElement> FindElements()
        {
            return driver.FindElements(by);
        }

        // Click an element
        public void Click()
        {
            FindElement().Click();
        }

        // Send text to an element
        public void SendKeys(string text)
        {
            FindElement().SendKeys(text);
        }

        // Get text from an element
        public string GetText()
        {
            return FindElement().Text;
        }

        public List <string> GetAllText()
        {
            return FindElements().Select(x => x.Text).ToList(); 
        }
    }
}
