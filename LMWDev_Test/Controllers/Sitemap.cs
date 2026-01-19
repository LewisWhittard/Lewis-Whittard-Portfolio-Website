using LMWDev.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Page_Library.Page.Entities.Page.DTO;
using Page_Library.Page.Repository;
using Page_Library.Page.Repository.Interface;
using Sitemap_Library.Service;

namespace LMWDev_Test.Controllers
{
    public class SitemapControllerTests
    {
        [Fact]
        public void Index_ReturnsExpectedXmlContent()
        {
            // Arrange
            IPageRepository pageRepository = new JsonPageRepository(Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json"));
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Scheme = "https";
            httpContext.Request.Host = new HostString("example.com");

            var accessor = new HttpContextAccessor { HttpContext = httpContext };

            var service = new SitemapXMLService(pageRepository, accessor);
            var controller = new SitemapController(service);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = httpContext
            };

            // Act
            var result = controller.Index() as ContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("application/xml; charset=utf-8", result.ContentType);

            var xml = result.Content;

            Assert.Contains("https://example.com/", xml);
            Assert.Contains("https://example.com/software-development", xml);
            Assert.Contains("https://example.com/software-development/portfolio-website-completed", xml);
            Assert.Contains("https://example.com/software-development/my-portfolio-website-development", xml);
            Assert.Contains("https://example.com/software-development/ui-test-automation-portfolio-piece", xml);
            Assert.Contains("https://example.com/intersections/cogetta", xml);
            Assert.Contains("https://example.com/software-development/from-reflection-to-action-the-marginal-gains-sprint", xml);
            Assert.Contains("https://example.com/software-development/search-structure-and-SEO-upgrade", xml);
            Assert.Contains("https://example.com/creative-works", xml);
            Assert.Contains("https://example.com/creative-works/lewis-matthew-whittard-software-development-logo", xml);

            Assert.StartsWith("<?xml", xml.TrimStart());
            Assert.EndsWith("</urlset>", xml.TrimEnd());
        }
    }
}