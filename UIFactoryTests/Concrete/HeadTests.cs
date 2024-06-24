using SEO.Model.Meta.Interface;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class HeadTests
    {
        private List<Infrastructure.Models.Data.Head.Head> _heads;
        private JsonLDService _jsonLDService;
        private MetaData _metaData;

        public void SetUp()
        {
            _heads.Add(new Infrastructure.Models.Data.Head.Head(0, false, false, "HeadTitle", 0, "First"));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(1, false, false, "HeadTitle", 1, "Second"));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(2, false, false, "HeadTitle", 2, "Non"));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(3, false, false, "HeadTitle", 3, null));
            _heads.Add(new Infrastructure.Models.Data.Head.Head(4, false, false, "HeadTitle", 4, "Multiple"));
        }

        private void TearDown()
        {
            _heads = null;
            _jsonLDService = null;
            _metaData = null;
        }
    }
}