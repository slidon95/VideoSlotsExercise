Feature: Note Creation

    @ui
    Scenario: Login and write a note followed by a logout
       
        Given I am on the login page
        And I Login with "<email>" and "<password>" 
        When I create a new note titled "<note_title>"
        And I log out from Evernote
        Then I should be redirected to the login page
        
        Examples:
       | email                       | password   | note_title |
       | s.lidonvideoslots@gmail.com | Test.1234_ | Test Note  |

    @ui
    Scenario: Login again and verify the note created
        Given I am on the login page
        And I Login with "<email>" and "<password>" 
        When I open the note titled "<note_title>"
        Then I should see the note content
        
        Examples:

          | email                       | password   | note_title | 
          | s.lidonvideoslots@gmail.com | Test.1234_ | Test Note  | 
