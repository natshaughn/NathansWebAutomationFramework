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
            driver = DriverManager.GetDriver();
            login = new Login(driver);
        }

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            string baseUrl = TestContext.Parameters.Get("BaseUrl")!;
            DriverManager.GoTo(baseUrl);

            string actualTitle = login.GetLoginPageTitle();
            string expectedTitle = "Swag Labs";

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), $"Actual title: {actualTitle}, Expected title: {expectedTitle}");
        }

        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            GivenIAmOnTheLoginPage();
            login.LoginToSwagLabs("standard_user", "secret_sauce");
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
