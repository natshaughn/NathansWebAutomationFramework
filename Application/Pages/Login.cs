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

        private ElementWrapper LoginButton => new ElementWrapper(driver, By.XPath("//input[@id='login-button']"));
        private ElementWrapper LoginErrorMsg => new ElementWrapper(driver, By.XPath("//div/h3"));
        private ElementWrapper LoginTitle => new ElementWrapper(driver, By.XPath("//div[@class='login_logo']"));
        private ElementWrapper PasswordInput => new ElementWrapper(driver, By.XPath("//input[@id='password']"));
        private ElementWrapper UserInput => new ElementWrapper(driver, By.XPath("//input[@id='user-name']"));

        public string GetLoginPageTitle()
        {
            return LoginTitle.GetText();
        }

        public void InputUsername(string text)
        {
            UserInput.SendKeys(text);
        }

        public void InputPassword(string text)
        {
            PasswordInput.SendKeys(text);
        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return LoginErrorMsg.GetText();
        }
        public void LoginToSwagLabs(string username, string password)
        {
            InputUsername(username);
            InputPassword(password);
            ClickLoginButton();
        }
    }
}
