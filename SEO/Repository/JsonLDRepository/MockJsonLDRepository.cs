using SEO.Models.JsonLD;
using SEO.Repository.JsonLDRepository.Interface;

namespace SEO.Repository.JsonLDRepositoryRepository
{
    public class MockJsonLDRepository : IJsonLDRepository
    {
        List<JsonLDData> _jsonLDData {  get; set; }

        public MockJsonLDRepository()
        {
            _jsonLDData = new List<JsonLDData>()
            {
                //new JsonLDData() {SuperClassGUID = "First", Deleted = false, Inactive = false },
                //new JsonLDData() {SuperClassGUID = "Second", Deleted = false, Inactive = false},
                //new JsonLDData() {SuperClassGUID = "Multiple", Deleted = false, Inactive = false},
                //new JsonLDData() {SuperClassGUID = "Multiple", Deleted = false, Inactive = false},
                //new JsonLDData() {SuperClassGUID = "Deleted", Deleted = true, Inactive = false},
                //new JsonLDData() {SuperClassGUID = "IncludeInactive", Deleted = false, Inactive = true},
                //new JsonLDData() {SuperClassGUID = "ExcludeInactive", Deleted = false, Inactive = true}
            };
        }

        public List<JsonLDData> GetJsonLDs()
        {
            return _jsonLDData;
        }
    }
}
