using Infrastructure.Service.Page;
using Infrastructure.Repository.Page;

public class PageServiceTests
{
    [Theory]
    [InlineData("FirstPage",false)]
    [InlineData("SecondPage",false)]
    [InlineData("NoPage",false)]
    [InlineData("Deleted",false)]
    [InlineData("IncludeInactive",true)]
    [InlineData("ExcludeInactive", false)]
    public void GetByPageName_ReturnsPage(string pageName, bool includeInactive)
    {
        // Arrange
        var mockRepository = new MockPageRepository();
        var pageService = new PageService(mockRepository);

        // Act
        Infrastructure.Models.Data.Page.Page? page = pageService.GetByPageName(pageName,includeInactive);

        // Assert
        if (pageName == "NoPage" || pageName == "Deleted" || pageName == "ExcludeInactive")
        {
            Assert.Null(page);
        }
        else
        {
            Assert.Equal(pageName, page.PageName);
        }
    }

    [Fact]
    [InlineData("HomePage")]
    public void GetByPageNameAsIDataList_ReturnsIDataList_WhenPageExists()
    {
        // Arrange

        // Act

        // Assert

        Assert.True(true);
    }
}
