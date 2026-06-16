<h2>🚀 Overview</h2>
<p>
  Source code for the portfolio site of Lewis Whittard. The solution is built with
  <strong>ASP.NET Core MVC</strong> and structured as a multi-project solution, separating
  the web application from a set of independently testable class libraries. The architecture
  follows a <strong>service–repository pattern</strong> with a <strong>factory-based
  content‑block system</strong> for composing page content from typed, modular blocks.
</p>

<h2>🏗️ Solution Structure</h2>
<p>The solution is divided into the web application, supporting libraries, and their corresponding test projects.</p>

<h3>Web Application — <code>LMWDev</code></h3>
<p>
  The ASP.NET Core MVC host. Controllers handle routing and view-model construction;
  Razor views and Razor components handle rendering. Every controller action is instrumented
  with <strong>OpenTelemetry</strong> activity spans covering route validation, data retrieval,
  JSON‑LD generation, and view-model construction. Cookie consent and session state are
  resolved at the controller level before any PII-adjacent telemetry tag is written.
</p>
<ul>
  <li><strong>Home</strong> — renders the homepage with statically generated JSON‑LD.</li>
  <li><strong>PillarPage</strong> — serves the two content pillars (<code>software-development</code>, <code>creative-works</code>) with page retrieval, category-scoped search, and dynamic JSON‑LD.</li>
  <li><strong>ClusterContent</strong> — serves individual articles nested under a pillar (<code>/{pillar}/{id}</code>), validating both page type and pillar–category alignment before rendering.</li>
  <li><strong>Search</strong> — category-filtered full-text search over the page library.</li>
  <li><strong>SiteMap</strong> — serves the generated XML sitemap.</li>
  <li><strong>Legal / Accessibility / Cookie</strong> — static informational and consent pages.</li>
</ul>

<h3>Umbraco CMS — <code>LMWDevUmbraco</code></h3>
<p>
  An <strong>Umbraco</strong> instance running as a headless CMS. Media assets — images and
  video — are delivered through Umbraco's Content Delivery API with <strong>AVIF</strong>
  support enabled for modern image formats. The web application fetches assets from Umbraco
  at runtime; no media is bundled directly into <code>LMWDev</code>.
</p>

<h2>📦 Libraries</h2>

<h3>Page Library — <code>Page_Library</code></h3>
<p>
  The core domain library. Defines the content model, page retrieval, and search.
</p>
<ul>
  <li>
    <strong>Page entities</strong> — <code>PageBase</code> holds the common page contract:
    external ID, type, title, publish date, category, meta, author, and a typed list of
    content blocks. Concrete page types extend this base.
  </li>
  <li>
    <strong>Content blocks</strong> — five block types (<code>HeaderBlock</code>,
    <code>ParagraphBlock</code>, <code>ImageBlock</code>, <code>VideoBlock</code>,
    <code>HyperlinkBlock</code>) share a common <code>ContentBlockBase</code> built from
    a <code>ContentBlockDTO</code>. The factory resolves the correct concrete type from
    the block-type discriminator at runtime.
  </li>
  <li>
    <strong>Content block factory</strong> — a switch-dispatched factory converts raw
    <code>ContentBlockDTO</code> objects into typed <code>IContentBlock</code> implementations,
    keeping the page assembly logic centralised and the individual block classes clean.
  </li>
  <li>
    <strong>Meta entities</strong> — each page carries a <code>Meta</code> object with title,
    description, image URL, and alt text, used for both HTML meta tags and JSON‑LD output.
  </li>
  <li>
    <strong>Repository</strong> — <code>JsonContentRepository</code> hydrates pages from
    structured JSON, and a separate content repository handles image and video retrieval.
  </li>
  <li>
    <strong>Page service</strong> — exposes <code>GetPage(id)</code> and
    <code>Search(query, category)</code> for use by the MVC controllers.
  </li>
</ul>

<h3>JSON‑LD Library — <code>JsonLD_Library</code></h3>
<p>
  Generates <strong>Schema.org JSON‑LD</strong> structured data for three surface types:
</p>
<ul>
  <li><strong>Homepage</strong> — static schema generated once at startup.</li>
  <li><strong>Pillar pages</strong> — dynamic schema derived from the page model and its category-scoped search results.</li>
  <li><strong>Cluster content pages</strong> — article-level schema generated from the individual page model.</li>
</ul>

<h3>Sitemap Library — <code>Sitemap_Library</code></h3>
<p>
  Generates a standards-compliant <strong>XML sitemap</strong> from the page library,
  keeping the sitemap in sync with the site's actual content structure automatically.
</p>

<h3>Breadcrumb Library — <code>Breadcrumb_Library</code></h3>
<p>Builds breadcrumb trails from the pillar–cluster page hierarchy for navigation and structured data.</p>

<h3>Static Page Generator — <code>StaticPageGenerator_Library</code></h3>
<p>Supports pre-generation of static page output where dynamic rendering is not required.</p>

<h2>🔍 Content &amp; SEO Model</h2>
<p>
  The site is organised around a <strong>pillar–cluster content model</strong>. Two pillar
  pages define the top-level categories (<em>Software Development</em>,
  <em>Creative Works</em>); cluster content pages sit beneath them under routed paths
  that encode the pillar–category relationship. A category-aligned internal search engine
  reinforces topical relevance across the site.
</p>
<p>
  Each page carries full SEO metadata — title, description, Open Graph image and alt text —
  sourced from the CMS. JSON‑LD structured data is generated dynamically per page type and
  injected into the document head, covering homepage, pillar, and article schemas.
</p>

<h2>🛡️ Testing</h2>
<p>The solution maintains test projects for each library and a separate UI test suite.</p>
<ul>
  <li><strong>xUnit</strong> — unit and integration tests for <code>Page_Library</code>, <code>JsonLD_Library</code>, and <code>Sitemap_Library</code>, with JSON fixture data covering page, content, and schema scenarios.</li>
  <li><strong>Selenium + ReqnRoll (BDD)</strong> — end-to-end browser tests written as executable Gherkin specifications. Feature files cover the homepage, both pillar pages, cluster content pages, the search page, and the legal page.</li>
</ul>

<h2>📡 Observability</h2>
<p>
  Every controller action is instrumented with <strong>OpenTelemetry</strong> distributed
  tracing via named <code>ActivitySource</code> instances. Spans cover each logical step —
  route validation, page retrieval, search, JSON‑LD generation, session reads, and
  view-model construction — with structured tags on each. Traces are exported to
  <strong>Honeycomb</strong>, configured via application settings.
</p>
