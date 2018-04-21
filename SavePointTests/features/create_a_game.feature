Feature: Show user that a game was added successfully
  To show a user that their game was added successfully
  When a user successfully adds a game
  The user will be taken to their Games page and show the added game

Scenario: Show added game on Game List page
  Given the user starts at the root page
  And the user navigates to the "Login" page
  When the user logs in with their information
  And the user navigates to the "Add a Game" page
  When the user adds their game information and clicks "Create"
  Then the user will be taken to their "Games" page
  Then the user will see their game information
