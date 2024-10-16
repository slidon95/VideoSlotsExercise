Feature: Login Functionality

    @ui
    Scenario Outline: Login using email
        Given I am on the login page
        When I Login with "<email>" and "<password>" 
        Then I should see "<expectedOutcome>"

        Examples:
          | email                       | password       | expectedOutcome                     |
          | s.lidonvideoslots@gmail.com | Test.1234_     | https://www.evernote.com/client/web |
          | s.lidonvideoslots@gmail.com | wrongpassword  | Check your credentials. We couldn’t match your email, username, or password. |