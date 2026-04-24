using Page_Library.Page.Entities.Page.DTO;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Base;
using System.Net.Http.Json;

public class UmbracoPageRepository : PageRepositoryBase
{
    private readonly HttpClient _http;

    public UmbracoPageRepository(HttpClient http)
    {
        _http = http;
    }

    public override IPage GetPage(string idOrSlug)
    {
        // Build the Delivery API v2 route URL
        var url = $"/umbraco/delivery/api/v2/content/item/{idOrSlug}";

        // Correct: call HttpClient using the URL (not the variable name)
        var dto = _http.GetFromJsonAsync<PageDTO>(url).Result;

        // Map into your domain Page object
        return new Page_Library.Page.Entities.Page.Page(dto);
    }


    public override List<IPage> GetPages(string? searchTerm, string category)
    {
        throw new NotImplementedException("List queries not implemented yet.");
    }
}
