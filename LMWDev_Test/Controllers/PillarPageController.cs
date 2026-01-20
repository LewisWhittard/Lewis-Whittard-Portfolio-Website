using LMWDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;
using Page_Library.Page.Service.Interface;

namespace LMWDev_Test.Controllers
{
    public class PillarPageController
    {
        [Theory]
        [InlineData("software-development", 0)]
        [InlineData("creative-works", 1)]
        public void Index_ReturnsViewModel_ForValidRoutes(string id, int index)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.PillarPageController>>();
            var pageServiceMock = new Mock<IPageService>();

            var mockPages = new List<IPage>
    {
        Mock.Of<IPage>(p => p.Category == "Category1"),
        Mock.Of<IPage>(p => p.Category == "Category2")
    };

            var mockSearchResultsOne = new List<ISearchResult>
    {
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object
    };

            var mockSearchResultsTwo = new List<ISearchResult>
    {
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object
    };

            pageServiceMock.Setup(s => s.GetPage("software-development"))
                           .Returns(mockPages[0]);

            pageServiceMock.Setup(s => s.GetPage("creative-works"))
                           .Returns(mockPages[1]);

            pageServiceMock.Setup(s => s.Search(null, "Category1"))
                           .Returns(mockSearchResultsOne);

            pageServiceMock.Setup(s => s.Search(null, "Category2"))
                           .Returns(mockSearchResultsTwo);

            var controller = new LMWDev.Controllers.PillarPageController(loggerMock.Object, pageServiceMock.Object);

            // Act
            var result = controller.Index(id);

            // Assert
            var model = Assert.IsType<PillarPageModel>(((ViewResult)result).Model);
            Assert.Equal(mockPages[index], model.Page);

            if (id == "software-development")
                Assert.Equal(mockSearchResultsOne, model.Results);
            else
                Assert.Equal(mockSearchResultsTwo, model.Results);
        }
    }
}