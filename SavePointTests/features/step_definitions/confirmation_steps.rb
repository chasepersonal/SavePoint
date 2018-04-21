# Steps related to features that require a confirmation

# Confirm the correct message is being displayed
Then (/the message "(.*?)" will be displayed$/) do |message|
  # Match message on page with expected message
  expect(@b.text).to include("#{message}")
end

# Confirm the user is on the correct nested page
Then (/^the user will be taken to their "(.*?)" page in the "(.*?)" area$/) do |page, area|

  # Get root url from config
  start = @config["pages"]

  # Inhert config value and add import values to create an expected url value
  expected_url = start["root"]
  expected_url += "#{area}/#{page}"

  #confirm current url equals expected url
  expect(@b.url).to eq(expected_url)
end

#Confirm the user is on the correct index page
Then (/^the user will be taken to their "(.*?)" page$/) do |page|

  # Get root url from config
  start = @config["pages"]

  # Inhert config value and add import values to create an expected url value
  expected_url = start["root"]
  expected_url += "#{page}"

  #confirm current url equals expected url
  expect(@b.url).to eq(expected_url)
end

# Confirm the user sees the game they added
Then (/the user will see their game information$/) do
  games = @config["test-game"]
  expect(@b.text).to include(games["title"])
end
