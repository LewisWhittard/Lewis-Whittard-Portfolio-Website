using JsonLD_Library.Service.Interface;
using Microsoft.AspNetCore.Http;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Page.Entities.Page.Interface;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Page_Library.Page.Entities.SearchResult.Interface;

namespace JsonLD_Library.Service.Base
{
    public class JsonLDBase : IJsonLDService
    {
        private readonly IHttpContextAccessor _http;

        public JsonLDBase(IHttpContextAccessor http)
        {
            _http = http;
        }

        public string GenerateJsonLDHomePage()
        {
            var baseUrl = $"{_http.HttpContext.Request.Scheme}://{_http.HttpContext.Request.Host}";

            var jsonLd = new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "WebPage",

                ["name"] = "Lewis Whittard – Developer & Support Analyst",
                ["url"] = baseUrl,
                ["description"] = "Portfolio homepage of Lewis Whittard, a Developer & Support Analyst with experience across software testing, development, and support. Showcasing professional history, qualifications and certifications.",

                ["isPartOf"] = new Dictionary<string, object?>
                {
                    ["@type"] = "WebSite",
                    ["url"] = baseUrl,
                    ["name"] = "Lewis Whittard Portfolio"
                },

                ["primaryImageOfPage"] = new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = $"{baseUrl}/Images/LewisWhittard.jpg",
                    ["caption"] = "Picture of Lewis Whittard"
                }
            };

            return JsonSerializer.Serialize(jsonLd, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }

        public string GenerateJsonLDCulsterContentPage(IPage page)
        {
            var baseUrl = $"{_http.HttpContext.Request.Scheme}://{_http.HttpContext.Request.Host}";
            var pillarSlug = GetPillarSlug(page.Category); // UPDATED

            // Collect images
            var images = page.ContentBlocks
                .OfType<ImageBlock>()
                .Select(image => new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = $"{baseUrl}/{image.Content.Path}",
                    ["caption"] = image.Content.Alt
                })
                .ToList();

            // Collect videos
            var videos = page.ContentBlocks
                .OfType<VideoBlock>()
                .Select(video => new Dictionary<string, object?>
                {
                    ["@type"] = "VideoObject",
                    ["name"] = video.Content.Name,
                    ["description"] = video.Content.Description,
                    ["contentUrl"] = $"{baseUrl}/{video.Content.Path}"
                })
                .ToList();

            // Meta image
            List<Dictionary<string, object?>>? metaImage = null;

            if (page.Meta?.Content?.Path != null)
            {
                metaImage = new List<Dictionary<string, object?>>
                {
                    new Dictionary<string, object?>
                    {
                        ["@type"] = "ImageObject",
                        ["url"] = $"{baseUrl}/{page.Meta.Content.Path}"
                    }
                };
            }

            var allImages = (metaImage ?? new List<Dictionary<string, object?>>())
                .Concat(images)
                .ToList();

            // Build JSON-LD
            var jsonLd = new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = page.JsonLDType,
                ["headline"] = page.Title,
                ["description"] = page.Meta?.MetaDescription,
                ["datePublished"] = page.PublishDate?.ToString(),

                ["author"] = new Dictionary<string, object?>
                {
                    ["@type"] = "Person",
                    ["name"] = page.Author
                },

                ["mainEntityOfPage"] = new Dictionary<string, object?>
                {
                    ["@type"] = "WebPage",
                    ["@id"] = $"{baseUrl}/{pillarSlug}/{page.ExternalId}"
                },

                ["image"] = allImages.Any() ? allImages : null,
                ["video"] = videos.Any() ? videos : null
            };

            return JsonSerializer.Serialize(jsonLd, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        }

        public string GenerateJsonLDPillarPage(IPage page, List<ISearchResult> ClustercontentPages)
        {
            var baseUrl = $"{_http.HttpContext.Request.Scheme}://{_http.HttpContext.Request.Host}";
            var pillarSlug = GetPillarSlug(page.Category); // UPDATED

            // Collect images
            var images = page.ContentBlocks
                .OfType<ImageBlock>()
                .Select(image => new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = $"{baseUrl}/{image.Content.Path}",
                    ["caption"] = image.Content.Alt
                })
                .ToList();

            // Collect videos
            var videos = page.ContentBlocks
                .OfType<VideoBlock>()
                .Select(video => new Dictionary<string, object?>
                {
                    ["@type"] = "VideoObject",
                    ["name"] = video.Content.Name,
                    ["description"] = video.Content.Description,
                    ["contentUrl"] = $"{baseUrl}/{video.Content.Path}"
                })
                .ToList();

            // Meta image
            List<Dictionary<string, object?>>? metaImage = null;

            if (page.Meta?.Content?.Path != null)
            {
                metaImage = new List<Dictionary<string, object?>>
                {
                    new Dictionary<string, object?>
                    {
                        ["@type"] = "ImageObject",
                        ["url"] = $"{baseUrl}/{page.Meta.Content.Path}"
                    }
                };
            }

            var allImages = (metaImage ?? new List<Dictionary<string, object?>>())
                .Concat(images)
                .ToList();

            // Build hasPart
            List<Dictionary<string, object?>>? hasPart = null;

            if (ClustercontentPages != null && ClustercontentPages.Count > 0)
            {
                hasPart = new List<Dictionary<string, object?>>();

                foreach (var child in ClustercontentPages)
                {
                    var childSlug = GetPillarSlug(child.Category); // UPDATED

                    hasPart.Add(new Dictionary<string, object?>
                    {
                        ["@type"] = "WebPage",
                        ["name"] = child.Title,
                        ["url"] = $"{baseUrl}/{childSlug}/{child.ExternalId}"
                    });
                }
            }

            // Build JSON-LD
            var jsonLd = new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "WebPage",
                ["name"] = page.Title,
                ["headline"] = page.Title,
                ["description"] = page.Meta?.MetaDescription,
                ["datePublished"] = page.PublishDate?.ToString(),

                ["mainEntityOfPage"] = new Dictionary<string, object?>
                {
                    ["@type"] = "WebPage",
                    ["@id"] = $"{baseUrl}/{pillarSlug}"
                },

                ["image"] = allImages.Any() ? allImages : null,
                ["video"] = videos.Any() ? videos : null,

                ["about"] = new Dictionary<string, object?>
                {
                    ["@type"] = "Thing",
                    ["name"] = page.Category,
                    ["url"] = $"{baseUrl}/{pillarSlug}"
                },

                ["hasPart"] = hasPart
            };

            return JsonSerializer.Serialize(jsonLd, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        }

        // ---------------------------------------------------------
        // ONLY THIS METHOD REMAINS
        // ---------------------------------------------------------
        private string GetPillarSlug(string category)
        {
            if (category == "Software Development")
                return "software-development";

            if (category == "Creative Works")
                return "creative-works";

            if (category.Contains(","))
                return "intersections";

            return "intersections";
        }
    }
}