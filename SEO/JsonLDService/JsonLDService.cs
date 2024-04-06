using SEO.JsonLDService.Interface;
using SEO.Models.JsonLD.Interface;

namespace SEO.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        List<IJsonLDData> IJsonLDService.Get(string PageName)
        {
            throw new NotImplementedException();
        }
    }
}
