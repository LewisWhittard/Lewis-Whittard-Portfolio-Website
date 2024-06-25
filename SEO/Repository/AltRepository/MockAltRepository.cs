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
                new AltData("First","FirstValue",0,false,false),
                new AltData("Second","SecondValue",1,false,false),
                new AltData("Multiple","MultipleValue",2,false,false),
                new AltData("Multiple","MultipleValue2",2,false,false),
                new AltData("Deleted","DeletedValue",4,true,false),
                new AltData("IncludeInactive","IncludeInactiveValue",5,false,true),
            };
        }

        public List<AltData> GetAltDatas()
        {
            return _altData;
        }
    }
}
