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
                .Select(item => item?["content"]?["properties"])
                .Where(p => p != null)
                .Select(p => new ContentBlockDTO
                {
                    BlockType = (string?)p["blockType"],
                    Alignment = (string?)p["alignment"],
                    Level = (string?)p["hLevel"],
                    Text = (string?)p["text"],
                    BodyText = (string?)p["bodyText"],
                    MediaId = (int?)p["mediaId"],
                    Url = (string?)p["url"],
                    LinkText = (string?)p["linkText"]
                })
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
                ExternalId = (string?)props?["externalId"],   // FIXED
                PageType = (string?)props?["pageType"],
                Title = (string?)props?["title"],             // FIXED
                PublishDate = (string?)props?["publishDate"],
                Category = category,                          // FIXED
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
                    .Select(it => it?["content"]?["properties"])
                    .Where(p => p != null)
                    .Select(p => new ContentBlockDTO
                    {
                        BlockType = (string?)p["blockType"],
                        Alignment = (string?)p["alignment"],
                        Level = (string?)p["hLevel"],
                        Text = (string?)p["text"],
                        BodyText = (string?)p["bodyText"],
                        MediaId = (int?)p["mediaId"],
                        Url = (string?)p["url"],
                        LinkText = (string?)p["linkText"]
                    })
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

            // 3) Filtering - use same semantics as previous implementation but null-safe and case-insensitive
            var data = pages.Cast<Page>().ToList(); // Page inherits PageBase, which exposes properties

            bool isSearchEmpty = string.IsNullOrWhiteSpace(searchTerm);
            bool isCategoryEmpty = string.IsNullOrWhiteSpace(category) || category.ToLower() == "all";

            if (isSearchEmpty && isCategoryEmpty)
            {
                return data.Where(r => string.Equals(r.PageType, "Cluster Content Page", StringComparison.OrdinalIgnoreCase)).Cast<IPage>().ToList();
            }

            // Prepare lowercase search strings
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
                filtered = filtered.Where(r => !string.IsNullOrEmpty(r.Category) && r.Category.ToLower().Contains(categoryLower));
            }

            // Always restrict to Cluster Content Page as original logic
            var resultFinal = filtered.Where(r => string.Equals(r.PageType, "Cluster Content Page", StringComparison.OrdinalIgnoreCase)).Cast<IPage>().ToList();

            return resultFinal;
        }
        catch (Exception ex)
        {
            throw new Exception("Error occurred while fetching pages from Umbraco delivery API", ex);
        }
    }
}
