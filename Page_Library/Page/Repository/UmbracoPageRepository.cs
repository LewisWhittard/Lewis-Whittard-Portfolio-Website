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
                BlockType = p["blockType"]?
    .ToString()?
    .Trim('[', ']', '"', ' ')
    ?? null,

                Alignment = (string?)p["alignment"],
                Level = (string?)p["hLevel"],
                Text = (string?)p["text"],
                BodyText = (string?)p["bodyText"],
                MediaId = (int?)p["mediaId"],
                Url = (string?)p["url"],
                LinkText = (string?)p["linkText"]
            })
            .ToList() ?? new List<ContentBlockDTO>();

        // --- PAGE DTO ---
        var dto = new PageDTO
        {
            ExternalId = (string?)json["id"],
            PageType = (string?)props?["pageType"],
            Title = (string?)json["name"],
            PublishDate = (string?)props?["publishedDate"],
            Category = (string?)props?["category"],
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

        Page page = new Page(dto);

        return (IPage)page;
    }

    public override List<IPage> GetPages(string? searchTerm, string category)
    {
        throw new NotImplementedException();
    }
}
