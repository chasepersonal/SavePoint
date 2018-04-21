Feature: Immediately Route to "Create Game" page after Registration
  For Easier User access
  Once User successfully registers account
  They can immediately register their games

Scenario: Create Game after Registration
  Given the user starts at the root page
  And the user navigates to the "Register" page
  When the user inputs their information for registration and clicks "Submit"
  Then the user will be taken to their "Create" page in the "Games" area
