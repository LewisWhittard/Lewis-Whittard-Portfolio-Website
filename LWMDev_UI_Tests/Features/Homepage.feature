Feature: Browser Navigation and Page Title Verification
  This feature tests opening a browser, navigating to a URL, and verifying the page title.

  Scenario: Open Chrome and verify homepage title
    Given I use Browser "chrome"
    When I go to "https://localhost:44325/"
    Then the page title is "Home Page - Lewis Whittard Software Development"

  Scenario: Open Firefox and verify homepage title
    Given I use Browser "firefox"
    When I go to "https://localhost:44325/"
    Then the page title is "Home Page - Lewis Whittard Software Development"

  Scenario: Open Edge and verify homepage title
    Given I use Browser "edge"
    When I go to "https://localhost:44325/"
    Then the page title is "Home Page - Lewis Whittard Software Development"

  Scenario: Open Safari and verify homepage title
    Given I use Browser "safari"
    When I go to "https://localhost:44325/"
    Then the page title is "Home Page - Lewis Whittard Software Development"
