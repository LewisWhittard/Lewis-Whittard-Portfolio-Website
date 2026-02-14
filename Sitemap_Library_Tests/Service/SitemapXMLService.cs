using Microsoft.AspNetCore.Http;
using Page_Library.Page.Repository;
using Page_Library.Page.Repository.Interface;
using Sitemap_Library.Service;

namespace LMWDev_Test.Services
{
    public class SitemapXMLServiceTests
    {
        [Fact]
        public void RenderSitemap_ReturnsExpectedXml()
        {
            // Arrange
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
            Assert.True(File.Exists(jsonPath), $"Missing test data file: {jsonPath}");

            IPageRepository pageRepository = new JsonPageRepository(jsonPath);

            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "https";
            httpContext.Request.Host = new HostString("example.com");

            var accessor = new HttpContextAccessor { HttpContext = httpContext };

            var service = new SitemapXMLService(pageRepository, accessor);

            // Act
            var xml = service.RenderSitemap();

            // Assert: basic structure
            Assert.StartsWith("<?xml", xml.TrimStart());
            Assert.EndsWith("</urlset>", xml.TrimEnd());

            // Assert: static URLs
            Assert.Contains("https://example.com/", xml);
            Assert.Contains("https://example.com/software-development", xml);
            Assert.Contains("https://example.com/creative-works", xml);

            // Assert: dynamic URLs from JSON
            Assert.Contains("https://example.com/software-development/portfolio-website-completed", xml);
            Assert.Contains("https://example.com/software-development/my-portfolio-website-development", xml);
            Assert.Contains("https://example.com/software-development/ui-test-automation-portfolio-piece", xml);
            Assert.Contains("https://example.com/intersections/cogetta", xml);
            Assert.Contains("https://example.com/software-development/from-reflection-to-action-the-marginal-gains-sprint", xml);
            Assert.Contains("https://example.com/software-development/search-structure-and-SEO-upgrade", xml);
            Assert.Contains("https://example.com/creative-works/lewis-matthew-whittard-software-development-logo", xml);
        }
    }
}