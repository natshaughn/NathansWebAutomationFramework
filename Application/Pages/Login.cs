using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class Login
    {
        private IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        By loginTitle = By.ClassName("login_logo");
        By userInput = By.Id("user-name");
        By passwordInput = By.Id("password");
        By loginButton = By.Id("login-button");

        public void LoginPageVerify()
        {
            // Updated to use GetAttribute("innerText") for better text retrieval
            string actualTitle = driver.FindElement(loginTitle).GetAttribute("innerText");
            string expectedTitle = "Swag Labs"; // Adjust this to your expected title

            if (!actualTitle.Equals(expectedTitle))
            {
                // Fail the test or log the failure
                Console.WriteLine($"Expected title: {expectedTitle}, Actual title: {actualTitle}");
                throw new Exception("Title mismatch");
            }
        }

        public void InputUser(string text)
        {
            // Updated to clear existing text before input
            driver.FindElement(userInput).Clear();
            driver.FindElement(userInput).SendKeys(text);
        }

        public void InputPassword(string text)
        {
            // Updated to clear existing text before input
            driver.FindElement(passwordInput).Clear();
            driver.FindElement(passwordInput).SendKeys(text);
        }

        public void ClickLogin()
        {
            driver.FindElement(loginButton).Click();
        }
    }
}
