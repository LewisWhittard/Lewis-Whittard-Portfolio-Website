<h2>🚀 Overview</h2>
<p>
  Source code for the portfolio site of Lewis Whittard, built with
  <strong>ASP.NET Core MVC</strong> using a
  <strong>service–repository architecture</strong> and a
  <strong>factory-based content‑block system</strong>. The application separates
  backend content generation from frontend layout through reusable
  <strong>Razor components</strong>. The project focuses on clean architecture,
  scalable content modelling, and automated structured data generation.
</p>

<h2>🧩 Content Architecture</h2>
<p>
  The site implements a <strong>pillar‑page content model</strong> with a
  <strong>category‑aligned internal search engine</strong> to improve navigation,
  topical relevance, and SEO performance.
</p>
<ul>
  <li>
    <strong>Content‑block model</strong> — factory‑constructed blocks rendered by
    Razor components for modular, maintainable page composition.
  </li>
  <li>
    <strong>Dynamic JSON‑LD generation</strong> — structured data produced from
    the content model, including homepage schema, pillar schemas, and content
    cluster schemas.
  </li>
  <li>
    <strong>Internal search and routing</strong> — category‑driven search and
    pillar matching to reinforce relevance and discoverability.
  </li>
  <li>
    <strong>XML sitemap generation</strong> — automated, standards‑compliant
    sitemaps aligned with the site’s content structure.
  </li>
</ul>

<h2>🛡️ Automation &amp; Reliability</h2>
<p>
  The project includes a full automation and observability stack for reliability
  and continuous validation.
</p>
<ul>
  <li><strong>xUnit</strong> — unit and integration testing for .NET</li>
  <li><strong>Selenium</strong> — end‑to‑end browser automation</li>
  <li><strong>ReqnRoll (BDD)</strong> — executable specifications for user‑facing behaviour</li>
  <li><strong>OpenTelemetry</strong> — tracing and performance monitoring for ASP.NET Core</li>
</ul>
