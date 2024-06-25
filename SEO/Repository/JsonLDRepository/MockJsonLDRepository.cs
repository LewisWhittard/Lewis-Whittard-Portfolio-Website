using SEO.Model.JsonLD;
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
                new JsonLDData("First",0,false,false,null),
                new JsonLDData("Second",1,false,false, null),
                new JsonLDData("Multiple",2,false,false, null),
                new JsonLDData("Multiple",3,false,false, null),
                new JsonLDData("IncludeInactive",4,false,true, null),
                new JsonLDData("ExcludeInactive",5,false,true, null),
                new JsonLDData("Deleted",6,true,false, 1),
                new JsonLDData(null,7,false,false,2),
                new JsonLDData(null,8,false,false, 3),
                new JsonLDData(null,9,false,false, 4),
                new JsonLDData(null,10,false,false, 4),
                new JsonLDData(null,11,false,true, 5),
                new JsonLDData(null,12,false,true, 6),
                new JsonLDData(null,13,true,false, 7)
            };
        }

        public List<JsonLDData> GetJsonLDatas()
        {
            return _jsonLDData;
        }
    }
}
