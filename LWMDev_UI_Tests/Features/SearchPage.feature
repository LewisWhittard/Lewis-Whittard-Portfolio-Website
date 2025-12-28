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

Scenario Outline: Click Github button
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" and use the Github button
	Then SearchPage: I have arrived at Github

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Software Development on the navigation bar
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" and use the Software Development button
	Then SearchPage: the page title is "Software Development - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Creative Works on the navigation bar
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" and use the Creative Works button
	Then SearchPage: the page title is "Creative Works - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Search Category only All
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" select All and search
	Then SearchPage: Then find the results based on the all category

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Search Category only Software Development
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" select Software Development and search
	Then SearchPage: Then find the results based on the Software Development category

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Search Category Creative Works - Mixed
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select Creative Works and search "<searchTerm>"
    Then SearchPage: Then find the results based on the Creative Works category and Cogetta search 

Examples:
    | browser | searchTerm |
    | Chrome  | Cogetta    |


Scenario Outline: Search Category Creative Works - Spesific
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select Creative Works and search "<searchTerm>"
    Then SearchPage: Then find the results based on the Creative Works category and Logo search

Examples:
    | browser | searchTerm |
    | Chrome  | Logo       |


Scenario Outline: Search Category Creative Works - No Result
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select Creative Works and search "<searchTerm>"
    Then SearchPage: Then find the results based on the Creative Works category and No Result

Examples:
    | browser | searchTerm |
    | Chrome  | No Result  |

Scenario Outline: Search Category All
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" select All and search 
	Then SearchPage: Then find the results based on the all category

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Search Category Software Development
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" select Software Development and search
	Then SearchPage: Then find the results based on the Software Development category

Examples:
	| browser | 
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Search Category Creative Works
	Given SearchPage: I use Browser "<browser>"
	When SearchPage: I go to "https://localhost:44325/search" and select Creative Works and search
	Then SearchPage: Then find the results based on the Creative Works category

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Search Category Software development - Mixed
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select Software Development and search "<searchTerm>"
    Then SearchPage: Then find the results based on the  Software Development category and Cogetta search 

Examples:
    | browser | searchTerm |
    | Chrome  | Cogetta    |


Scenario Outline: Search Category Software development - Spesific
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select Software Development and search "<searchTerm>"
    Then SearchPage: Then find the results based on the Software Development category and Marginal gains

Examples:
    | browser | searchTerm     |
    | Chrome  | Marginal gains |


Scenario Outline: Search Category Software development - No Result
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select Software Development and search "<searchTerm>"
    Then SearchPage: Then find the results based on the Software Development category and No Result

Examples:
    | browser | searchTerm |
    | Chrome  | No Result  |

Scenario Outline: Search Category All - Mixed
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select all and search "<searchTerm>"
    Then SearchPage: Then find the results based on the  all category and Cogetta search 

Examples:
    | browser | searchTerm |
    | Chrome  | Cogetta    |


Scenario Outline: Search Category All - Software Development
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select all and search "<searchTerm>"
    Then SearchPage: Then find the results based on the all category and Marginal gains

Examples:
    | browser | searchTerm     |
    | Chrome  | Marginal gains |
    | Chrome  |                |

Scenario Outline: Search Category All - No Result
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select all and search "<searchTerm>"
    Then SearchPage: Then find the results based on the all category and No Result

Examples:
    | browser | searchTerm |
    | Chrome  | No Result  |

Scenario Outline: Search Category all - Creative Works
    Given SearchPage: I use Browser "<browser>"
    When SearchPage: I go to "https://localhost:44325/search" and select all and search "<searchTerm>"
    Then SearchPage: Then find the results based on the all category and Logo search

Examples:
    | browser | searchTerm |
    | Chrome  | Logo       |