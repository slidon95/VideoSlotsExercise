Feature: Palindrome

    Scenario Outline: Check if the input string is a palindrome
        Given the input string "<input>"
        When I check if it is a palindrome
        Then the result should be <expectedResult>

        Examples:
          | input                       | expectedResult |
          | Madam, I'm Adam.            | true           |
          | Able was I, ere I saw Elba. | true           |
          | Hello, World!               | false          |
          | 12321                       | true           |
          | ""                          | true           |
          | A                           | true           |
          | !!!                         | true           |