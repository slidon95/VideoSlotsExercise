namespace SpecFlowPlaywright.Code
{
    public static class Code_task1
    {
       
            // Static fields to store results
            private static bool _isPalindromeResult;
            private static int _multipleResult;

            // Method to count multiples of 4 or 6
            public static int CountMultiplesOf4Or6(int[] numbers)
            {
                _multipleResult = 0; // Reset the count before calculation
                foreach (var number in numbers)
                {
                    if (Math.Abs(number) % 4 == 0 || Math.Abs(number) % 6 == 0)
                    {
                        _multipleResult++;
                    }
                }

                return _multipleResult; // Return the count of multiples
            }

            // Method to check if a string is a palindrome
            public static bool IsPalindrome(string input)
            {
                // Remove non-alphanumeric characters and convert the string to lowercase
                var normalizedInput = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();

                // Check if the normalized string is equal to its reverse
                _isPalindromeResult = normalizedInput.SequenceEqual(normalizedInput.Reverse());
                return _isPalindromeResult; // Return the palindrome check result
            }

            // Method to get the stored palindrome result
            public static bool GetPalindromeResult()
            {
                return _isPalindromeResult; // Return the palindrome result
            }

            // Method to get the stored count result
            public static int GetCountResult()
            {
                return _multipleResult; // Return the count result
            }
        }
    }
