using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;
using NUnit.Framework;
using OpenQA.Selenium;

namespace NathansWebAutomationFramework.Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver driver;
        private readonly Login login;

        public LoginSteps()
        {
            this.driver = DriverManager.GetDriver();
            this.login = new Login(driver);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            var baseUrl = TestContext.Parameters.Get("BaseUrl")!;
            DriverManager.GoTo(baseUrl);  // Use DriverManager.GoTo to navigate to the URL
            login.LoginPageVerify();
        }

        [When(@"I enter the username '([^']*)'")]
        public void WhenIEnterTheUsername(string username)
        {
            login.InputUser(username);
        }

        [When(@"I enter the password '([^']*)'")]
        public void WhenIEnterThePassword(string password)
        {
            login.InputPassword(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            login.ClickLogin();
        }
    }
}
