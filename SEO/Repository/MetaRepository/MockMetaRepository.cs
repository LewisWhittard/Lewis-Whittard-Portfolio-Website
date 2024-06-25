using SEO.Model.Meta.Interface;
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
                //first
                new MetaData(0,Name.Description,"Content0","UTF-8",false,false,0),
                //second
                new MetaData(1,Name.OGTitle,"Content1","UTF-8",false,false,1),
                //multiple
                new MetaData(2,Name.Author,"Content2","UTF-8",false,false,2),
                new MetaData(3,Name.OGTitle,"Content3","UTF-8",false,false,2),
                //deleted
                new MetaData(6,Name.Author,"Content6","UTF-8",true,false,4),
                //include inactive
                new MetaData(4,Name.Description,"Content4","UTF-8",false,true,5),
                //exclude inactive
                new MetaData(5,Name.OGTitle,"Content5","UTF-8",false,true,6)
                
            };
        }

        public List<MetaData> GetMetaDatas()
        {
            return _metaDataLDData;
        }
    }
}
