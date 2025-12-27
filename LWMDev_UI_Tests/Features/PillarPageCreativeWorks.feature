Feature: Pillar Page Creative Works

Scenario Outline: Verify Cluster title for multiple pages
  Given PillarCreativeWorks: I use Browser "<browser>"
  When PillarCreativeWorks: I go to "https://localhost:44325/clustercontent/Index/<pageIndex>"
  Then PillarCreativeWorks: the page title is "<expectedTitle>"

Examples:
  | browser | pageIndex            | expectedTitle                                              |
  | chrome  | software-development | Software Development - Lewis Whittard Software Development |
  | firefox | software-development | Software Development - Lewis Whittard Software Development |
  | edge    | software-development | Software Development - Lewis Whittard Software Development |
  | safari  | software-development | Software Development - Lewis Whittard Software Development |

Scenario Outline: Click search on the navigation bar
    Given PillarCreativeWorks: I use Browser "<browser>"
    When PillarCreativeWorks: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the search button
    Then PillarCreativeWorks: the page title is "Search - Lewis Whittard Software Development"

    Examples:
      | browser |
      | chrome  |
      | firefox |
      | edge    |
      | safari  |

    Scenario Outline: Click home on the navigation bar
        Given PillarCreativeWorks: I use Browser "<browser>"
        When PillarCreativeWorks: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the home button
        Then PillarCreativeWorks: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click Linkedin button
        Given PillarCreativeWorks: I use Browser "<browser>"
        When PillarCreativeWorks: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the Linkedin button
        Then PillarCreativeWorks: I have arrived at linkedin

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click logo on the navigation bar
        Given PillarCreativeWorks: I use Browser "<browser>"
        When PillarCreativeWorks: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the logo button
        Then PillarCreativeWorks: the page title is "Home Page - Lewis Whittard Software Development"

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |

    Scenario Outline: Click Github button
        Given PillarCreativeWorks: I use Browser "<browser>"
        When PillarCreativeWorks: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the Github button
        Then PillarCreativeWorks: I have arrived at Github

        Examples:
        | browser |
        | chrome  |
        | firefox |
        | edge    |
        | safari  |