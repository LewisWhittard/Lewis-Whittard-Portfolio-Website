using Infrastructure.Service.Page;
using Infrastructure.Repository.Page;
using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Service
{
    public class PageServiceTests
    {
        [Theory]
        [InlineData("First", false)]
        [InlineData("Second", false)]
        [InlineData("Non", false)]
        [InlineData("Deleted", false)]
        [InlineData("IncludeInactive", true)]
        [InlineData("ExcludeInactive", false)]
        public void GetByPageName_ReturnsPage(string pageName, bool includeInactive)
        {
            // Arrange
            var mockRepository = new MockPageRepository();
            var pageService = new PageService(mockRepository);

            // Act
            Infrastructure.Models.Data.Page.Page? page = pageService.GetByPageName(pageName, includeInactive);

            // Assert
            if (pageName == "Non" || pageName == "Deleted" || pageName == "ExcludeInactive")
            {
                Assert.Null(page);
            }
            else
            {
                Assert.Equal(pageName, page.PageName);
            }
        }

        [Theory]
        [InlineData("First", false)]
        [InlineData("Second", false)]
        [InlineData("Non", false)]
        [InlineData("Deleted", false)]
        [InlineData("IncludeInactive", true)]
        [InlineData("ExcludeInactive", false)]
        public void GetByPageNameAsIDataList_ReturnsIDataList(string pageName, bool includeInactive)
        {
            try
            {
                // Arrange
                var mockRepository = new MockPageRepository();
                var pageService = new PageService(mockRepository);

                // Act
                List<IData> pageIDatas = pageService.GetByPageNameAsIDataList(pageName, includeInactive);

                //assert
                if (pageName != "First")
                {
                    Assert.Equal(pageIDatas.Count(), 0);
                }

                else 
                {
                    Assert.Equal(pageIDatas.Count(), 1);
                }
            }
            catch (Exception)
            {
                if (pageName == "Non" || pageName == "Deleted" || pageName == "ExcludeInactive")
                {
                    Assert.True(true);
                }

                else 
                { 
                    Assert.True(false); 
                }
            }
        }
    }
}
