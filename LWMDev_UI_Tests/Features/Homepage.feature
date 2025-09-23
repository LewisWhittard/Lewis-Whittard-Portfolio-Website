Feature: Navigation and Search Defaults

  Scenario Outline: Visiting the homepage
    Given I use Browser "<browser>" and I goto "https://localhost:44325/"
    When And I wait for the page to load
    Then the page title is "Home Page - Lewis Whittard Software Development"

  Examples:
    | browser  |
    | Chrome   |
    | Firefox  |
    | Edge     |