using System.Diagnostics;
using Microsoft.Playwright;
using NUnit.Framework;
using SpecFlowPlaywright.Drivers;

namespace SpecFlowPlaywright.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly string _url = "https://accounts.evernote.com/login-with-password"; // Correct URL for the login page
        private ILocator _emailField;
        private ILocator _passwordField;
        private ILocator _errorMessage;


        // Constructor: initialize the _page and any necessary locators
        public LoginPage(IPage page)
        {
            _page = page;
            _emailField = _page.Locator("#email");
            _passwordField = _page.Locator("input[placeholder='Password']");
            _errorMessage = _page.Locator("span.text-secondary-red-400");

        }

        // Method to navigate to the login page
        public async Task NavigateToLoginPage()
        {
            await _page.GotoAsync(_url);
        }

        // Method to enter email and password and click continue
        public async Task EnterCredentials(string email, string password)
        {
            await _emailField.TypeAsync(email);
            await _passwordField.TypeAsync(password);
            await _passwordField.PressAsync("Enter");
            
        }

        // Method to check the error message after clicking continue
        public async Task ErrorMessageAfterClickContinue(string expectedErrorMessage)
        {
            // Get the actual error message from the UI
            string actualErrorMessage = await _errorMessage.InnerTextAsync();

            // Assert that the actual error message matches the expected error message
            Assert.That(actualErrorMessage, Is.EqualTo(expectedErrorMessage), "The error message does not match.");
        }
        
        // Method to check if the "Get started" button is visible after clicking "Continue" and having a successful login
        public async Task CheckUrl(string url)
        {
            // Wait for the page to load completely
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            string currentUrl = _page.Url; // Get the current URL
            if (currentUrl != url)
            {
                throw new Exception($"The current Url is {currentUrl}, expected to be {url}");
            }
        }


    }
}