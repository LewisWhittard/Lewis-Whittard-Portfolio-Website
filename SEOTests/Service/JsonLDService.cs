using SEO.Model.JsonLD;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.JsonLDService;

namespace SEOTests.Service
{
    public class JsonLDServiceTests
    {
        [Theory]
        [InlineData("First", false)]
        [InlineData("Second", false)]
        [InlineData("Multiple", false)]
        [InlineData("Non", false)]
        [InlineData("Deleted", false)]
        [InlineData("IncludeInactive", true)]
        [InlineData("ExcludeInactive", false)]
        public void GetByUIId_ReturnsJsonLD(string uIId, bool includeInactive)
        {
            // Arrange
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            JsonLDService jsonLDService = new JsonLDService(mockJsonLDRepository);
            // Act
            List<JsonLDData> jsonLDData = jsonLDService.GetByUIId(uIId, includeInactive);

            // Assert
            if (uIId == "Non" || uIId == "Deleted" || uIId == "ExcludeInactive")
            {
                Assert.True(jsonLDData.Count() == 0);
            }
            else
            {
                foreach (var item in jsonLDData)
                {
                    Assert.Equal(uIId, item.UIId);
                }

                if (uIId == "Multiple")
                {
                    Assert.True(jsonLDData.Count() == 2);
                }

                else
                {
                    Assert.True(jsonLDData.Count() == 1);
                }
            }
        }

        [Theory]
        //first
        [InlineData(0, false)]
        //second
        [InlineData(1, false)]
        //multiple
        [InlineData(2, false)]
        //non
        [InlineData(3, false)]
        //deleted
        [InlineData(4, false)]
        //include inactive
        [InlineData(5, true)]
        //exclude inactive
        [InlineData(6, false)]
        public void GetByPageName_ReturnsJsonLD(int pageId, bool includeInactive)
        {
            // Arrange
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            JsonLDService jsonLDService = new JsonLDService(mockJsonLDRepository);
            // Act
            List<JsonLDData> jsonLDData = jsonLDService.GetByPageId(pageId, includeInactive);

            // Assert
            if (pageId == 3 || pageId == 4 || pageId == 6)
            {
                Assert.True(jsonLDData.Count() == 0);
            }
            else
            {
                foreach (var item in jsonLDData)
                {
                    Assert.Equal(pageId, item.PageId);
                }

                if (pageId == 2)
                {
                    Assert.True(jsonLDData.Count() == 2);
                }
                else
                {
                    Assert.True(jsonLDData.Count() == 1);
                }
            }
        }

        [Fact]
        public void JsonLDService_Ctor()
        {
            // Arrange
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            // Act
            JsonLDService jsonLDService = new JsonLDService(mockJsonLDRepository);
            // Assert
            Assert.NotNull(jsonLDService);
        }
    }
}
