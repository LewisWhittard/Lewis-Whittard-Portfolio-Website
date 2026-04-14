Feature: LegalPage

Scenario Outline: Verify legal title
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal"
	Then LegalPage: the page title is "Legal Page - Lewis Whittard Software Development"
Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |
Scenario Outline: Click search on the navigation bar
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the search button
	Then LegalPage: the page title is "Search - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click home on the navigation bar
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the home button
	Then LegalPage: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Linkedin button
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the Linkedin button
	Then LegalPage: I have arrived at linkedin
        
Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |


Scenario Outline: Click logo on the navigation bar
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the logo button
	Then LegalPage: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Github button
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the Github button
	Then LegalPage: I have arrived at Github
        
Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Software Development on the navigation bar
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the Software Development button
	Then LegalPage: the page title is "Software Development - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Creative Works on the navigation bar
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the Creative Works button
	Then LegalPage: the page title is "Creative Works - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click legal on the navigation bar
	Given LegalPage: I use Browser "<browser>"
	When LegalPage: I go to "https://localhost:44325/legal" and use the legal button
	Then LegalPage: the page title is "Legal Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |