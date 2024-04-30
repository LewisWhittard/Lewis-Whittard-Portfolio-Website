using SEO.Models.JsonLD.Interface;
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
        JsonLDService JsonLDService = new JsonLDService();
        // Act
        List<IJsonLDData> altData = JsonLDService.GetBySuperClassGUID(superClassGUID, includeInactive);

        // Assert
        if (superClassGUID == "Non" || superClassGUID == "Deleted" || superClassGUID == "ExcludeInactive")
        {
            foreach (var item in altData)
            {
                Assert.Null(altData);
            }
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
}
