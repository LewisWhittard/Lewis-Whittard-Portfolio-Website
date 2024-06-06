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

            };
        }

        public List<MetaData> GetMetaDatas()
        {
            return _metaDataLDData;
        }
    }
}
