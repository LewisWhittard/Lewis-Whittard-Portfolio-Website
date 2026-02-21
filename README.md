##Overview

This repository contains the source code for the portfolio site of Lewis Whittard, built with ASP.NET Core MVC and structured around a scalable service–repository architecture. The application uses a content‑block model with factory‑based construction, with Razor components responsible for consistent UI presentation and a clean separation between backend content generation and frontend layout.


## Content Architecture

The site follows a pillar‑page content model supported by a category‑aligned internal search system, improving navigation, topical authority, and SEO clarity. Structured data is generated through a semi‑automatic JSON‑LD library, with the homepage schema defined statically and pillar and cluster pages populated dynamically from the underlying content model. An integrated XML sitemap generator keeps search engines accurately indexed with standards‑compliant output.

## Automation & Reliability

Reliability is maintained through a comprehensive automation test suite, using xUnit for unit and integration testing and Selenium for full end‑to‑end browser automation. Behaviour‑driven development scenarios are implemented with ReqnRoll, providing executable specifications that validate user‑facing behaviour. OpenTelemetry instrumentation is included for APM compatibility, ensuring the application can integrate cleanly with modern observability platforms as the system evolves.
