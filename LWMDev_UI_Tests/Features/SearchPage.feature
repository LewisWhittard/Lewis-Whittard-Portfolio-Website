Feature: SearchPage

Scenario Outline: Click search on the navigation bar
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and use the search button
    Then SearchPage: the page title is "Search - Lewis Whittard Software Development"

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

    Scenario Outline: Click home on the navigation bar
        Given SearchPage: I use Browser "<browser>"
        When SearchPage: I go to "https://localhost:44325/search" and use the home button
        Then SearchPage: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click Linkedin button
        Given SearchPage: I use Browser "<browser>"
        When SearchPage: I go to "https://localhost:44325/search" and use the Linkedin button
        Then SearchPage: I have arrived at linkedin

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click logo on the navigation bar
        Given SearchPage: I use Browser "<browser>"
        When SearchPage: I go to "https://localhost:44325/search" and use the logo button
        Then SearchPage: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: I go to the search page
        Given SearchPage: I use Browser "<browser>"
        When SearchPage: I go to "https://localhost:44325/search"
        Then SearchPage: all search items should be visible

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |


Scenario Outline: I go to the search page and search with no tick boxes
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search"
    And SearchPage: I untick all the search boxes and search
    Then SearchPage: No search items should be visible

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

Scenario Outline: I go to the search page and search with all tick boxes
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search"
    And SearchPage: and search
    Then SearchPage: all search items should be visible

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

Scenario Outline: I go to the search page and search with all tick boxes and click a search result
  Given SearchPage: I use Browser "<browser>"
  When SearchPage: I go to "https://localhost:44325/search"
  And SearchPage: and search
  Then SearchPage: I click a "<SearchResult>" result and go through to the page "<ExpectedURL>"

Examples:
  | browser | SearchResult           | ExpectedURL                                         |
  | chrome  | SearchResultButton 0   | https://localhost:44325/ClusterContent/Index/0     |
  | firefox | SearchResultButton 1   | https://localhost:44325/ClusterContent/Index/1     |
  | edge    | SearchResultButton 2   | https://localhost:44325/ClusterContent/Index/2     |
  | safari  | SearchResultButton 3   | https://localhost:44325/ClusterContent/Index/3     |
  | chrome  | SearchResultButton 4   | https://localhost:44325/ClusterContent/Index/4     |

