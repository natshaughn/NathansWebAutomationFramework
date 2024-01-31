using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            try
            {
                // Wait for the element to be present before attempting to find it
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(driver => driver.FindElement(by));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Timeout waiting for the element to be visible: {by}");
                throw;
            }
        }

        public IReadOnlyCollection<IWebElement> FindElements()
        {
            try
            {
                // Wait for at least one element to be present before attempting to find them
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return wait.Until(driver => driver.FindElements(by));
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine($"Timeout waiting for at least one element to be visible: {by}");
                throw;
            }
        }

        public void Clear()
        {
            FindElement().Clear();
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

