using Infrastructure.Repository.Page;
using Infrastructure.Service.Page;
using SEO.Repository.AltRepository;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Repository.MockMetaRepository;
using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using SEO.Service.MetaService;
using UIFactory.Factory.Concrete.Interface;

namespace UIFactoryTests.Factory
{
    public class UIFactoryTests
    {

        public void SetUp()
        {

        }

        [Theory]
        [InlineData("First")]
        [InlineData("Second")]
        [InlineData("Non")]
        [InlineData(null)]
        public void UIFactory_CreateConcreteUIListByPageName(string Page)
        {
            // Arrange
            var mockPageService = new PageService(new MockPageRepository());
            var mockJsonLDService = new JsonLDService(new MockJsonLDRepository());
            var mockAltService = new AltService(new MockAltRepository());
            var mockMetaService = new MetaService(new MockMetaRepository());
            var uIFactory = new UIFactory.Factory.UIFactory(mockPageService, mockJsonLDService, mockAltService, mockMetaService);

            // Act
            List<IConcreteUI> concreteUIList = uIFactory.CreateConcreteUIListByPageName("First");

            if (Page == "Non" || Page == null)
            {
                Assert.Equal(concreteUIList.Count(), 0);
            }

            else
            {

            }
        }

        public void TearDown()
        {

        }
    }
}
