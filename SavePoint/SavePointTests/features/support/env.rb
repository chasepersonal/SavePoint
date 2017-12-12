# Require necessary modules
require 'rspec'
require 'page-object'
require 'data_magic'
require 'yaml'

#Set configuration for Watir
World(Watir)

# Initialize Browser object
if !ENV['BROWSER'] || ENV['BROWSER'] == 'chrome'
  require 'watir'
  b = Watir::Browser.new :chrome
end

# Intialize browser object before all other functions
Before do
  @b = b
end

# Close browser at the end of the session
at_exit do
  b.close
end
