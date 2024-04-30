using SEO.Models.JsonLD;
using SEO.Repository.JsonLDRepositoryRepository;
using SEO.Service.JsonLDService;

public class JsonLDServiceTests
{
    [Theory]
    [InlineData("First",false)]
    [InlineData("Second",false)]
    [InlineData("Multiple",false)]
    [InlineData("Non",false)]
    [InlineData("Deleted",false)]
    [InlineData("IncludeInactive",true)]
    [InlineData("ExcludeInactive", false)]
    public void GetBySuperClassGUID_ReturnsALT(string superClassGUID, bool includeInactive)
    {
        // Arrange
        MockJsonLDRepository mockJsonLDRepository = new MockJsonLDRepository();
        JsonLDService jsonLDService = new JsonLDService(mockJsonLDRepository);
        // Act
        List<JsonLDData> JsonData = jsonLDService.GetBySuperClassGUID(superClassGUID, includeInactive);

        // Assert
        if (superClassGUID == "Non" || superClassGUID == "Deleted" || superClassGUID == "ExcludeInactive")
        {
            foreach (var item in JsonData)
            {
                Assert.Null(JsonData);
            }
        }
        else
        {
            foreach (var item in JsonData) 
            { 
                Assert.Equal(superClassGUID, item.SuperClassGUID);
            }

            if (superClassGUID == "Multiple")
            {
                Assert.True(JsonData.Count() == 2);
            }

            else
            {
                Assert.True(JsonData.Count() == 1);
            }
        }
    }
}
