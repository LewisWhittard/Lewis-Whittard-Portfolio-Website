🚀 Overview
This repository contains the source code for the portfolio site of Lewis Whittard, built with ASP.NET Core MVC and organised around a scalable service–repository architecture. The application uses a content‑block model with factory‑based construction, while Razor components provide consistent UI presentation and a clear separation between backend content generation and frontend layout.

🧩 Content Architecture
The site follows a pillar‑page content model supported by a category‑aligned internal search system, improving navigation, topical authority, and SEO clarity.
Key architectural features include:
• 	Content‑block model — strongly typed blocks constructed via factories for predictable, schema‑safe output.
• 	Dynamic structured data — a semi‑automatic JSON‑LD generation library, with static homepage schema and dynamic pillar/cluster schemas derived from the content model.
• 	Search‑aligned routing — category‑driven organisation that reinforces internal relevance and discoverability.
• 	XML sitemap generation — a standards‑compliant sitemap generator that keeps search engines accurately aligned with the site’s structure.
Together, these components form a deterministic, maintainable content pipeline designed for long‑term scalability.

🛡️ Automation & Reliability
Reliability is supported through a comprehensive automation suite:
• 	xUnit for unit and integration testing
• 	Selenium for full end‑to‑end browser automation
• 	ReqnRoll (BDD) for executable specifications that validate user‑facing behaviour
• 	OpenTelemetry instrumentation for APM compatibility and modern observability integration
This combination ensures the system remains stable, testable, and observable as it evolves.
