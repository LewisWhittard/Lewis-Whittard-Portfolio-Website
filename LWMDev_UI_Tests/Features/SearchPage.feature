Feature: SearchPage

Scenario Outline: Click search on the navigation bar
    Given ClusterContent: I use Browser "<browser>"
    When ClusterContent: I go to "https://localhost:44325/search" and use the search button
    Then ClusterContent: the page title is "Search - Lewis Whittard Software Development"

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

    Scenario Outline: Click home on the navigation bar
        Given ClusterContent: I use Browser "<browser>"
        When ClusterContent: I go to "https://localhost:44325/search" and use the home button
        Then ClusterContent: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click Linkedin button
        Given ClusterContent: I use Browser "<browser>"
        When ClusterContent: I go to "https://localhost:44325/search" and use the Linkedin button
        Then ClusterContent: I have arrived at linkedin

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click logo on the navigation bar
        Given ClusterContent: I use Browser "<browser>"
        When ClusterContent: I go to "https://localhost:44325/search" and use the logo button
        Then ClusterContent: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |
