using SEO.Models.JsonLD;
using SEO.Models.JsonLD.Interface;

namespace SEO.Service.JsonLDService.Interface
{
    public interface IJsonLDService
    {
        public List<JsonLDData> GetBySuperClassGUID(string superClassGUID, bool includeInactive);

    }
}
