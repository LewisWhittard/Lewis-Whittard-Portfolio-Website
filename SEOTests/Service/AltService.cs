using SEO.Model.Alt;
using SEO.Repository.AltRepository;
using SEO.Service.AltService;

namespace SEOTests.Service
{
    public class AltServiceTests
    {
        [Theory]
        [InlineData("First", false)]
        [InlineData("Second", false)]
        [InlineData("Non", false)]
        [InlineData("Deleted", false)]
        [InlineData("IncludeInactive", true)]
        [InlineData("ExcludeInactive", false)]
        public void GetBySuperClassGUID_ReturnsALT(string superClassGUID, bool includeInactive)
        {
            // Arrange
            MockAltRepository altRepository = new MockAltRepository();
            AltService altService = new AltService(altRepository);
            // Act
            AltData altData = altService.GetBySuperClassGUID(superClassGUID, includeInactive);

            // Assert
            if (superClassGUID == "Non" || superClassGUID == "Deleted" || superClassGUID == "ExcludeInactive")
            {
                Assert.Null(altData);
            }
            else
            {
                Assert.Equal(superClassGUID, altData.SuperClassGUID);
            }
        }

        [Fact]
        public void AltService_Ctor()
        {
            // Arrange
            MockAltRepository altRepository = new MockAltRepository();
            // Act
            AltService altService = new AltService(altRepository);
            // Assert
            Assert.NotNull(altService);
        }
    }
}