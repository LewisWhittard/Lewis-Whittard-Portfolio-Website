<h2>🚀 Overview</h2>
<p>
  This repository contains the source code for the portfolio site of 
  <strong>Lewis Whittard</strong>, built with <strong>ASP.NET Core MVC</strong> and 
  organised around a scalable <strong>service–repository architecture</strong>. 
  The application uses a <strong>content‑block model</strong> with factory‑based 
  construction, while Razor components provide consistent UI presentation and a 
  clear separation between backend content generation and frontend layout.
</p>

<hr>

<h2>🧩 Content Architecture</h2>
<p>
  The site follows a <strong>pillar‑page content model</strong> supported by a 
  <strong>category‑aligned internal search system</strong>, improving navigation, 
  topical authority, and SEO clarity.
</p>

<ul>
  <li><strong>Content‑block model</strong> — blocks constructed via factories and rendered by razor components </li>
  <li><strong>Dynamic structured data</strong> — a semi‑automatic JSON‑LD generation library, with static homepage schema and dynamic pillar/content cluster schemas derived from the content model.</li>
  <li><strong>Internal Search and pillar matching routing </strong> — category‑driven organisation that reinforces internal relevance and discoverability.</li>
  <li><strong>XML sitemap generation</strong> — a standards‑compliant sitemap generator that keeps search engines accurately aligned with the site’s structure.</li>
</ul>
<hr>

<h2>🛡️ Automation & Reliability</h2>
<p>
  Reliability is supported through a comprehensive automation suite:
</p>

<ul>
  <li><strong>xUnit</strong> for unit and integration testing</li>
  <li><strong>Selenium</strong> for full end‑to‑end browser automation</li>
  <li><strong>ReqnRoll (BDD)</strong> for executable specifications that validate user‑facing behaviour</li>
  <li><strong>OpenTelemetry</strong> for application performance monitoring (APM) and modern observability integration</li>
</ul>
