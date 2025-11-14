using Page_Library.Page.Entities.Page.DTO;
using Page_Library.Page.Entities.Page.DTO.Umbraco;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Repository.Base;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Page_Library.Page.Repository
{
    public class UmbracoHTTPClientPageRepository : PageRepositoryBase
    {
        private readonly HttpClient _httpClient;

        public UmbracoHTTPClientPageRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:44396/");
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<UmbracoPageDto> GetHomePageByContentName(string name)
        {
            var response = await _httpClient.GetAsync("umbraco/delivery/api/v2/content/item/" + name);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var dto = JsonSerializer.Deserialize<UmbracoPageDto>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return dto;
        }

        public override IPage GetPage(string Id)
        {
            var task = Task.Run(() => GetHomePageByContentName(Id));
            var dto = task.Result;
            return null;

        }
    }
}