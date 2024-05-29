using NathansWebAutomationFramework.Application.Elements;

namespace NathansWebAutomationFramework.Application.Pages
{
    public class Login
    {
        private readonly IWebDriver driver;
        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        private ElementWrapper LoginButton => new(driver, By.Id("login-button"));
        private ElementWrapper LoginErrorMsg => new(driver, By.XPath("//div/h3"));
        private ElementWrapper LoginTitle => new(driver, By.XPath("//div[@class='login_logo']"));
        private ElementWrapper PasswordInput => new(driver, By.Id("password"));
        private ElementWrapper UserInput => new(driver, By.Id("user-name"));

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return LoginErrorMsg.GetText();
        }
        public string GetLoginPageTitle()
        {
            return LoginTitle.GetText();
        }
        public void InputPassword(string text)
        {
            PasswordInput.SendKeys(text);
        }

        public void InputUsername(string text)
        {
            UserInput.SendKeys(text);
        }

        public void LoginToSwagLabs(string username, string password)
        {
            InputUsername(username);
            InputPassword(password);
            ClickLoginButton();
        }
    }
}
