using System.Text.Json;
using JsonLD_Library.Service.Interface;
using JsonLD_Library.Service;
using Microsoft.AspNetCore.Http;
using Moq;
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
}