using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Page_Library.Content.Repository;
using Page_Library.Page.Factory;
using Page_Library.Page.Repository;
using Page_Library.Page.Service;

namespace JsonLD_Library_Tests.Service;
public class JsonLDService
{
    [Fact]
    public void Homepage_JsonLD_Correctly()
    {
        // Arrange
        var httpContext = new DefaultHttpContext();
        httpContext.Request.Scheme = "https";
        httpContext.Request.Host = new HostString("example.com");

        var accessor = new HttpContextAccessor { HttpContext = httpContext };

        var service = new JsonLD_Library.Service.JsonLDService(accessor); // replace with your class

        // Act
        var actualJson = service.GenerateJsonLDHomePage();

        // Expected JSON-LD (literal)
        var expectedJson = @"{
  ""@context"": ""https://schema.org"",
  ""@type"": ""WebPage"",
  ""name"": ""Lewis Whittard – Developer & Support Analyst"",
  ""url"": ""https://example.com"",
  ""description"": ""Portfolio homepage of Lewis Whittard, a Developer & Support Analyst with experience across software testing, development, and support. Showcasing professional history, qualifications and certifications."",
  ""isPartOf"": {
    ""@type"": ""WebSite"",
    ""url"": ""https://example.com"",
    ""name"": ""Lewis Whittard Portfolio""
  },
  ""primaryImageOfPage"": {
    ""@type"": ""ImageObject"",
    ""url"": ""https://example.com/Images/LewisWhittard.jpg"",
    ""caption"": ""Picture of Lewis Whittard""
  }
}";

        // Normalise formatting for comparison
        var expected = JToken.Parse(expectedJson).ToString();
        var actual = JToken.Parse(actualJson).ToString();

        // Assert
        Assert.Equal(expected, actual);
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
      ""headline"": ""Release 1.3.1 — 3D Background, WCAG Controls & SEO Improvements"",
      ""description"": ""Explore Release 1.3.1, featuring a new 3D prerendered background video, WCAG‑compliant motion controls, automatic sitemap generation, improved routing, and a hybrid video format with higher production values."",
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
          ""name"": ""Release 1.3.1 — 3D Background, WCAG Controls, and SEO Improvements"",
          ""description"": ""Release 1.3.1 video covering the new 3D prerendered background, WCAG accessibility toggle, hybrid video format, routing improvements, and automatic sitemap generation."",
          ""contentUrl"": ""https://example.com/PortfolioSiteRelease1.3.1.mp4"",
          ""thumbnailUrl"": ""https://example.com/Thumbnails/PortfolioSiteRelease1.3.1Thumbnail.png"",
          ""uploadDate"": ""2026-01-26T00:00:00Z""
        },
        {
          ""@type"": ""VideoObject"",
          ""name"": ""Release 1.2.0 — Search, Structure, and SEO Upgrade"",
          ""description"": ""Release 1.2.0 video covering the search overhaul, SEO improvements, and UI updates."",
          ""contentUrl"": ""https://example.com/PortfolioRelease1.2.0.mp4"",
          ""thumbnailUrl"": ""https://example.com/Thumbnails/PortfolioRelease1.2.0Thumbnail.png"",
          ""uploadDate"": ""2026-01-26T00:00:00Z""
        }
      ],
      ""isPartOf"": [
        {
          ""@id"": ""https://example.com/software-development""
        },
        {
          ""@id"": ""https://example.com/creative-works""
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
            ""name"": ""Release 1.3.1 — 3D Background, WCAG Controls & SEO Improvements""
          }
        }
      ]
    },
    {
      ""@type"": ""WebPage"",
      ""@id"": ""https://example.com/software-development"",
      ""name"": ""Software Development""
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
            ""name"": ""Release 1.3.1 — 3D Background, WCAG Controls & SEO Improvements""
          }
        }
      ]
    },
    {
      ""@type"": ""WebPage"",
      ""@id"": ""https://example.com/creative-works"",
      ""name"": ""Creative Works""
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
    public void ClusterContent_NoVideosAndImages_Correctly()
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
        var expectedJson = @"{
  ""@context"": ""https://schema.org"",
  ""@graph"": [
    {
      ""@type"": ""BlogPosting"",
      ""@id"": ""https://example.com/Cluster content test no Images and Videos"",
      ""url"": ""https://example.com/Cluster content test no Images and Videos"",
      ""headline"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements"",
      ""description"": ""Explore Release 1.3.1, featuring a new 3D prerendered background video, WCAG\u2011compliant motion controls, automatic sitemap generation, improved routing, and a hybrid video format with higher production values."",
      ""datePublished"": ""2026-01-26T00:00:00Z"",
      ""mainEntityOfPage"": {
        ""@type"": ""WebPage"",
        ""@id"": ""https://example.com/Cluster content test no Images and Videos""
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
      ""isPartOf"": [
        {
          ""@id"": ""https://example.com/software-development""
        },
        {
          ""@id"": ""https://example.com/creative-works""
        }
      ]
    },
    {
      ""@type"": ""BreadcrumbList"",
      ""@id"": ""https://example.com/intersections/Cluster content test no Images and Videos#breadcrumb-software-development"",
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
            ""@id"": ""https://example.com/intersections/Cluster content test no Images and Videos"",
            ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements""
          }
        }
      ]
    },
    {
      ""@type"": ""WebPage"",
      ""@id"": ""https://example.com/software-development"",
      ""name"": ""Software Development""
    },
    {
      ""@type"": ""BreadcrumbList"",
      ""@id"": ""https://example.com/intersections/Cluster content test no Images and Videos#breadcrumb-creative-works"",
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
            ""@id"": ""https://example.com/intersections/Cluster content test no Images and Videos"",
            ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements""
          }
        }
      ]
    },
    {
      ""@type"": ""WebPage"",
      ""@id"": ""https://example.com/creative-works"",
      ""name"": ""Creative Works""
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
    public void PillarPage_NoVideosAndImages_Correctly()
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
        var page = pageService.GetPage("creative-works");
        var search = pageService.Search(null, page.Category);
        var actualJson = jsonLdService.GenerateJsonLDPillarPage(page,search);

        // Expected JSON-LD (literal)
        var expectedJson = @"{
  ""@context"": ""https://schema.org"",
  ""@type"": ""CollectionPage"",
  ""name"": ""Creative Works"",
  ""headline"": ""Creative Works"",
  ""description"": ""A pillar page showcasing my creative projects including digital assets and game development."",
  ""url"": ""https://example.com/creative-works"",
  ""breadcrumb"": {
    ""@type"": ""BreadcrumbList"",
    ""itemListElement"": [
      {
        ""@type"": ""ListItem"",
        ""position"": 1,
        ""name"": ""Creative Works"",
        ""item"": ""https://example.com/creative-works""
      }
    ]
  },
  ""hasPart"": [
    {
      ""@type"": ""WebPage"",
      ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements"",
      ""url"": ""https://example.com/intersections/Cluster content test no Images and Videos""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements"",
      ""url"": ""https://example.com/intersections/Cluster content test Images and Videos""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""Cogetta"",
      ""url"": ""https://example.com/intersections/cogetta""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""Lewis Matthew Whittard Software Development Logo"",
      ""url"": ""https://example.com/creative-works/lewis-matthew-whittard-software-development-logo""
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
    public void PillarPage_VideosAndImages_Correctly()
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
        var page = pageService.GetPage("software-development");
        var search = pageService.Search(null, page.Category);
        var actualJson = jsonLdService.GenerateJsonLDPillarPage(page, search);

        // Expected JSON-LD (literal)
       var expectedJson = @"{
  ""@context"": ""https://schema.org"",
  ""@type"": ""CollectionPage"",
  ""name"": ""Software Development"",
  ""headline"": ""Software Development"",
  ""description"": ""A pillar page covering my software development work including testing, development practices, and support processes."",
  ""url"": ""https://example.com/software-development"",
  ""breadcrumb"": {
    ""@type"": ""BreadcrumbList"",
    ""itemListElement"": [
      {
        ""@type"": ""ListItem"",
        ""position"": 1,
        ""name"": ""Software Development"",
        ""item"": ""https://example.com/software-development""
      }
    ]
  },
  ""hasPart"": [
    {
      ""@type"": ""WebPage"",
      ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements"",
      ""url"": ""https://example.com/intersections/Cluster content test no Images and Videos""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""Release 1.3.1 \u2014 3D Background, WCAG Controls \u0026 SEO Improvements"",
      ""url"": ""https://example.com/intersections/Cluster content test Images and Videos""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""Release 1.2.0 \u2014 Search, Structure, and SEO Upgrade"",
      ""url"": ""https://example.com/software-development/search-structure-and-seo-upgrade""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""From Reflection to Action: The Marginal Gains Sprint"",
      ""url"": ""https://example.com/software-development/from-reflection-to-action-the-marginal-gains-sprint""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""Cogetta"",
      ""url"": ""https://example.com/intersections/cogetta""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""UI Test Automation Portfolio Piece"",
      ""url"": ""https://example.com/software-development/ui-test-automation-portfolio-piece""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""My Portfolio Website Development"",
      ""url"": ""https://example.com/software-development/my-portfolio-website-development""
    },
    {
      ""@type"": ""WebPage"",
      ""name"": ""Portfolio Website Completed!"",
      ""url"": ""https://example.com/software-development/portfolio-website-completed""
    }
  ],
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
      ""uploadDate"": ""2025/12/21T00:00:00Z""
    },
    {
      ""@type"": ""VideoObject"",
      ""name"": ""Release 1.2.0 \u2014 Search, Structure, and SEO Upgrade"",
      ""description"": ""Release 1.2.0 video covering the search overhaul, SEO improvements, and UI updates."",
      ""contentUrl"": ""https://example.com/PortfolioRelease1.2.0.mp4"",
      ""thumbnailUrl"": ""https://example.com/Thumbnails/PortfolioRelease1.2.0Thumbnail.png"",
      ""uploadDate"": ""2025/12/21T00:00:00Z""
    }
  ]
}";

        // Normalise formatting for comparison
        var expected = JToken.Parse(expectedJson).ToString();
        var actual = JToken.Parse(actualJson).ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

}