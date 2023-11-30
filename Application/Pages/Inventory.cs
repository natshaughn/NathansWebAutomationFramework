using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class Inventory
    {
        private IWebDriver driver;
        public Inventory(IWebDriver driver)
        {
            this.driver = driver;
        }

        By inventoryTitle = By.ClassName("title");

        public void FindTitle()
        {
            IWebElement titleElement = driver.FindElement(inventoryTitle);
            string actualTitle = titleElement.Text;
            string expectedTitle = "Products"; // Adjust this to your expected title

            if (!actualTitle.Equals(expectedTitle))
            {
                // Fail the test or log the failure
                Console.WriteLine($"Expected title: {expectedTitle}, Actual title: {actualTitle}");
                throw new Exception("Title mismatch");
            }
        }

    }
}
