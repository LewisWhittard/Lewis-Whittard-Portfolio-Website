using LMWDev.Controllers;
using LMWDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Page_Library.Page.Entities.Page;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Service.Interface;
using System.ComponentModel.DataAnnotations;

namespace LWMDev_Test.Controllers
{
    public class ClusterContentController
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ClusterContentController_ReturnIndexViewModel_Correctly(int ID)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();

            var mockPages = new List<Mock<IPage>>
            {
                new Mock<IPage>(), // corresponds to ID = 1
                new Mock<IPage>()  // corresponds to ID = 2
            };

            pageServiceMock
                .Setup(service => service.GetPage(1))
                .Returns(mockPages[0].Object);

            pageServiceMock
                .Setup(service => service.GetPage(2))
                .Returns(mockPages[1].Object);

            var controller = new LMWDev.Controllers.ClusterContentController(loggerMock.Object, pageServiceMock.Object);

            // Act
            var result = controller.Index(ID);

            // Assert
            var model = Assert.IsType<ClusterContentModel>(((ViewResult)result).Model);
            Assert.Equal(mockPages[ID - 1].Object, model.Page); // Adjusted index
        }
    }
}
