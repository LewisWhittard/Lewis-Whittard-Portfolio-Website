using SEO.Models.JsonLD;
using SEO.Models.JsonLD.Interface;
using SEO.Repository.JsonLDRepository.Interface;
using SEO.Service.JsonLDService.Interface;

namespace SEO.Service.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        private readonly IJsonLDRepository _jsonLDRepository;

        public JsonLDService(IJsonLDRepository jsonLDRepository)
        {
            _jsonLDRepository = jsonLDRepository;
        }

        public List<JsonLDData> GetBySuperClassGUID(string superClassGUID, bool includeInactive)
        {
            if (includeInactive == true)
            {
                return _jsonLDRepository.GetJsonLDs().Where(x => x.SuperClassGUID == superClassGUID &&  !x.Deleted).ToList();
            }
            else
            {
                return _jsonLDRepository.GetJsonLDs().Where(x => x.SuperClassGUID == superClassGUID && !x.Deleted && !x.Inactive).ToList();
            }
        }
    }
}
