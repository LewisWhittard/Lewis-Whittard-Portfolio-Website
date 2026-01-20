Feature: Pillar Page Creative Works

Scenario Outline: Verify Pillar title for multiple pages
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/<pageIndex>"
	Then PillarCreativeWorks: the page title is "<expectedTitle>"

Examples:
	| browser | pageIndex      | expectedTitle                                        |
	| chrome  | creative-works | Creative Works - Lewis Whittard Software Development |
	| firefox | creative-works | Creative Works - Lewis Whittard Software Development |
	| edge    | creative-works | Creative Works - Lewis Whittard Software Development |
	| safari  | creative-works | Creative Works - Lewis Whittard Software Development |

Scenario Outline: Click search on the navigation bar
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/creative-works" and use the search button
	Then PillarCreativeWorks: the page title is "Search - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click home on the navigation bar
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/creative-works" and use the home button
	Then PillarCreativeWorks: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Linkedin button
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/creative-works" and use the Linkedin button
	Then PillarCreativeWorks: I have arrived at linkedin

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click logo on the navigation bar
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/creative-works" and use the logo button
	Then PillarCreativeWorks: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Github button
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/creative-works" and use the Github button
	Then PillarCreativeWorks: I have arrived at Github

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Software Development on the navigation bar
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/creative-works" and use the Software Development button
	Then PillarCreativeWorks: the page title is "Software Development - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Creative Works on the navigation bar
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/creative-works" and use the Creative Works button
	Then PillarCreativeWorks: the page title is "Creative Works - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Verify brings back correct cluster content
	Given PillarCreativeWorks: I use Browser "<browser>"
	When PillarCreativeWorks: I go to "https://localhost:44325/<pageIndex>"
	Then PillarCreativeWorks: The pillar pages brings back the correct cluster content

Examples:
	| browser | pageIndex      | expectedTitle                                        |
	| chrome  | creative-works | Creative Works - Lewis Whittard Software Development |
	| firefox | creative-works | Creative Works - Lewis Whittard Software Development |
	| edge    | creative-works | Creative Works - Lewis Whittard Software Development |
	| safari  | creative-works | Creative Works - Lewis Whittard Software Development |

Scenario Outline: Click search option
  Given PillarCreativeWorks: I use Browser "<browser>"
  When PillarCreativeWorks: I go to "https://localhost:44325/creative-works"
  Then PillarCreativeWorks: I click the search result "<SearchResult>" and the title is "<Title>"

Examples:
  | browser | SearchResult                                                        | Title                                                                                  |
  | chrome  | SearchResultButton-cogetta                                          | Cogetta - Lewis Whittard Software Development                                          |
  | firefox | SearchResultButton-lewis-matthew-whittard-software-development-logo | Lewis Matthew Whittard Software Development Logo - Lewis Whittard Software Development |