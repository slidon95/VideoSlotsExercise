using SpecFlowPlaywright.Code;

namespace SpecFlowPlaywright.Steps.Task_1;

[Binding]
public sealed class StepsPalidrome
{
    private string _input;

    // Step definition for Given
    [Given(@"the input string ""(.*)""")]
    public void GivenTheInputString(string inputString)
    {
        _input = inputString;  // Capture the input string from the scenario
    }

    // Step definition for When
    [When(@"I check if it is a palindrome")]
    public void WhenICheckIfItIsAPalindrome()
    {
      Code_task1.IsPalindrome(_input);  // Call the palindrome check function
    }
    
}