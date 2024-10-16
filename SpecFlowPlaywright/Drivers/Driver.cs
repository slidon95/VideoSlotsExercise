using Microsoft.Playwright;

namespace SpecFlowPlaywright.Drivers
{
    public class Driver : IAsyncDisposable
    {
        private IBrowser? _browser;
        private IPage? _page;

        public async Task<IPage> GetPageAsync()
        {
            if (_page == null)
            {
                // Playwright
                var playwright = await Playwright.CreateAsync();

                // Browser
                _browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                {
                    Headless = false
                });

                // Page
                _page = await _browser.NewPageAsync();
            }
            return _page; // Return the page instance
        }

        public async ValueTask DisposeAsync()
        {
            if (_browser != null)
            {
                await _browser.CloseAsync(); // Close the browser when disposal is called
                _browser = null; // Clean up the reference
                _page = null; // Clean up the reference
            }
        }
    }
}