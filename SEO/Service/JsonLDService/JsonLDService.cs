using SEO.Models.JsonLD.Interface;
using SEO.Service.JsonLDService.Interface;

namespace SEO.Service.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        List<IJsonLDData> IJsonLDService.Get(string PageName)
        {
            throw new NotImplementedException();
        }
    }
}
