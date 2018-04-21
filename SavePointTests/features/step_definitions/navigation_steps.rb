# Steps related to features that require navigation

#Initiate Browser at home page
Given (/^the user starts at the root page$/) do
  # Retrieve pages information from config
  pages = @config["pages"]
  @b.goto pages["root"]
end

# Navigate to a single link
And (/^the user navigates to the "(.*?)" page$/) do |page|
  @b.link(:text, "#{page}").wait_until_present.click
end

# Navigate between nested pages
And (/^the user navigates to the "(.*?)" page from the "(.*?)" page$/) do |second_page, first_page|
  @b.link(:text, "#{first_page}").wait_until_present.click
  @b.link(:text, "#{second_page}").wait_until_present.click
end
