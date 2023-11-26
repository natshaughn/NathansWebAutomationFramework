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
            driver.FindElement(loginTitle).Equals("Swag Labs");
        }
        public void InputUser(string text)
        {
            driver.FindElement(userInput).SendKeys(text);
        }

        public void InputPassword(string text)
        {
            driver.FindElement(passwordInput).SendKeys(text);
        }

        public void ClickLogin()
        {
            driver.FindElement(loginButton).Click();
        }
    }
}
