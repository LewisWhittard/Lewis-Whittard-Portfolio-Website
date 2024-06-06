using SEO.Models.Alt;
using SEO.Models.Alt.Interface;
using SEO.Repository.AltRepository;
using SEO.Repository.AltRepository.Interface;
using SEO.Service.AltService;

namespace SEOTests.Service
{
    public class AltServiceTests
    {
        [Theory]
        [InlineData("First", false)]
        [InlineData("Second", false)]
        [InlineData("Multiple", false)]
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
            List<AltData> altData = altService.GetBySuperClassGUID(superClassGUID, includeInactive);

            // Assert
            if (superClassGUID == "Non" || superClassGUID == "Deleted" || superClassGUID == "ExcludeInactive")
            {
                Assert.True(altData.Count() == 0);
            }
            else
            {
                foreach (var item in altData)
                {
                    Assert.Equal(superClassGUID, item.SuperClassGUID);
                }

                if (superClassGUID == "Multiple")
                {
                    Assert.True(altData.Count() == 2);
                }

                else
                {
                    Assert.True(altData.Count() == 1);
                }
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