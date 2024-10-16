using Microsoft.Playwright;
using SpecFlowPlaywright.Pages;

namespace SpecFlowPlaywright.Steps.Task_5
{
    [Binding]
    public sealed class StepsLogin
    {
        private readonly LoginPage _login;

        public StepsLogin(ScenarioContext scenarioContext)
        {
            var page = scenarioContext[Configuration.ConfiTags.ScenarioContextPage] as IPage; // Retrieve the IPage instance from ScenarioContext
            _login = new LoginPage(page); // Create a new instance of LoginPage
        }

        [Given(@"I am on the login page")]
        public async Task GivenIAmOnTheLoginPage()
        {
            await _login.NavigateToLoginPage(); // Navigate to the login page
        }

        [Then(@"I should see ""(.*)""")]
        public async Task ThenIShouldSee(string expectedOutcome)
        {
            if (expectedOutcome.Contains("Check your credentials"))
            {
                // Verify the error message
                await _login.ErrorMessageAfterClickContinue(expectedOutcome);
            }
            else
            {
                // Check if the Get Started button is visible
                 _login.CheckUrl(expectedOutcome);
            }
        }

        [When(@"I Login with ""(.*)"" and ""(.*)""")]
        [Given(@"I Login with ""(.*)"" and ""(.*)""")]
        public async Task WhenILoginWithAnd(string email, string password)
        {
            await _login.EnterCredentials(email, password); // Enter credentials
        }
    }
}