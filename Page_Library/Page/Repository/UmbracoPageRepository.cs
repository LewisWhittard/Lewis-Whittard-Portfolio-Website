using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.MetaData.DTO;
using Page_Library.Page.Entities.Page;
using Page_Library.Page.Entities.Page.DTO;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Base;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Nodes;

public class UmbracoPageRepository : PageRepositoryBase
{
    private readonly HttpClient _http;

    public UmbracoPageRepository(HttpClient http)
    {
        _http = http;
    }

    public override IPage GetPage(string idOrSlug)
    {
        try
        {
            var url = $"/umbraco/delivery/api/v2/content/item/{idOrSlug}";
            JsonNode json = _http.GetFromJsonAsync<JsonNode>(url).Result;
            if (json == null)
                return null;

            var props = json["properties"];

            // --- META BLOCK ---
            var metaProps = props?["meta"]?["items"]?[0]?["content"]?["properties"];

            // --- CONTENT BLOCKS ---
            var blocks = props?["contentBlocks"]?["items"]?
                .AsArray()
                .Select(item =>
                {
                    var p = item?["content"]?["properties"];
                    if (p == null) return null;

                    var dto = new ContentBlockDTO
                    {
                        BlockType = (string?)p["blockType"],
                        Alignment = (string?)p["alignment"],
                        Level = (string?)p["hLevel"],
                        Text = (string?)p["text"],
                        BodyText = (string?)p["bodyText"],
                        Url = (string?)p["url"],
                        LinkText = (string?)p["linkText"],
                        Alt = (string?)p["alt"],
                        Description = (string?)p["description"]
                    };

                    // Image
                    var selectedImage = p["selectedImage"] as JsonArray;
                    var imageNode = selectedImage?.FirstOrDefault();
                    if (imageNode != null)
                    {
                        dto.ImageUrl = (string?)imageNode["url"];
                    }

                    // Video
                    var selectedVideo = p["selectedVideo"] as JsonArray;
                    var videoNode = selectedVideo?.FirstOrDefault();
                    if (videoNode != null)
                    {
                        dto.VideoUrl = (string?)videoNode["url"];
                    }

                    // Thumbnail
                    var selectedThumbnail = p["selectedThumbnail"] as JsonArray;
                    var thumbNode = selectedThumbnail?.FirstOrDefault();
                    if (thumbNode != null)
                    {
                        dto.ThumbnailUrl = (string?)thumbNode["url"];
                    }

                    return dto;
                })
                .Where(x => x != null)
                .ToList() ?? new List<ContentBlockDTO>();

            // --- CATEGORY HANDLING (string OR array) ---
            string category = props?["category"] switch
            {
                JsonArray arr => string.Join(", ", arr.Select(x => x?.ToString())),
                JsonValue val => val.ToString(),
                _ => null
            };

            // --- PAGE DTO ---
            var dto = new PageDTO
            {
                ExternalId = (string?)props?["externalId"],
                PageType = (string?)props?["pageType"],
                Title = (string?)props?["title"],
                PublishDate = (string?)props?["publishDate"],
                Category = category,
                Author = (string?)props?["author"],
                Meta = new MetaDTO
                {
                    MetaTitle = (string?)metaProps?["metaTitle"],
                    MetaDescription = (string?)metaProps?["metaDescription"],
                    MetaKeywords = metaProps?["metaKeywords"] is JsonArray keywordsArray
                        ? keywordsArray.Select(k => (string?)k).Where(s => s != null).ToList()!
                        : new List<string>(),
                    MetaImageId = (int?)metaProps?["metaImageId"]
                },
                ContentBlocks = blocks
            };

            return new Page(dto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }

    public override List<IPage> GetPages(string? searchTerm, string category)
    {
        try
        {
            // 1) Fetch list from API
            var url = "/umbraco/delivery/api/v2/content";
            JsonNode json = _http.GetFromJsonAsync<JsonNode>(url).Result;
            if (json == null)
                return new List<IPage>();

            // 2) Normalize items: support {"items":[...]} and root array [...]
            IEnumerable<JsonNode>? itemsNode = null;
            if (json is JsonArray rootArray)
            {
                itemsNode = rootArray;
            }
            else if (json["items"] is JsonArray itemsArray)
            {
                itemsNode = itemsArray;
            }
            else if (json["items"] is JsonNode singleItem)
            {
                itemsNode = new[] { singleItem };
            }
            else
            {
                itemsNode = Enumerable.Empty<JsonNode>();
            }

            var pages = new List<IPage>();

            foreach (var item in itemsNode)
            {
                var props = item?["properties"];
                if (props == null) continue;

                // Meta
                var metaProps = props?["meta"]?["items"]?[0]?["content"]?["properties"];

                // Content blocks
                var blocks = props?["contentBlocks"]?["items"]?
                    .AsArray()
                    .Select(it =>
                    {
                        var p = it?["content"]?["properties"];
                        if (p == null) return null;

                        var dto = new ContentBlockDTO
                        {
                            BlockType = (string?)p["blockType"],
                            Alignment = (string?)p["alignment"],
                            Level = (string?)p["hLevel"],
                            Text = (string?)p["text"],
                            BodyText = (string?)p["bodyText"],
                            Url = (string?)p["url"],
                            LinkText = (string?)p["linkText"],
                            Alt = (string?)p["alt"],
                            Description = (string?)p["description"]
                        };

                        var selectedImage = p["selectedImage"] as JsonArray;
                        var imageNode = selectedImage?.FirstOrDefault();
                        if (imageNode != null)
                        {
                            dto.ImageUrl = (string?)imageNode["url"];
                        }

                        var selectedVideo = p["selectedVideo"] as JsonArray;
                        var videoNode = selectedVideo?.FirstOrDefault();
                        if (videoNode != null)
                        {
                            dto.VideoUrl = (string?)videoNode["url"];
                        }

                        var selectedThumbnail = p["selectedThumbnail"] as JsonArray;
                        var thumbNode = selectedThumbnail?.FirstOrDefault();
                        if (thumbNode != null)
                        {
                            dto.ThumbnailUrl = (string?)thumbNode["url"];
                        }

                        return dto;
                    })
                    .Where(x => x != null)
                    .ToList() ?? new List<ContentBlockDTO>();

                // Category (string or array)
                string categoryValue = props?["category"] switch
                {
                    JsonArray arr => string.Join(", ", arr.Select(x => x?.ToString())),
                    JsonValue val => val.ToString(),
                    _ => null
                };

                var dto = new PageDTO
                {
                    ExternalId = (string?)props?["externalId"],
                    PageType = (string?)props?["pageType"],
                    Title = (string?)props?["title"],
                    PublishDate = (string?)props?["publishDate"],
                    Category = categoryValue,
                    Author = (string?)props?["author"],
                    Meta = new MetaDTO
                    {
                        MetaTitle = (string?)metaProps?["metaTitle"],
                        MetaDescription = (string?)metaProps?["metaDescription"],
                        MetaKeywords = metaProps?["metaKeywords"] is JsonArray keywordsArray
                            ? keywordsArray.Select(k => (string?)k).Where(s => s != null).ToList()!
                            : new List<string>(),
                        MetaImageId = (int?)metaProps?["metaImageId"]
                    },
                    ContentBlocks = blocks
                };

                pages.Add(new Page(dto));
            }

            // 3) Filtering
            var data = pages.Cast<Page>().ToList();

            bool isSearchEmpty = string.IsNullOrWhiteSpace(searchTerm);
            bool isCategoryEmpty = string.IsNullOrWhiteSpace(category) || category.ToLower() == "all";

            if (isSearchEmpty && isCategoryEmpty)
            {
                return data
                    .Where(r => string.Equals(r.PageType, "Cluster Content Page", StringComparison.OrdinalIgnoreCase))
                    .Cast<IPage>()
                    .ToList();
            }

            string searchLower = isSearchEmpty ? string.Empty : searchTerm!.ToLower();
            string categoryLower = isCategoryEmpty ? string.Empty : category.ToLower();

            IEnumerable<Page> filtered = data;

            if (!isSearchEmpty)
            {
                filtered = filtered.Where(r =>
                    (!string.IsNullOrEmpty(r.Title) && r.Title.ToLower().Contains(searchLower)) ||
                    (!string.IsNullOrEmpty(r.Title) && r.Title.ToLower() == searchLower) ||
                    (r.Meta != null && !string.IsNullOrEmpty(r.Meta.MetaTitle) && r.Meta.MetaTitle.ToLower().Contains(searchLower)) ||
                    (r.Meta != null && !string.IsNullOrEmpty(r.Meta.MetaTitle) && r.Meta.MetaTitle.ToLower() == searchLower) ||
                    (r.Meta != null && !string.IsNullOrEmpty(r.Meta.MetaDescription) && r.Meta.MetaDescription.ToLower().Contains(searchLower)) ||
                    (r.Meta != null && !string.IsNullOrEmpty(r.Meta.MetaDescription) && r.Meta.MetaDescription.ToLower() == searchLower)
                );
            }

            if (!isCategoryEmpty)
            {
                filtered = filtered.Where(r =>
                    !string.IsNullOrEmpty(r.Category) &&
                    r.Category.ToLower().Contains(categoryLower));
            }

            var resultFinal = filtered
                .Where(r => string.Equals(r.PageType, "Cluster Content Page", StringComparison.OrdinalIgnoreCase))
                .Cast<IPage>()
                .ToList();

            return resultFinal;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while fetching pages from Umbraco delivery API", ex);
        }
    }
}
