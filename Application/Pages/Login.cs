using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Application.Pages
{
    // Represents the Login Page of the application
    public class Login
    {
        private readonly IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locating specific elements on the page - if changed, can change here
        readonly By loginTitle = By.ClassName("login_logo");
        readonly By userInput = By.Id("user-name");
        readonly By passwordInput = By.Id("password");
        readonly By loginButton = By.Id("login-button");
        readonly By loginErrorMsg = By.TagName("h3");

        // Verify the login page has the expected title
        public void LoginPageVerify()
        {
            // Updated to use GetAttribute("innerText") for better text retrieval
            string actualTitle = driver.FindElement(loginTitle).GetAttribute("innerText");
            string expectedTitle = "Swag Labs"; // Expected title

            if (!actualTitle.Equals(expectedTitle))
            {
                // Log the failure details to the console
                Console.WriteLine($"Expected title: {expectedTitle}, Actual title: {actualTitle}");
                throw new Exception("Login page title mismatch");
            }
        }

        // Inputs a username 
        public void InputUser(string text)
        {
            // Clear existing text before input
            driver.FindElement(userInput).Clear();
            driver.FindElement(userInput).SendKeys(text);
        }

        // Inputs a password
        public void InputPassword(string text)
        {
            // Clear existing text before input
            driver.FindElement(passwordInput).Clear();
            driver.FindElement(passwordInput).SendKeys(text);
        }

        // Click the login button on the page
        public void ClickLogin()
        {
            driver.FindElement(loginButton).Click();
        }

        // Check the error message is correct 
        public void ErrorMessage()
        {
            string expectedErrorMessage = "Epic sadface: Username and password do not match any user in this service";
            string actualErrorMessage = driver.FindElement(loginErrorMsg).Text;

            if (!actualErrorMessage.Equals(expectedErrorMessage))
            {
                // Log the failure details to the console
                Console.WriteLine($"Expected error message: {expectedErrorMessage}, Actual error message: {actualErrorMessage}");
                throw new Exception("Error message mismatch");
            }
        }
    }
}
