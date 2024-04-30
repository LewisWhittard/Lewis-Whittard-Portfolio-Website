using SEO.Models.JsonLD;
using SEO.Models.JsonLD.Interface;

namespace SEO.Repository.JsonLDRepository.Interface
{
    public class IJsonLDRepository
    {
        List<JsonLDData> JsonLDData;

        public List<JsonLDData> GetJsonLDs()
        {
            return JsonLDData;
        }
    }
}
