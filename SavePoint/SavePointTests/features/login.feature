Feature: Route to "Games" Page upon successful login
  So that a user can view their games easier
  Once a user successfully logs in
  The user will be taken to their games list

Scenario: See Game List after successful login
  Given the user navigates to the "Log In" page
  When the "test-user" logs in with their information
  Then the user will be on their "Games" page
