using SEO.Models.Meta.Interface;
using SEO.Repository.MockMetaRepository;
using SEO.Service.MetaService;

namespace SEOTests.Service
{
    public class MetaServiceTests
    {
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
        public void GetByPageName_ReturnsMeta(int pageId, bool includeInactive)
        {
            // Arrange
            MockMetaRepository mockMetaRepository = new MockMetaRepository();
            MetaService metaService = new MetaService(mockMetaRepository);
            // Act
            List<MetaData> metaData = metaService.GetByPageId(pageId, includeInactive);

            // Assert
            if (pageId == 3 || pageId == 4 || pageId == 6)
            {
                Assert.True(metaData.Count() == 0);
            }
            else
            {
                foreach (var item in metaData)
                {
                    Assert.Equal(pageId, item.PageId);
                }

                if (pageId == 2)
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
}

