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
        throw new NotImplementedException();
    }
}
