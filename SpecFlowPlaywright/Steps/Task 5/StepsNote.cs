namespace SpecFlowPlaywright.Steps.Task_5;

[Binding]
public class StepsNote
{
    [When(@"I create a new note titled ""(.*)""")]
    public void WhenICreateANewNoteTitled(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I log out from Evernote")]
    public void WhenILogOutFromEvernote()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"I should be redirected to the login page")]
    public void ThenIShouldBeRedirectedToTheLoginPage()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I open the note titled ""(.*)""")]
    public void WhenIOpenTheNoteTitled(string p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"I should see the note content")]
    public void ThenIShouldSeeTheNoteContent()
    {
        ScenarioContext.StepIsPending();
    }
}