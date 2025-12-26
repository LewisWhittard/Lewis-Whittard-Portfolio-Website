Feature: Homepage

  Scenario Outline: Verify homepage title
    Given Homepage: I use Browser "<browser>"
    When Homepage: I go to "https://localhost:44325/"
    Then Homepage: the page title is "Home Page - Lewis Whittard Software Development"
        Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |
   Scenario Outline: Click search on the navigation bar
    Given Homepage: I use Browser "<browser>"
    When Homepage: I go to "https://localhost:44325/" and use the search button
    Then Homepage: the page title is "Search - Lewis Whittard Software Development"

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

    Scenario Outline: Click home on the navigation bar
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the home button
        Then Homepage: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click Linkedin button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the Linkedin button
        Then Homepage: I have arrived at linkedin
        
        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |


    Scenario Outline: Click logo on the navigation bar
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the logo button
        Then Homepage: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click Github button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the Github button
        Then Homepage: I have arrived at Github
        
        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |