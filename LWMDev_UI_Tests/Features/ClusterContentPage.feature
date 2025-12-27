Feature: Cluster Content Page

Scenario Outline: Verify Cluster title for multiple pages
	Given ClusterContent: I use Browser "<browser>"
	When ClusterContent: I go to "https://localhost:44325/clustercontent/Index/<pageIndex>"
	Then ClusterContent: the page title is "<expectedTitle>"

Examples:
	| browser | pageIndex                                        | expectedTitle                                                                          |
	| chrome  | portfolio-website-completed                      | Portfolio Website Completed! - Lewis Whittard Software Development                     |
	| firefox | portfolio-website-completed                      | Portfolio Website Completed! - Lewis Whittard Software Development                     |
	| edge    | portfolio-website-completed                      | Portfolio Website Completed! - Lewis Whittard Software Development                     |
	| safari  | portfolio-website-completed                      | Portfolio Website Completed! - Lewis Whittard Software Development                     |
	| chrome  | lewis-matthew-whittard-software-development-logo | Lewis Matthew Whittard Software Development Logo - Lewis Whittard Software Development |
	| firefox | lewis-matthew-whittard-software-development-logo | Lewis Matthew Whittard Software Development Logo - Lewis Whittard Software Development |
	| edge    | lewis-matthew-whittard-software-development-logo | Lewis Matthew Whittard Software Development Logo - Lewis Whittard Software Development |
	| safari  | lewis-matthew-whittard-software-development-logo | Lewis Matthew Whittard Software Development Logo - Lewis Whittard Software Development |

Scenario Outline: Click search on the navigation bar
	Given ClusterContent: I use Browser "<browser>"
	When ClusterContent: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the search button
	Then ClusterContent: the page title is "Search - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click home on the navigation bar
	Given ClusterContent: I use Browser "<browser>"
	When ClusterContent: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the home button
	Then ClusterContent: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Linkedin button
	Given ClusterContent: I use Browser "<browser>"
	When ClusterContent: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the Linkedin button
	Then ClusterContent: I have arrived at linkedin

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click logo on the navigation bar
	Given ClusterContent: I use Browser "<browser>"
	When ClusterContent: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the logo button
	Then ClusterContent: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Github button
	Given ClusterContent: I use Browser "<browser>"
	When ClusterContent: I go to "https://localhost:44325/ClusterContent/Index/portfolio-website-completed" and use the Github button
	Then ClusterContent: I have arrived at Github

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |


Scenario Outline: Click Software Development on the navigation bar
	Given Homepage: I use Browser "<browser>"
	When Homepage: I go to "https://localhost:44325/" and use the Software Development button
	Then Homepage: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |

Scenario Outline: Click Creative Works on the navigation bar
	Given Homepage: I use Browser "<browser>"
	When Homepage: I go to "https://localhost:44325/" and use the Creative Works button
	Then Homepage: the page title is "Home Page - Lewis Whittard Software Development"

Examples:
	| browser |
	| chrome  |
	| firefox |
	| edge    |
	| safari  |