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
                //new MetaData() {PageName = "First", Deleted = false, Inactive = false },
                //new MetaData() {PageName = "Second", Deleted = false, Inactive = false},
                //new MetaData() {PageName = "Multiple", Deleted = false, Inactive = false},
                //new MetaData() {PageName = "Multiple", Deleted = false, Inactive = false},
                //new MetaData() {PageName = "Deleted", Deleted = true, Inactive = false},
                //new MetaData() {PageName = "IncludeInactive", Deleted = false, Inactive = true},
                //new MetaData() {PageName = "ExcludeInactive", Deleted = false, Inactive = true}
            };
        }

        public List<MetaData> GetMetaDatas()
        {
            return _metaDataLDData;
        }
    }
}
