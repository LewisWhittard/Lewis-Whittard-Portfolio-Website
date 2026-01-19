using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace LMWDev.Controllers
{
    [Route("sitemap.xml")]
    public class SitemapController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Build the base URL dynamically (e.g., https://yourdomain.com)
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var xml = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">

  <url>
    <loc>{baseUrl}/</loc>
  </url>

  <url>
    <loc>{baseUrl}/search</loc>
  </url>

  <url>
    <loc>{baseUrl}/software-development</loc>
  </url>

  <url>
    <loc>{baseUrl}/software-development/portfolio-website-completed</loc>
  </url>

  <url>
    <loc>{baseUrl}/software-development/my-portfolio-website-development</loc>
  </url>

  <url>
    <loc>{baseUrl}/software-development/ui-test-automation-portfolio-piece</loc>
  </url>

  <url>
    <loc>{baseUrl}/intersections/cogetta</loc>
  </url>

  <url>
    <loc>{baseUrl}/software-development/from-reflection-to-action-the-marginal-gains-sprint</loc>
  </url>

  <url>
    <loc>{baseUrl}/software-development/search-structure-and-SEO-upgrade</loc>
  </url>

  <url>
    <loc>{baseUrl}/creative-works</loc>
  </url>

  <url>
    <loc>{baseUrl}/creative-works/lewis-matthew-whittard-software-development-logo</loc>
  </url>

</urlset>";

            return Content(xml, "application/xml", Encoding.UTF8);
        }
    }
}