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
                new JsonLDData("First",0,null,"FirstGUID",false,false,null),
                new JsonLDData("Second",1,null,"SecondGUID",false,false, null),
                new JsonLDData("Multiple",2,null,"MultipleGUID",false,false, null),
                new JsonLDData("Multiple",3,null,"MultipleGUID",false,false, null),
                new JsonLDData("IncludeInactive",4,null,"IncludeInactiveGUID",false,true, null),
                new JsonLDData("ExcludeInactive",5,null,"ExcludeInactiveGUID",false,true, null),
                new JsonLDData("Deleted",6,null,"DeletedGUID",true,false, 1),
                new JsonLDData(null,7,null,"FirstGUID",false,false,2),
                new JsonLDData(null,8,null,"SecondGUID",false,false, 3),
                new JsonLDData(null,9,null,"MultipleGUID",false,false, 4),
                new JsonLDData(null,10,null,"MultipleGUID",false,false, 4),
                new JsonLDData(null,11,null,"IncludeInactiveGUID",false,true, 5),
                new JsonLDData(null,12,null,"ExcludeInactiveGUID",false,true, 6),
                new JsonLDData(null,13,null,"DeletedGUID",true,false, 7)
            };
        }

        public List<JsonLDData> GetJsonLDs()
        {
            return _jsonLDData;
        }
    }
}
