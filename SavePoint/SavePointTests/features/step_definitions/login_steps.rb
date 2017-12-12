Given (/^the user navigates to the "(.*?)" page$/) do |page|

  #Get value for root URL, then add necessary page URL
  url = config('pages.root')
  url += config("pages.#{page}")

  #Naviagte to page URL
  b.goto url
end

When (/^the "(.*?)" logs in with their information$/) do |user|

  #Pull values for the user from the config file
  user_data = config("users.#{user}")

  #Enter user data from the cofig file
  b.text_field(:id => "UserName").set(user_data('username'))
  b.text_field(:id => "Password").set(user_data('password'))
  b.button(:text => "Submit").wait_until_present.click
end

Then (/^the user will be on their "(.*?)" page$/) do |page|

  # Get the expected url
  expected_url = config('pages.root')
  url += config("pages.#{page}")

  # A custom loop that waits 5 seconds until the expected_url is the same as the current url
  start = Time.now
  while b.url != expected_url
    break if (Time.now - start).to_i >= 5
    sleep(0.1)
  end

  # Check if the URL's are the same
  if b.url != expected_url
    error("The current URL and expected URL were not the same: \n Current: #{b.url}\n Expected: #{expected_url}")
  end
end
