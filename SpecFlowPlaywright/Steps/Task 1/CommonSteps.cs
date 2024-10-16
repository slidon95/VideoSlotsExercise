using SpecFlowPlaywright.Code;


namespace SpecFlowPlaywright.Steps.Task_1
{
    [Binding]
    public class CommonSteps
    {
        private int _result=Code_task1.GetCountResult();  // For multiples of 4 or 6
        private bool _isPalindromeResult = Code_task1.GetPalindromeResult(); // For palindrome checks
        

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expected)
        {
            // Check if the expected result is a boolean
            if (bool.TryParse(expected, out bool expectedBool))
            {
                if (_isPalindromeResult != expectedBool)
                {
                    throw new Exception($"Expected {expectedBool}, but got {_isPalindromeResult}");
                }
            }
            // Check if the expected result is an integer
            else if (int.TryParse(expected, out int expectedCount))
            {
                if (_result != expectedCount)
                {
                    throw new Exception($"Expected {expectedCount}, but got {_result}");
                }
            }
            else
            {
                throw new Exception($"Expected result '{expected}' is neither a boolean nor an integer.");
            }
        }
    }
}