using SEO.Models.Meta.Interface;
using SEO.Repository.MockMetaRepository;
using SEO.Service.MetaService;


public class MetaServiceTests
{
    [Theory]
    [InlineData("First", false)]
    [InlineData("Second", false)]
    [InlineData("Multiple", false)]
    [InlineData("Non", false)]
    [InlineData("Deleted", false)]
    [InlineData("IncludeInactive", true)]
    [InlineData("ExcludeInactive", false)]
    public void GetByPageName_ReturnsMeta(string pageName, bool includeInactive)
    {
        // Arrange
        MockMetaRepository mockMetaRepository = new MockMetaRepository();
        MetaService metaService = new MetaService(mockMetaRepository);
        // Act
        List<MetaData> metaData = metaService.GetByPageName(pageName, includeInactive);

        // Assert
        if (pageName == "Non" || pageName == "Deleted" || pageName == "ExcludeInactive")
        {
            Assert.True(metaData.Count() == 0);
        }
        else
        {
            foreach (var item in metaData)
            {
                Assert.Equal(pageName, item.PageName);
            }

            if (pageName == "Multiple")
            {
                Assert.True(metaData.Count() == 2);
            }

            else
            {
                Assert.True(metaData.Count() == 1);
            }
        }
    }
}

