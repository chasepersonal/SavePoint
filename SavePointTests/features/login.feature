Feature: Route to UserHome Page upon successful login
  So that a user easily navigate their account
  Once a user successfully logs in
  The user will be taken to their UserHome page

Scenario: See Game List after successful login
  Given the user starts at the root page
  And the user navigates to the "Login" page
  When the user logs in with their information
  Then the user will be taken to their "UserHome" page in the "Home" area
