using Microsoft.Playwright;
using SpecFlowPlaywright.Configuration;
using SpecFlowPlaywright.Drivers;


namespace SpecFlowPlaywright.Hooks
{
        [Binding]
        public class Hooks
        {
            private Driver _driver;
            private IPage _page;
            private readonly ScenarioContext _scenarioContext;

            public Hooks(ScenarioContext scenarioContext)
            {
                _scenarioContext = scenarioContext;
            }

            [BeforeScenario]
            public async Task BeforeScenario()
            {
                // Check if the scenario has the @ui tag
                if (_scenarioContext.ScenarioInfo.Tags.Contains(ConfiTags.UiTag))
                {
                    _driver = new Driver(); // Initialize the Driver instance
                    _page = await _driver.GetPageAsync(); // Await the async method

                    // Store the driver and page in ScenarioContext for access in step definitions
                    _scenarioContext[ConfiTags.ScenarioContextDriver] = _driver;
                    _scenarioContext[ConfiTags.ScenarioContextPage] = _page;
                }
            }

            [AfterScenario]
            public async Task AfterScenario()
            {
                // Dispose the driver only if it was initialized
                if (_scenarioContext.TryGetValue(ConfiTags.ScenarioContextDriver, out var value))
                {
                    _driver = (Driver)value;
                    await _driver.DisposeAsync(); // Await the DisposeAsync method
                }
            }

        }
    }
