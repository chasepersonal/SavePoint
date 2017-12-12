# Step Definitions for reg_to_create.feature

# Initiate Browser at home page, then naviagte to the "Register" page
Given (/^the user navigates to the "Register" page$/) do
  @b.goto "https://localhost:44307"
  @b.link(:text, "Register").wait_until_present.click
end

# User inputs necessary information on the "Register Account" page and submit
When (/^the user inputs their information and submits it$/) do
  @b.text_field(:id => "UserName").set "SomeZero"
  @b.text_field(:id => "Email").set "lolhorse@fakemail.com"
  @b.text_field(:id => "Password").set "P@$$wyrd4"
  @b.text_field(:id => "ConfirmPassword").set "P@$$wyrd4"
  @b.button(:text => "Submit").wait_until_present.click
end

Then (/^the user will be taken to the "Create Games" page$/) do

  # Get the expected url
  expected_url = "https://localhost:44307/Games/Create"

  # A custom loop that waits 5 seconds until the expected_url is the same as the current url
  start = Time.now
  while @b.url != expected_url
    break if (Time.now - start).to_i >= 5
    sleep(0.1)
  end

  # Check if the URL's are the same
  if @b.url != expected_url
    error("The current URL and expected URL were not the same: \n Current: #{@b.url}\n Expected: #{expected_url}")
  end
end
