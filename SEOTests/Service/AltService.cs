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
        public void GetByUIId_ReturnsALT(string uIId, bool includeInactive)
        {
            // Arrange
            MockAltRepository altRepository = new MockAltRepository();
            AltService altService = new AltService(altRepository);
            // Act
            AltData altData = altService.GetByUIId(uIId, includeInactive);

            // Assert
            if (uIId == "Non" || uIId == "Deleted" || uIId == "ExcludeInactive")
            {
                Assert.Null(altData);
            }
            else
            {
                Assert.Equal(uIId, altData.UIId);
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