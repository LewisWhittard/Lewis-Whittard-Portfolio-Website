using SEO.Model.JsonLD;
using SEO.Model.JsonLD.Interface;

namespace SEO.Service.JsonLDService.Interface
{
    public interface IJsonLDService
    {
        public List<JsonLDData> GetByUIId(string uIId, bool includeInactive);

    }
}
