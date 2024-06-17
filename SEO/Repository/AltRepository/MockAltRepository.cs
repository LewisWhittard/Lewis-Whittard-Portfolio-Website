using SEO.Model.Alt;
using SEO.Repository.AltRepository.Interface;

namespace SEO.Repository.AltRepository
{
    public class MockAltRepository : IAltRepository
    {
        List<AltData> _altData;

        public MockAltRepository()
        {
            _altData = new List<AltData>()
            {
                new AltData("First",null,"FirstValue",null,0,false,false),
                new AltData("Second",null,"SecondValue",null,1,false,false),
                new AltData("Multiple",null,"MultipleValue",null,2,false,false),
                new AltData("Multiple",null,"MultipleValue2",null,2,false,false),
                new AltData("Deleted",null,"DeletedValue",null,4,true,false),
                new AltData("IncludeInactive",null,"IncludeInactiveValue",null,5,false,true),
            };
        }

        public List<AltData> GetAltDatas()
        {
            return _altData;
        }
    }
}
