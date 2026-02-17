using Microsoft.AspNetCore.Http;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;

namespace JsonLD_Library.Service.Interface
{
    public interface IJsonLDService
    {
        public string GenerateJsonLDCulsterContentPage(IPage page);
        public string GenerateJsonLDHomePage();
        public string GenerateJsonLDPillarPage(IPage page, List<ISearchResult> ClustercontentPages);

    }
}
