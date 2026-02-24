using JsonLD_Library.Service;
using JsonLD_Library.Service.Interface;
using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json.Linq;
using Page_Library.Content.Repository;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Factory;
using Page_Library.Page.Repository;
using Page_Library.Page.Repository.Interface;
using Page_Library.Page.Service;
using System.Text.Json;
using Xunit;

namespace JsonLD_Library_Tests.Service;
public class JsonLDService
{
    [Fact]
    public void GenerateJsonLDHomePage_ProducesExpectedJsonStructure()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Scheme = "https";
        httpContext.Request.Host = new HostString("example.com");

        var accessor = new HttpContextAccessor { HttpContext = httpContext };

        var service = new JsonLD_Library.Service.JsonLDService(accessor); // replace with your class

        // Act
        var json = service.GenerateJsonLDHomePage();
        using var doc = JsonDocument.Parse(json);
        var root = doc.RootElement;

        // Assert: top-level object
        Assert.Equal(JsonValueKind.Object, root.ValueKind);

        // Assert: required top-level fields
        Assert.Equal("https://schema.org", root.GetProperty("@context").GetString());
        Assert.Equal("WebPage", root.GetProperty("@type").GetString());
        Assert.Equal("Lewis Whittard – Developer & Support Analyst", root.GetProperty("name").GetString());
        Assert.Equal("https://example.com", root.GetProperty("url").GetString());

        var description = root.GetProperty("description").GetString();
        Assert.Equal(
            "Portfolio homepage of Lewis Whittard, a Developer & Support Analyst with experience across software testing, development, and support. Showcasing professional history, qualifications and certifications.",
            description
        );

        // Assert: isPartOf object
        var isPartOf = root.GetProperty("isPartOf");
        Assert.Equal(JsonValueKind.Object, isPartOf.ValueKind);
        Assert.Equal("WebSite", isPartOf.GetProperty("@type").GetString());
        Assert.Equal("https://example.com", isPartOf.GetProperty("url").GetString());
        Assert.Equal("Lewis Whittard Portfolio", isPartOf.GetProperty("name").GetString());

        // Assert: primaryImageOfPage object
        var img = root.GetProperty("primaryImageOfPage");
        Assert.Equal(JsonValueKind.Object, img.ValueKind);
        Assert.Equal("ImageObject", img.GetProperty("@type").GetString());
        Assert.Equal("https://example.com/Images/LewisWhittard.jpg", img.GetProperty("url").GetString());
        Assert.Equal("Picture of Lewis Whittard", img.GetProperty("caption").GetString());

        // Assert: no unexpected top-level properties
        var expectedTopLevel = new[]
        {
        "@context", "@type", "name", "url", "description", "isPartOf", "primaryImageOfPage"
    };

        var actualTopLevel = root.EnumerateObject().Select(p => p.Name).ToArray();
        Assert.Equal(expectedTopLevel.OrderBy(x => x), actualTopLevel.OrderBy(x => x));
    }

    [Fact]
    public void ClusterContent_VideosAndImages_Correctly()
    {
        // Arrange
        var pagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
        var pageRepository = new JsonPageRepository(pagePath);

        var factory = new ContentBlockFactory();

        var contentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
        var contentRepository = new JsonContentRepository(contentPath);

        var pageService = new PageService(pageRepository, factory, contentRepository);

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Scheme = "https";
        httpContext.Request.Host = new HostString("example.com");

        var accessor = new HttpContextAccessor { HttpContext = httpContext };
        var jsonLdService = new JsonLD_Library.Service.JsonLDService(accessor);

        // Act
        var page = pageService.GetPage("Cluster content test Images and Videos");
        var actualJson = jsonLdService.GenerateJsonLDCulsterContentPage(page);

        // Expected JSON-LD (literal)
        var expectedJson = @"{
  ""@context"": ""https://schema.org"",
  ""@graph"": [
    {
      ""@type"": ""BlogPosting"",
      ""@id"": ""https://example.com/Cluster content test Images and Videos"",
      ""url"": ""https://example.com/Cluster content test Images and Videos"",
      ""headline"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements"",
      ""description"": ""Explore Release 1.3.1, featuring a new 3D prerendered background video, WCAG\u2011compliant motion controls, automatic sitemap generation, improved routing, and a hybrid video format with higher production values."",
      ""datePublished"": ""2026-01-26T00:00:00Z"",
      ""mainEntityOfPage"": {
        ""@type"": ""WebPage"",
        ""@id"": ""https://example.com/Cluster content test Images and Videos""
      },
      ""publisher"": {
        ""@type"": ""Organization"",
        ""name"": ""Lewis Whittard"",
        ""logo"": {
          ""@type"": ""ImageObject"",
          ""url"": ""https://example.com/LMWlogo.png""
        }
      },
      ""author"": {
        ""@type"": ""Person"",
        ""name"": ""Lewis Whittard""
      },
      ""image"": [
        {
          ""@type"": ""ImageObject"",
          ""url"": ""https://example.com/LMWlogo.png"",
          ""caption"": ""Lewis Matthew Whittard Software Development""
        },
        {
          ""@type"": ""ImageObject"",
          ""url"": ""https://example.com/CogettaPlain.png"",
          ""caption"": ""Cogetta Logo""
        }
      ],
      ""video"": [
        {
          ""@type"": ""VideoObject"",
          ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls, and SEO Improvements"",
          ""description"": ""Release 1.3.1 video covering the new 3D prerendered background, WCAG accessibility toggle, hybrid video format, routing improvements, and automatic sitemap generation."",
          ""contentUrl"": ""https://example.com/PortfolioSiteRelease1.3.1.mp4"",
          ""thumbnailUrl"": ""https://example.com/Thumbnails/PortfolioSiteRelease1.3.1Thumbnail.png"",
          ""uploadDate"": ""2026-01-26T00:00:00Z""
        },
        {
          ""@type"": ""VideoObject"",
          ""name"": ""Release 1.2.0 \u2014 Search, Structure, and SEO Upgrade"",
          ""description"": ""Release 1.2.0 video covering the search overhaul, SEO improvements, and UI updates."",
          ""contentUrl"": ""https://example.com/PortfolioRelease1.2.0.mp4"",
          ""thumbnailUrl"": ""https://example.com/Thumbnails/PortfolioRelease1.2.0Thumbnail.png"",
          ""uploadDate"": ""2026-01-26T00:00:00Z""
        }
      ]
    },
    {
      ""@type"": ""BreadcrumbList"",
      ""@id"": ""https://example.com/intersections/Cluster content test Images and Videos#breadcrumb-software-development"",
      ""itemListElement"": [
        {
          ""@type"": ""ListItem"",
          ""position"": 1,
          ""item"": {
            ""@type"": ""WebPage"",
            ""@id"": ""https://example.com/software-development"",
            ""name"": ""Software Development""
          }
        },
        {
          ""@type"": ""ListItem"",
          ""position"": 2,
          ""item"": {
            ""@type"": ""WebPage"",
            ""@id"": ""https://example.com/intersections/Cluster content test Images and Videos"",
            ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements""
          }
        }
      ]
    },
    {
      ""@type"": ""BreadcrumbList"",
      ""@id"": ""https://example.com/intersections/Cluster content test Images and Videos#breadcrumb-creative-works"",
      ""itemListElement"": [
        {
          ""@type"": ""ListItem"",
          ""position"": 1,
          ""item"": {
            ""@type"": ""WebPage"",
            ""@id"": ""https://example.com/creative-works"",
            ""name"": ""Creative Works""
          }
        },
        {
          ""@type"": ""ListItem"",
          ""position"": 2,
          ""item"": {
            ""@type"": ""WebPage"",
            ""@id"": ""https://example.com/intersections/Cluster content test Images and Videos"",
            ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements""
          }
        }
      ]
    }
  ]
}";

        // Normalise formatting for comparison
        var expected = JToken.Parse(expectedJson).ToString();
        var actual = JToken.Parse(actualJson).ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PageService_GetPageById_Correctly()
    {
        // Arrange
        var pagePath = Path.Combine(AppContext.BaseDirectory, "TestData", "Page", "Page.json");
        var pageRepository = new JsonPageRepository(pagePath);

        var factory = new ContentBlockFactory();

        var contentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
        var contentRepository = new JsonContentRepository(contentPath);

        var pageService = new PageService(pageRepository, factory, contentRepository);

        var httpContext = new DefaultHttpContext();
        httpContext.Request.Scheme = "https";
        httpContext.Request.Host = new HostString("example.com");

        var accessor = new HttpContextAccessor { HttpContext = httpContext };
        var jsonLdService = new JsonLD_Library.Service.JsonLDService(accessor);

        // Act
        var page = pageService.GetPage("Cluster content test no Images and Videos");
        var actualJson = jsonLdService.GenerateJsonLDCulsterContentPage(page);

        // Expected JSON-LD (literal)
        var expectedJson = @"";

        // Normalise formatting for comparison
        var expected = JToken.Parse(expectedJson).ToString();
        var actual = JToken.Parse(actualJson).ToString();

        // Assert
        Assert.Equal(expected, actual);
    }
}