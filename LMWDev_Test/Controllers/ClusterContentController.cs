using LMWDev.Controllers;
using LMWDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Page_Library.Page.Entities.Page;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Service.Interface;
using System.ComponentModel.DataAnnotations;

namespace LMWDev_Test.Controllers
{
    public class ClusterContentController
    {
        [Theory]
        [InlineData("1",0, "software-development")]
        [InlineData("2",1, "creative-works")]
        public void ClusterContentController_ReturnIndexViewModel_Correctly(string id, int count,string pillar)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();

            var mockPages = new List<Mock<IPage>>
            {
                new Mock<IPage>(), // corresponds to ID = 1
                new Mock<IPage>()  // corresponds to ID = 2
            };

            mockPages[0].Setup(p => p.Category).Returns("Software Development");
            mockPages[1].Setup(p => p.Category).Returns("Creative Works");
            mockPages[0].Setup(p => p.PageType).Returns("Cluster Content Page");
            mockPages[1].Setup(p => p.PageType).Returns("Cluster Content Page");

            pageServiceMock
                .Setup(service => service.GetPage("1"))
                .Returns(mockPages[0].Object);

            pageServiceMock
                .Setup(service => service.GetPage("2"))
                .Returns(mockPages[1].Object);

            var controller = new LMWDev.Controllers.ClusterContentController(loggerMock.Object, pageServiceMock.Object);

            // Act
            var result = controller.Index(pillar,id);

            // Assert
            var model = Assert.IsType<ClusterContentModel>(((ViewResult)result).Model);
            Assert.Equal(mockPages[count].Object, model.Page); // Adjusted index
        }

        [Theory]
        [InlineData("2", 0, "software-development")]
        [InlineData("1", 1, "creative-works")]
        public void ClusterContentController_WrongPageForPillar_404(string id, int count, string pillar)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();

            var mockPages = new List<Mock<IPage>>
            {
                new Mock<IPage>(), // corresponds to ID = 1
                new Mock<IPage>()  // corresponds to ID = 2
            };

            mockPages[0].Setup(p => p.Category).Returns("Software Development");
            mockPages[1].Setup(p => p.Category).Returns("Creative Works");
            mockPages[0].Setup(p => p.PageType).Returns("Cluster Content Page");
            mockPages[1].Setup(p => p.PageType).Returns("Cluster Content Page");

            pageServiceMock
                .Setup(service => service.GetPage("1"))
                .Returns(mockPages[0].Object);

            pageServiceMock
                .Setup(service => service.GetPage("2"))
                .Returns(mockPages[1].Object);

            var controller = new LMWDev.Controllers.ClusterContentController(loggerMock.Object, pageServiceMock.Object);

            // Act
            var result = controller.Index(pillar, id);

            // Assert
            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);

        }

        [Theory]
        [InlineData("1", 0, "software-development")]
        public void ClusterContentController_WrongPageType_404(string id, int count, string pillar)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();

            var mockPages = new List<Mock<IPage>>
            {
                new Mock<IPage>(), // corresponds to ID = 1
            };

            mockPages[0].Setup(p => p.Category).Returns("Software Development");
            mockPages[0].Setup(p => p.PageType).Returns("Pillar Page");


            pageServiceMock
                .Setup(service => service.GetPage("1"))
                .Returns(mockPages[0].Object);

            var controller = new LMWDev.Controllers.ClusterContentController(loggerMock.Object, pageServiceMock.Object);

            // Act
            var result = controller.Index(pillar, id);

            // Assert
            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);

        }
    }
}
