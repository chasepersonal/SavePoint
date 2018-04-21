# Require necessary modules
require 'rspec'
require 'watir'
require 'cucumber'
require 'page-object'
require 'data_magic'
require 'yaml'

# Initialize Browser object
Before do |scenario|
  if ENV['BROWSER'] == "chrome"
    @b = Watir::Browser.new :chrome
  elsif ENV['BROWSER'] == "edge"
    @b = Watir::Browser.new :edge
  end

  @config = YAML.load_file("config/config.yml")
end

# Close browser at the end of the session
After do |scenario|
  if scenario.failed?
    timestamp = DateTime.now.strftime("%m-%d-%Y %H-%M-%S")
    screenshot = "screenshots/FAILED #{scenario.__id__} #{timestamp}.png"
    @b.screenshot.save (screenshot)
  end
  @b.close
end
