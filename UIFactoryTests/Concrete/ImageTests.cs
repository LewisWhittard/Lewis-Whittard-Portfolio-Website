using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;

namespace UIFactoryTests.Concrete
{
    public class ImageTests
    {
        private AltService _altService;
        private JsonLDService _jsonLDService;
        private Infrastructure.Models.Data.Shared.Image.Image _image;

        public void Setup()
        {
            MockAltRepository mockAltRepository = new MockAltRepository();
            _altService = new AltService(mockAltRepository);
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            _jsonLDService = new JsonLDService(mockJsonLDRepository);
            _image = new Infrastructure.Models.Data.Shared.Image.Image();
        }

        //teardown
        public void TearDown()
        {
            _altService = null;
            _jsonLDService = null;
            _image = null;
        }
    }
}
