Feature: Send e-mail for password reset
  So that a user is aware of a password reset when not logged in to their account
  They can get an e-mail link sent to them
  Then they will receive a confirmation message that the e-mail was sent

Scenario: Receive confirmation that e-mail was screenshot
  Given the user starts at the root page
  And the user navigates to the "Forgot your password?" page from the "Login" page
  When the user inputs their E-mail address and clicks "Submit"
  Then the user will be taken to their "ForgotPasswordConfirmation" page in the "Manage" area
