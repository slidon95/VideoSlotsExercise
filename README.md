## First, Second and Fifth Question

This repository contains the implementation of the technical exercises requested, including two main sets of tasks: **Task 1** (algorithmic exercises) and **Task 5** (UI automated tests using SpecFlow and Playwright for Evernote). The project was developed in **C#** using **SpecFlow** for BDD and **Playwright** for UI tests. The structure follows a modular organization, divided into several folders to ensure scalability and maintainability.

### Folder Structure

- **Code**: Contains business logic and functions for Task 1.
  - `Code_task1.cs`: Implements the algorithms for multiples of 4 and 6, and palindrome checks.
  
- **Configuration**: Configuration files.
  - `ConfigTags.cs`: Contains configurations for SpecFlow tags.
  
- **Drivers**: Manages the drivers for automation.
  - `Driver.cs`: Contains Playwright driver configuration.
  
- **Features**: This directory holds `.feature` files, following the Gherkin syntax for describing test scenarios.
  - **Evernote [Task 5]**: E2E automation tests for the Evernote application.
    - `Login.feature`: Scenarios for login (successful and unsuccessful).
    - `Note.feature`: Tests for creating and verifying notes.(not fully implemented due to issue).
  
  - **Task 1**: Test scenarios for algorithmic exercises.
    - `Multiples_of_4_or_6.feature`: Tests for the multiples of 4 or 6 function.
    - `Palindrome.feature`: Tests for the palindrome function.

- **Hooks**: Defines pre- and post-conditions for the tests.
  - `Hook.cs`: Contains initialization and teardown settings for tests.

- **Pages**: Page Objects that encapsulate interactions with the UI pages.
  - `LoginPage.cs`: Implements login page actions.

- **Steps**: Step definitions for the tests described in the `.feature` files.
  - **Task 1**: Steps for the algorithmic tests.
    - `CommonSteps.cs`: Common steps across tests.
    - `StepsMultiple.cs`: Step definitions for testing multiples of 4 or 6.
    - `StepsPalindrome.cs`: Step definitions for testing palindromes.
  
  - **Task 5**: Steps for Evernote E2E tests.
    - `StepsLogin.cs`: Steps for login scenarios (success and failure).
    - `StepsNote.cs`: Steps for creating and verifying notes. (not fully implemented due to a post-login issue).

## Implemented Tasks

### Task 1

1. **Multiples of 4 and 6**: Implements a function that takes an array of numbers and returns how many values are multiples of either 4 or 6.
   - File: `Code_task1.cs`
   - Associated test: `Multiples_of_4_or_6.feature`
  
2. **Palindrome**: Function that checks if a string is a palindrome.
   - File: `Code_task1.cs`
   - Associated test: `Palindrome.feature`

### Task 5 - E2E Automation Tests for Evernote
**Note: We encountered an issue where, after logging in successfully, the page was not loading properly, which blocked further interaction with the UI. Therefore, only the login tests (successful and unsuccessful) were implemented. For successful login, an assertion was made based on the URL, which is not considered best practice, but it was necessary due to the page loading issue.**

1. **Unsuccessful login**: Test to ensure login fails when incorrect credentials are used.
   - `.feature` file: `Login.feature`
   - Step definitions: `StepsLogin.cs`

2. **Successful login**: Test to ensure login succeeds with correct credentials.
**Due to the page not loading after login, an assertion was made based on the URL to verify successful login, even though asserting based on the URL is not ideal.**
   - `.feature` file: `Login.feature`
   - Step definitions: `StepsLogin.cs`

4. **Create a note and logout**: Test to create a new note after logging in and ensure logout works correctly and **Reopen note after logging in again**: Test to ensure the note created previously can be reopened after logging back in.
**Not fully implemented due to the post-login page loading issue.**
   - `.feature` file: `Note.feature`
   - Step definitions: `StepsNote.cs`

## Setting Up the Development Environment

### Requirements

- .NET SDK
- Rider or Visual Studio
- Playwright
- SpecFlow

### Setup Steps for **Rider**

1. **Install .NET SDK**:
   - Download and install the .NET SDK: [Download .NET SDK](https://dotnet.microsoft.com/download).
   
2. **Install Rider**:
   - Download and install JetBrains Rider: [Download Rider](https://www.jetbrains.com/rider/download/).

3. **Install SpecFlow and Playwright**:
   - Run the following command in the terminal to add SpecFlow and Playwright:
     ```bash
     dotnet add package SpecFlow
     dotnet add package Microsoft.Playwright
     dotnet build
     ```
   - Install the Playwright browsers with:
     ```bash
     playwright install
     ```

4. **Run the Project**:
   - Execute the tests directly in Rider by clicking on the **Run** button.

### Setup Steps for **Visual Studio**

1. **Install .NET SDK**:
   - Download and install the .NET SDK: [Download .NET SDK](https://dotnet.microsoft.com/download).

2. **Install Visual Studio**:
   - Download and install Visual Studio: [Download Visual Studio](https://visualstudio.microsoft.com/).

3. **Install SpecFlow and Playwright**:
   - Open the **Package Manager Console** and run:
     ```bash
     Install-Package SpecFlow
     Install-Package Microsoft.Playwright
     dotnet build
     ```
   - Install the Playwright browsers:
     ```bash
     playwright install
     ```

4. **Run the Project**:
   - Execute the tests by clicking on the **Run** button in Visual Studio.

## Third question
At the moment, I don’t have access to Videoslots to explore the platform; however, I consider the following as critical bugs:

- Not being able to log in or register - Without the ability to log in or register, users cannot access their accounts or create new ones, making the platform entirely unusable for both existing and potential new customers.
- Issues with making deposits and withdrawals- These are fundamental transactions on a gambling platform. If users cannot deposit funds, they are unable to play. Similarly, withdrawal issues prevent users from accessing their winnings, which can lead to frustration and mistrust.
- Not being able to access or play games in the online casino- The primary purpose of an online casino is to allow users to play games. If users cannot access or play games, it defeats the main reason for using the platform, resulting in a poor user experience and potential loss of users to competitors.


## Fourth question

Imagine you are dealing with a DB which has 2 tables, users table which holds the registered clients in a system and users_creds table which contains the users’ credentials for those who are still active in the system. Both tables are linked with the ids.

![image](https://github.com/user-attachments/assets/6f9a5368-ed7d-48de-861f-d10c334146f1)

1. Create an SQL Query which retrieves the id, name and surname of all registered users under country Malta.
```bash
SELECT u.id, u.name, u.surname
FROM users u
WHERE u.country = 'MT';
```
2. Create an SQL Query which retrieves the id, name, surname of all registered users that are NOT registered under country Portugal and France.
```bash
SELECT u.id, u.name, u.surname
FROM users u
WHERE u.country NOT IN ('PT', 'FR');
```
3. Create an SQL Query which retrieves the id, name and surname of all registered users which are still active.**(i am considering that active is equal failed_logins = 0)**
```bash
SELECT u.id, u.name, u.surname
FROM users u
JOIN users_creds uc ON u.id = uc.id
WHERE uc.failed_logins = 0;
```
4. Create an SQL Query which retrieves the name, surname and emails of all registered users which requires a reset password.

```bash
SELECT u.name, u.surname, u.email
FROM users u
JOIN users_creds uc ON u.id = uc.id
WHERE uc.required_reset_password = 1;
```
