# Steps related to features that require inputing information

#Input necessary information on Login page and submit
When (/^the user logs in with their information$/) do
  # Retrieve user information from config
  # Have webdriver input necessary user information and submit
  user = @config["test-user"]
  @b.text_field(:id => "UserName").set user["username"]
  @b.text_field(:id => "Password").set user["password"]
  @b.button(:id => "Login").wait_until_present.click
end

# Input necessary informaiton on Register page and submit
When (/^the user inputs their information for registration and clicks "(.*?)"$/) do |action|
  # Import user information from config file
  # Have webdriver input necessary user information and submit
  user = @config["test-user"]
  @b.text_field(:id => "UserName").set user["username"]
  @b.text_field(:id => "Email").set user["e-mail"]
  @b.text_field(:id => "Password").set user["password"]
  @b.text_field(:id => "ConfirmPassword").set user["password"]
  @b.button(:text => "#{action}").wait_until_present.click
end

# Input necessary information for adding a game
When (/^the user adds their game information and clicks "(.*?)"$/) do |page|
  # Import necessary game information
  # Have webdriver input necessary game information and submit
  games = @config["test-game"]
  @b.text_field(:id => "Title").set games["title"]
  @b.select(:id => "Consoles").option(:text => "Switch").select
  @b.select(:id => "Genre").option(:text => "Action/Adventure").select
  @b.text_field(:id => "ReleaseYear").set games["release_year"]
  @b.text_field(:id => "Rating").set games["rating"]
  @b.text_field(:id => "Comment").set games["comment"]
  @b.button(:text => "#{page}").wait_until_present.click
end

# Input e-mail and take an action
When (/^the user inputs their E-mail address and clicks "(.*?)"$/) do |action|
   user = @config["test-user"]
   @b.text_field(:id => "Email").set user["e-mail"]
   @b.button(:text => "#{action}").wait_until_present.click
end


# Input necessary information to change a password
And (/^they change their password$/) do
  # Retrive user information from config
  # Input new password values and confirm submission
  user = @config["test-user"]
  @b.text_field(:id => "OldPassword").set user["password"]
  @b.text_field(:id => "NewPassword").set user["new_password"]
  @b.text_field(:id => "ConfirmPassword").set user["new_password"]
  @b.button(:text, "Update password").wait_until_present.click
end
