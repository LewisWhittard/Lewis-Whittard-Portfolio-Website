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
                new JsonLDData("First",0,null,"FirstGUID",false,false),
                new JsonLDData("Second",1,null,"SecondGUID",false,false),
                new JsonLDData("Multiple",2,null,"MultipleGUID",false,false),
                new JsonLDData("Multiple",3,null,"MultipleGUID",false,false),
                new JsonLDData("IncludeInactive",4,null,"IncludeInactiveGUID",false,true),
                new JsonLDData("ExcludeInactive",5,null,"ExcludeInactiveGUID",false,true),
                new JsonLDData("Deleted",6,null,"DeletedGUID",true,false),
            };
        }

        public List<JsonLDData> GetJsonLDs()
        {
            return _jsonLDData;
        }
    }
}
