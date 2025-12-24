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
        [InlineData("1", 0)]
        [InlineData("2", 1)]
        public void PillarPage_Controller_ReturnIndexViewModel_Correctly(string id, int count)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.PillarPageController>>();
            var pageServiceMock = new Mock<IPageService>();

            var mockPages = new List<IPage>
            {
                Mock.Of<IPage>(p => p.Category == "Category1"),
                Mock.Of<IPage>(p => p.Category == "Category2")
            };

            var mockSearchReusltsOne = new List<ISearchResult>
            {
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object
            };

            var mockSearchReusltsTwo = new List<ISearchResult>
            {
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object
            };

            pageServiceMock
                .Setup(service => service.GetPage("1"))
                .Returns(mockPages[0]);

            pageServiceMock
                .Setup(service => service.GetPage("2"))
                .Returns(mockPages[1]);

            pageServiceMock
                .Setup(service => service.Search(null, "Category1"))
                .Returns(mockSearchReusltsOne);

            pageServiceMock
                .Setup(service => service.Search(null, "Category2"))
                .Returns(mockSearchReusltsTwo);


            var controller = new LMWDev.Controllers.PillarPageController(loggerMock.Object, pageServiceMock.Object);

            // Act
            var result = controller.Index(id);

            // Assert
            var model = Assert.IsType<PillarPageModel>(((ViewResult)result).Model);
            Assert.Equal(mockPages[count], model.Page); // Adjusted index
            Assert.Equal(mockPages[count], model.Page); // Adjusted index

            if (id == "1")
            {
                Assert.Equal(mockSearchReusltsOne, model.Results);

            }
            else
            {
                Assert.Equal(mockSearchReusltsTwo, model.Results);
            }
        }
    }
}