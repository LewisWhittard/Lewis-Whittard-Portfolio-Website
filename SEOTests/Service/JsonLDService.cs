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
        public void GetBySuperClassGUID_ReturnsJsonLD(string superClassGUID, bool includeInactive)
        {
            // Arrange
            MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
            JsonLDService jsonLDService = new JsonLDService(mockJsonLDRepository);
            // Act
            List<JsonLDData> jsonLDData = jsonLDService.GetBySuperClassGUID(superClassGUID, includeInactive);

            // Assert
            if (superClassGUID == "Non" || superClassGUID == "Deleted" || superClassGUID == "ExcludeInactive")
            {
                Assert.True(jsonLDData.Count() == 0);
            }
            else
            {
                foreach (var item in jsonLDData)
                {
                    Assert.Equal(superClassGUID, item.SuperClassGUID);
                }

                if (superClassGUID == "Multiple")
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
