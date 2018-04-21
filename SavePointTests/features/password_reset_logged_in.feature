Feature: Display message for successful password reset
  So that the user is aware of a password reset when changing it from inside their account
  Once the password is changed
  They will receive a confirmation that they changed their password

Scenario: Successful Password Reset Message
  Given the user starts at the root page
  And the user navigates to the "Login" page
  When the user logs in with their information
  And the user navigates to the "Password" page from the "Manage" page
  And they change their password
  Then the message "Your password has been changed." will be displayed
