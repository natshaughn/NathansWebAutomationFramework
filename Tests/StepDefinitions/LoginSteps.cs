using NathansWebAutomationFramework.Application.Pages;
using NathansWebAutomationFramework.Tests.Execution;

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
            // Get the base URL from the configuration
            var baseUrl = TestContext.Parameters.Get("BaseUrl")!;

            // Use DriverManager.GoTo to navigate to the URL
            DriverManager.GoTo(baseUrl);

            string actualTitle = login.GetLoginPageTitle();
            string expectedTitle = "Swag Labs";

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Actual title: {actualTitle}, Expected title: {expectedTitle}");
        }

        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            LoginSteps loginSteps = new LoginSteps();
            loginSteps.GivenIAmOnTheLoginPage();
            loginSteps.WhenIEnterTheUsername("standard_user");
            loginSteps.WhenIEnterThePassword("secret_sauce");
            loginSteps.WhenIClickTheLoginButton();
            new InventorySteps().ThenIAmOnTheInventoryPage();
        }

        [When(@"I enter the username '([^']*)'")]
        public void WhenIEnterTheUsername(string username)
        {
            login.InputUsername(username);
        }

        [When(@"I enter the password '([^']*)'")]
        public void WhenIEnterThePassword(string password)
        {
            login.InputPassword(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            login.ClickLoginButton();
        }

        [Then(@"an error message should appear")]
        public void ThenAnErrorMessageShouldAppear()
        {
            string actualErrorMessage = login.GetErrorMessage();
            string expectedErrorMessage = "Epic sadface: Username and password do not match any user in this service";
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), $"Actual error message: {actualErrorMessage}, Expected error message: {expectedErrorMessage}");
        }
    }
}
