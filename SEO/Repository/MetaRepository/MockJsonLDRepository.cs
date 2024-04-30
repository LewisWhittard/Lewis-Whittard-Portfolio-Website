using SEO.Models.Meta.Interface;
using SEO.Repository.MetaRepository.Interface;

namespace SEO.Repository.MockMetaRepository
{
    public class MockMetaRepository : IMetaRepository
    {
        private List<MetaData> _metaDataLDData {  get; set; }

        public MockMetaRepository()
        {
            _metaDataLDData = new List<MetaData>()
            {
                new MetaData() {GUID = "First", Deleted = false, Inactive = false },
                new MetaData() {GUID = "Second", Deleted = false, Inactive = false},
                new MetaData() {GUID = "Multiple", Deleted = false, Inactive = false},
                new MetaData() {GUID = "Multiple", Deleted = false, Inactive = false},
                new MetaData() {GUID = "Deleted", Deleted = true, Inactive = false},
                new MetaData() {GUID = "IncludeInactive", Deleted = false, Inactive = true},
                new MetaData() {GUID = "ExcludeInactive", Deleted = false, Inactive = true}
            };
        }

        public List<MetaData> GetMetaDatas()
        {
            return _metaDataLDData;
        }
    }
}
