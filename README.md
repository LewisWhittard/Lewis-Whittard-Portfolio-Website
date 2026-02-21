## Overview

This repository contains the source code for the portfolio site of Lewis Whittard, built with ASP.NET Core MVC and structured around a scalable service–repository architecture. The application uses Razor components for semi‑automated rendering, ensuring consistent UI output and a clean separation of concerns across all content types.

## Content Architecture

The site follows a pillar‑page content model supported by a category‑aligned internal search system, improving navigation, topical authority, and SEO clarity. Structured data is generated through a semi‑automatic JSON‑LD pipeline, with the homepage schema defined statically and pillar and cluster pages populated dynamically from the underlying content model. An integrated XML sitemap generator keeps search engines accurately indexed with standards‑compliant output.

## Automation & Reliability

Reliability is maintained through a comprehensive automation test suite, using xUnit for unit and integration testing and Selenium for full end‑to‑end browser automation. Behaviour‑driven development scenarios are implemented with ReqnRoll, providing executable specifications that validate user‑facing behaviour and strengthen long‑term maintainability as the platform evolves.
