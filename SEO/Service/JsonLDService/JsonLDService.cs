using SEO.Model.JsonLD;
using SEO.Model.Meta.Interface;
using SEO.Repository.JsonLDRepository.Interface;
using SEO.Repository.MetaRepository.Interface;
using SEO.Service.JsonLDService.Interface;

namespace SEO.Service.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        private readonly IJsonLDRepository _jsonLDRepository;

        public List<JsonLDData> GetByPageId(int pageId, bool includeInactive)
        {
            if (includeInactive == true)
            {
                return _jsonLDRepository.GetJsonLDatas().Where(x => x.PageId == pageId && !x.Deleted).ToList();
            }

            else
            {
                return _jsonLDRepository.GetJsonLDatas().Where(x => x.PageId == pageId && !x.Deleted && !x.Inactive).ToList();
            }
        }

        public JsonLDService(IJsonLDRepository jsonLDRepository)
        {
            _jsonLDRepository = jsonLDRepository;
        }

        public List<JsonLDData> GetBySuperClassGUID(string superClassGUID, bool includeInactive)
        {
            if (includeInactive == true)
            {
                return _jsonLDRepository.GetJsonLDatas().Where(x => x.SuperClassGUID == superClassGUID &&  !x.Deleted).ToList();
            }
            else
            {
                return _jsonLDRepository.GetJsonLDatas().Where(x => x.SuperClassGUID == superClassGUID && !x.Deleted && !x.Inactive).ToList();
            }
        }
    }
}
