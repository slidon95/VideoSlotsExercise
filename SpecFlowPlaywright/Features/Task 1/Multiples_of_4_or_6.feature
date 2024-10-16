Feature: Multiples of 4 or 6 

    Scenario Outline: Count multiples of 4 or 6 in a given array
        Given the input array "<input>"
        When I check if it is multiples of 4 or 6
        Then the result should be <expectedCount>

        Examples:
          | input                  | expectedCount |
          | [4, 5, 6, 8, 10, 12]   | 4             |
          | [1, 2, 3, 5]           | 0             |
          | [-4, -6, -8, -10, -12] | 4             |
          | []                     | 0             |