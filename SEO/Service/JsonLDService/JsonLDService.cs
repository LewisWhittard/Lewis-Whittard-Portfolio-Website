using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using SEO.Service.JsonLDService.Interface;

namespace SEO.Service.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        public List<IJsonLDData> GetBySuperClassGUID(IData data)
        {
            return new List<IJsonLDData>();
        }
    }
}
