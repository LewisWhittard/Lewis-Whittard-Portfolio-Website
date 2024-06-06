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
                //first
                new MetaData(0,Name.Description,"Content0","GUID0","UTF-8",false,false,0,0),
                //second
                new MetaData(1,Name.OGTitle,"Content1","GUID1","UTF-8",false,false,1,1),
                //multiple
                new MetaData(2,Name.Author,"Content2","GUID2","UTF-8",false,false,2,2),
                new MetaData(3,Name.OGTitle,"Content3","GUID3","UTF-8",false,false,3,2),
                //deleted
                new MetaData(6,Name.Author,"Content6","GUID6","UTF-8",true,false,6,4),
                //include inactive
                new MetaData(4,Name.Description,"Content4","GUID4","UTF-8",false,true,4,5),
                //exclude inactive
                new MetaData(5,Name.OGTitle,"Content5","GUID5","UTF-8",false,true,5,6)
                
            };
        }

        public List<MetaData> GetMetaDatas()
        {
            return _metaDataLDData;
        }
    }
}
