Feature: Immediately Route to "Create Game" after Registration
  For Easier User access
  Once User successfully registers account
  They can immediately register their games

Scenario: Create Game after Registration
  Given the user navigates to the "Register" page
  When the user inputs their information and submits it
  Then the user will be taken to the "Create Games" page
