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

        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            var loginSteps = new LoginSteps();
            loginSteps.GivenIAmOnTheLoginPage();
            loginSteps.WhenIEnterTheUsername("standard_user");
            loginSteps.WhenIEnterThePassword("secret_sauce");
            loginSteps.WhenIClickTheLoginButton();
            new InventorySteps().ThenIAmOnTheInventoryPage(); // Assuming you want to verify being on the inventory page
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

        [Then(@"an error message should appear")]
        public void ThenAnErrorMessageShouldAppear()
        {
            login.ErrorMessage();
        }


    }
}
