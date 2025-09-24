Feature: Homepage

  Scenario Outline: Verify homepage title
    Given I use Browser "<browser>"
    When I go to "https://localhost:44325/"
    Then the page title is "Home Page - Lewis Whittard Software Development"
        Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |
   Scenario Outline: Click search on the navigation bar
    Given I use Browser "<browser>"
    When I go to "https://localhost:44325/" and use the search button
    Then the page title is "Search - Lewis Whittard Software Development"

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

    Scenario Outline: Click home on the navigation bar
        Given I use Browser "<browser>"
        When I go to "https://localhost:44325/" and use the home button
        Then the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

        Scenario Outline: Click Linkedin button
        Given I use Browser "<browser>"
        When I go to "https://localhost:44325/" and use the Linkedin button
        Then I have arrived at linkedin

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |