
using SpecFlowPlaywright.Code;

namespace SpecFlowPlaywright.Steps.Task_1

{
    [Binding]
    public sealed class StepsMultiple
    {
        private int[] _input;
        
        // Converts the string input into an integer array
        [Given(@"the input array ""(.*)""")]
        public void GivenTheInputArray(string array)
        {
            array = array.Trim('[', ']');

            // If the array is empty, initialize as empty array
            if (string.IsNullOrEmpty(array))
            {
                _input = new int[0];
            }
            else
            {
                _input = Array.ConvertAll(array.Split(','), int.Parse);
            }
        }

        [When(@"I check if it is multiples of 4 or 6")]
        public void WhenICheckIfItIsMultiplesOfOr()
        { 
            Code_task1.CountMultiplesOf4Or6(_input);
        }
    }
}