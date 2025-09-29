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

    Scenario Outline: Click programming button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the programming button
        Then Homepage: I have arrived at the search page with the programming tickbox ticked

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click testing button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the testing button
        Then Homepage: I have arrived at the search page with the testing tickbox ticked

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click games button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the games button
        Then Homepage: I have arrived at the search page with the games tickbox ticked

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

   Scenario Outline: Click 2D Assets button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the TwoD Assets button
        Then Homepage: I have arrived at the search page with the TwoD Assets tickbox ticked

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |
   
    Scenario Outline: Click 3D Assets button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the ThreeD Assets button
        Then Homepage: I have arrived at the search page with the ThreeD Assets tickbox ticked

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click Blog button
        Given Homepage: I use Browser "<browser>"
        When Homepage: I go to "https://localhost:44325/" and use the Blog button
        Then Homepage: I have arrived at the search page with the Blog tickbox ticked

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