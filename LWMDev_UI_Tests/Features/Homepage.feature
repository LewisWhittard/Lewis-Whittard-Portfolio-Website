Feature: Browser Navigation and Page Title Verification
  This feature tests opening a browser, navigating to a URL, and verifying the page title.

Feature: Browser Navigation and Page Title Verification
  This feature tests opening different browsers, navigating to a URL, and verifying the page title.

  Scenario Outline: Open browser and verify homepage title
    Given I use Browser "<browser>"
    When I go to "https://localhost:44325/"
    Then the page title is "Home Page - Lewis Whittard Software Development"
        Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |
   Scenario Outline: Open browser and click search on the navigation bar
    Given I use Browser "<browser>"
    When I go to "https://localhost:44325/" and use the search button
    Then the page title is "Search - Lewis Whittard Software Development"

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

    Scenario Outline: Open browser and click home on the navigation bar
        Given I use Browser "<browser>"
        When I go to "https://localhost:44325/" and use the home button
        Then the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

