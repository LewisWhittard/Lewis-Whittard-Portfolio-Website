using SEO.Models.Alt;
using SEO.Service.AltService;
public class PageServiceTests
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
        AltService altService = new AltService();
        // Act
        List<AltData> altData = altService.GetBySuperClassGUID(superClassGUID, includeInactive);

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
