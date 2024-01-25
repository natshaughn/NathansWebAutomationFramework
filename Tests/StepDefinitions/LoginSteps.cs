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
            // Get the base URL from the test context parameters
            var baseUrl = TestContext.Parameters.Get("BaseUrl")!;

            // Use DriverManager.GoTo to navigate to the URL
            DriverManager.GoTo(baseUrl);

            // Verify that the login page is displayed
            login.LoginPageVerify();
        }

        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            // Create an instance of LoginSteps to reuse its methods
            var loginSteps = new LoginSteps();

            // Navigate to the login page
            loginSteps.GivenIAmOnTheLoginPage();

            // Enter the username and password
            loginSteps.WhenIEnterTheUsername("standard_user");
            loginSteps.WhenIEnterThePassword("secret_sauce");

            // Click the login button
            loginSteps.WhenIClickTheLoginButton();

            // Verify being on the inventory page
            new InventorySteps().ThenIAmOnTheInventoryPage();
        }


        [When(@"I enter the username '([^']*)'")]
        public void WhenIEnterTheUsername(string username)
        {
            // Enter the specified username in the login page
            login.InputUser(username);
        }

        [When(@"I enter the password '([^']*)'")]
        public void WhenIEnterThePassword(string password)
        {
            // Enter the specified password in the login page
            login.InputPassword(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            // Click the login button in the login page
            login.ClickLogin();
        }

        [Then(@"an error message should appear")]
        public void ThenAnErrorMessageShouldAppear()
        {
            // Verify that an error message is displayed on the login page
            login.ErrorMessage();
        }

    }
}
