using SEO.Models.Alt;
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
            };
        }

        public List<AltData> GetAltDatas()
        {
            return _altData;
        }
    }
}
