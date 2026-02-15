using JsonLD_Library.Service.Interface;
using Microsoft.AspNetCore.Http;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Page.Entities.Page.Interface;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonLD_Library.Service.Base
{
    public class JsonLDBase : IJsonLDService
    {
        private readonly IHttpContextAccessor _http;

        public JsonLDBase(IHttpContextAccessor http)
        {
            _http = http;
        }

        public string GenerateJsonLDCulsterContentPage(IPage page)
        {
            var baseUrl = $"{_http.HttpContext.Request.Scheme}://{_http.HttpContext.Request.Host}";
            var pillarSlug = GetPillarSlug(page);

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

            // Build JSON-LD using dictionaries so @ keys serialize correctly
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

        private string GetPillarSlug(IPage page)
        {
            if (page.Category == "Software Development")
                return "software-development";

            if (page.Category == "Creative Works")
                return "creative-works";

            if (page.Category.Contains(","))
                return "intersections";

            return "intersections";
        }
    }
}
