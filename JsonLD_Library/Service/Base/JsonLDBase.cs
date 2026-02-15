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
                .Select(image => new
                {
                    @type = "ImageObject",
                    url = $"{baseUrl}{image.Content.Path}",
                    caption = image.Content.Alt
                })
                .ToList();

            // Collect videos
            var videos = page.ContentBlocks
                .OfType<VideoBlock>()
                .Select(video => new
                {
                    @type = "VideoObject",
                    name = video.Content.Name,
                    description = video.Content.Description,
                    url = $"{baseUrl}{video.Content.Path}"
                })
                .ToList();

            // Meta image
            var metaImage = page.Meta?.Content?.Path != null
                ? new[]
                {
            new
            {
                @type = "ImageObject",
                url = $"{baseUrl}{page.Meta.Content.Path}"
            }
                }
                : null;

            var allImages = (metaImage ?? Enumerable.Empty<object>())
                .Concat(images)
                .ToList();

            var jsonLd = new
            {
                @context = "https://schema.org",
                @type = page.JsonLDType,
                headline = page.Title,
                description = page.Meta?.MetaDescription,
                datePublished = page.PublishDate?.ToString(),
                author = new
                {
                    @type = "Person",
                    name = page.Author
                },

                mainEntityOfPage = new
                {
                    @type = "WebPage",
                    @id = $"{baseUrl}/{pillarSlug}/{page.ExternalId}"
                },

                image = allImages.Any() ? allImages : null,
                video = videos.Any() ? videos : null
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

