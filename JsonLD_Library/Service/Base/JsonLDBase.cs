using JsonLD_Library.Service.Interface;
using Microsoft.AspNetCore.Http;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Page.Entities.Page.Interface;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using Page_Library.Page.Entities.SearchResult.Interface;
using System.Text.RegularExpressions;

namespace JsonLD_Library.Service.Base
{
    public class JsonLDBase : IJsonLDService
    {
        private readonly IHttpContextAccessor _http;

        public JsonLDBase(IHttpContextAccessor http)
        {
            _http = http;
        }
        private static readonly Regex EmojiRegex = new Regex(
            @"\p{Cs}",
            RegexOptions.Compiled
        );

        private string RemoveEmojis(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input ?? string.Empty;

            return EmojiRegex.Replace(input, string.Empty);
        }

        public string GenerateJsonLDHomePage()
        {
            var baseUrl = $"{_http.HttpContext.Request.Scheme}://{_http.HttpContext.Request.Host}";

            var jsonLd = new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "WebPage",

                ["name"] = RemoveEmojis("Lewis Whittard – Developer & Support Analyst"),
                ["url"] = baseUrl,
                ["description"] = RemoveEmojis(
                    "Portfolio homepage of Lewis Whittard, a Developer & Support Analyst with experience across software testing, development, and support. Showcasing professional history, qualifications and certifications."
                ),

                ["isPartOf"] = new Dictionary<string, object?>
                {
                    ["@type"] = "WebSite",
                    ["url"] = baseUrl,
                    ["name"] = RemoveEmojis("Lewis Whittard Portfolio")
                },

                ["primaryImageOfPage"] = new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = $"{baseUrl}/Images/LewisWhittard.jpg",
                    ["caption"] = RemoveEmojis("Picture of Lewis Whittard")
                }
            };

            return JsonSerializer.Serialize(jsonLd, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            });
        }

        public string GenerateJsonLDPillarPage(IPage page, List<ISearchResult> clusterContentPages)
        {
            var baseUrl = $"{_http.HttpContext.Request.Scheme}://{_http.HttpContext.Request.Host}";
            var pillarSlug = GetPillarSlug(page.Category);

            // -----------------------------
            // IMAGES
            // -----------------------------
            var images = page.ContentBlocks
                .OfType<ImageBlock>()
                .Select(image => new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = $"{baseUrl}/{image.Content.Path}",
                    ["caption"] = RemoveEmojis(image.Content.Alt)?.Trim()
                })
                .ToList();

            if (page.Meta?.Content?.Path is string metaPath)
            {
                images.Insert(0, new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = $"{baseUrl}/{metaPath}"
                });
            }

            // -----------------------------
            // VIDEOS
            // -----------------------------
            var videos = page.ContentBlocks
                .OfType<VideoBlock>()
                .Select(video => new Dictionary<string, object?>
                {
                    ["@type"] = "VideoObject",
                    ["name"] = RemoveEmojis(video.Content.Name)?.Trim(),
                    ["description"] = RemoveEmojis(video.Content.Description)?.Trim(),
                    ["contentUrl"] = $"{baseUrl}/{video.Content.Path}"
                })
                .ToList();

            // -----------------------------
            // hasPart (cluster pages)
            // -----------------------------
            List<Dictionary<string, object?>>? hasPart = null;

            if (clusterContentPages != null && clusterContentPages.Count > 0)
            {
                hasPart = clusterContentPages.Select(child =>
                {
                    var childSlug = GetPillarSlug(child.Category);

                    return new Dictionary<string, object?>
                    {
                        ["@type"] = "WebPage",
                        ["name"] = RemoveEmojis(child.Title)?.Trim(),
                        ["url"] = $"{baseUrl}/{childSlug}/{child.ExternalId}"
                    };

                }).ToList();
            }

            // -----------------------------
            // BREADCRUMB
            // -----------------------------
            var breadcrumbItems = new List<Dictionary<string, object?>>();
            int position = 1;

            breadcrumbItems.Add(new Dictionary<string, object?>
            {
                ["@type"] = "ListItem",
                ["position"] = position++,
                ["name"] = "Home",
                ["item"] = $"{baseUrl}/"
            });

            breadcrumbItems.Add(new Dictionary<string, object?>
            {
                ["@type"] = "ListItem",
                ["position"] = position++,
                ["name"] = RemoveEmojis(page.Title)?.Trim(),
                ["item"] = $"{baseUrl}/{pillarSlug}"
            });

            var breadcrumb = new Dictionary<string, object?>
            {
                ["@type"] = "BreadcrumbList",
                ["itemListElement"] = breadcrumbItems
            };

            // -----------------------------
            // ROOT JSON-LD
            // -----------------------------
            var jsonLd = new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = "CollectionPage",

                ["name"] = RemoveEmojis(page.Title)?.Trim(),
                ["headline"] = RemoveEmojis(page.Title)?.Trim(),
                ["description"] = RemoveEmojis(page.Meta?.MetaDescription)?.Trim(),
                ["url"] = $"{baseUrl}/{pillarSlug}",

                ["breadcrumb"] = breadcrumb
            };

            if (hasPart != null)
            {
                jsonLd["hasPart"] = hasPart;
            }

            if (images.Any())
            {
                jsonLd["image"] = images;
            }

            if (videos.Any())
            {
                jsonLd["video"] = videos;
            }

            return JsonSerializer.Serialize(jsonLd, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        }



        private string GetPillarSlug(string category)
        {
            category = RemoveEmojis(category);

            if (category == "Software Development")
                return "software-development";

            if (category == "Creative Works")
                return "creative-works";

            if (category.Contains(","))
                return "intersections";

            return "intersections";
        }


        public string GenerateJsonLDCulsterContentPage(IPage page)
        {
            var baseUrl = $"{_http.HttpContext.Request.Scheme}://{_http.HttpContext.Request.Host}";

            // Collect images
            var images = page.ContentBlocks
                .OfType<ImageBlock>()
                .Select(image => new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = $"{baseUrl}/{image.Content.Path}",
                    ["caption"] = RemoveEmojis(image.Content.Alt)
                })
                .ToList();

            // Collect videos
            var videos = page.ContentBlocks
                .OfType<VideoBlock>()
                .Select(video => new Dictionary<string, object?>
                {
                    ["@type"] = "VideoObject",
                    ["name"] = RemoveEmojis(video.Content.Name),
                    ["description"] = RemoveEmojis(video.Content.Description),
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

            // ---------------------------------------------------------
            // 🔹 Build Breadcrumbs
            // ---------------------------------------------------------
            var breadcrumbItems = new List<Dictionary<string, object?>>();

            // 1. Home
            breadcrumbItems.Add(new Dictionary<string, object?>
            {
                ["@type"] = "ListItem",
                ["position"] = 1,
                ["item"] = new Dictionary<string, object?>
                {
                    ["@id"] = baseUrl,
                    ["name"] = "Home"
                }
            });

            // 2. Pillars
            var pillars = GetPillarsForCategory(page.Category);
            bool multiplePillars = page.Category.Contains(",");

            foreach (var pillar in pillars)
            {
                breadcrumbItems.Add(new Dictionary<string, object?>
                {
                    ["@type"] = "ListItem",
                    ["position"] = 2,
                    ["item"] = new Dictionary<string, object?>
                    {
                        ["@id"] = $"{baseUrl}/{pillar.pillar}",
                        ["name"] = RemoveEmojis(pillar.name)
                    }
                });
            }

            string pageUrl;

            // Build page URL
            if (page.Category.Contains(","))
            {
                pageUrl = $"{baseUrl}/intersections/{page.ExternalId}";
            }
            else
            {
                pageUrl = $"{baseUrl}/{string.Join("/", pillars.Select(p => p.pillar))}/{page.ExternalId}";
            }

            // 3. Current page
            breadcrumbItems.Add(new Dictionary<string, object?>
            {
                ["@type"] = "ListItem",
                ["position"] = 3,
                ["item"] = new Dictionary<string, object?>
                {
                    ["@id"] = pageUrl,
                    ["name"] = RemoveEmojis(page.Title)
                }
            });

            var breadcrumb = new Dictionary<string, object?>
            {
                ["@type"] = "BreadcrumbList",
                ["itemListElement"] = breadcrumbItems
            };

            // ---------------------------------------------------------
            // 🔹 Build JSON-LD
            // ---------------------------------------------------------
            var jsonLd = new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@type"] = page.JsonLDType,
                ["headline"] = RemoveEmojis(page.Title),
                ["description"] = RemoveEmojis(page.Meta?.MetaDescription),
                ["datePublished"] = page.PublishDate?.ToString(),

                ["author"] = new Dictionary<string, object?>
                {
                    ["@type"] = "Person",
                    ["name"] = RemoveEmojis(page.Author)
                },

                ["mainEntityOfPage"] = new Dictionary<string, object?>
                {
                    ["@type"] = "WebPage",
                    ["@id"] = pageUrl
                },

                ["breadcrumb"] = breadcrumb
            };

            // ---------------------------------------------------------
            // 🔹 Conditional image/video assignment
            // ---------------------------------------------------------
            if (allImages.Any())
            {
                jsonLd["image"] = allImages;
            }

            if (videos.Any())
            {
                jsonLd["video"] = videos;
            }

            return JsonSerializer.Serialize(jsonLd, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        }

        private List<(string pillar, string name)> GetPillarsForCategory(string category)
        {
            var list = new List<(string slug, string name)>();
            var normalized = category?.Trim().ToLowerInvariant() ?? string.Empty;

            if (normalized.Contains("software"))
            {
                list.Add(("software-development", "Software Development"));
            }

            if (normalized.Contains("creative"))
            {
                list.Add(("creative-works", "Creative Works"));
            }

            return list;
        }
    }
}