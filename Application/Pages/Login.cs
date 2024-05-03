using NathansWebAutomationFramework.Application.Elements;
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
        private ElementWrapper LoginButton => new ElementWrapper(driver, By.XPath("//input[@id='login-button']"));
        private ElementWrapper LoginErrorMsg => new ElementWrapper(driver, By.XPath("//div/h3"));
        private ElementWrapper LoginTitle => new ElementWrapper(driver, By.XPath("//div[@class='login_logo']"));
        private ElementWrapper PasswordInput => new ElementWrapper(driver, By.XPath("//input[@id='password']"));
        private ElementWrapper UserInput => new ElementWrapper(driver, By.XPath("//input[@id='user-name']"));

        // Verify the login page has the expected title
        public void LoginPageVerify()
        {
            string actualTitle = LoginTitle.GetText();
            string expectedTitle = "Swag Labs";

            if (!actualTitle.Equals(expectedTitle))
            {
                Console.WriteLine($"Expected title: {expectedTitle}, Actual title: {actualTitle}");
                throw new Exception("Login page title mismatch");
            }
        }

        // Inputs a username 
        public void InputUser(string text)
        {
            UserInput.SendKeys(text);
        }

        // Inputs a password
        public void InputPassword(string text)
        {
            PasswordInput.SendKeys(text);
        }

        // Click the login button on the page
        public void ClickLogin()
        {
            LoginButton.Click();
        }

        // Check the error message is correct 
        public void ErrorMessage()
        {
            string expectedErrorMessage = "Epic sadface: Username and password do not match any user in this service";
            string actualErrorMessage = LoginErrorMsg.GetText();

            if (!actualErrorMessage.Equals(expectedErrorMessage))
            {
                Console.WriteLine($"Expected error message: {expectedErrorMessage}, Actual error message: {actualErrorMessage}");
                throw new Exception("Error message mismatch");
            }
        }
    }
}
