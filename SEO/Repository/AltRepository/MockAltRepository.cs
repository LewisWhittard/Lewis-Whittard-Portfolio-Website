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
                new AltData() {SuperClassGUID = "First", Deleted = false, Inactive = false },
                new AltData() {SuperClassGUID = "Second", Deleted = false, Inactive = false},
                new AltData() {SuperClassGUID = "Multiple", Deleted = false, Inactive = false},
                new AltData() {SuperClassGUID = "Multiple", Deleted = false, Inactive = false},
                new AltData() {SuperClassGUID = "Deleted", Deleted = true, Inactive = false},
                new AltData() {SuperClassGUID = "IncludeInactive", Deleted = false, Inactive = true},
                new AltData() {SuperClassGUID = "ExcludeInactive", Deleted = false, Inactive = true}
            };
        }

        public List<AltData> GetAltDatas()
        {
            return _altData;
        }
    }
}
