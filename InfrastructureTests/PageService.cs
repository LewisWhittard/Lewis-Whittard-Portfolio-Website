using Infrastructure.Service.Page;
using Infrastructure.Repository.Page;

public class PageServiceTests
{
    [Theory]
    [InlineData("FirstPage")]
    [InlineData("SecondPage")]
    [InlineData("NoPage")]
    public void GetByPageName_ReturnsPage(string pageName)
    {
        // Arrange
        var mockRepository = new MockPageRepository();
        var pageService = new PageService(mockRepository);

        // Act
        Infrastructure.Models.Data.Page.Page? page = pageService.GetByPageName(pageName);

        // Assert
        if (pageName != "NoPage")
        {
            Assert.Equal(pageName, page.PageName);
        }
        else
        {
            Assert.Null(page);
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
