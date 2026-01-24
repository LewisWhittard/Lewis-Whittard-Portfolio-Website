using LMWDev.Controllers;
using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Service.Interface;
using static LMWDev_Test.Controllers.AccessibilityControllerTests;

namespace LMWDev_Test.Controllers
{
    public class ClusterContentControllerTests
    {
        // -----------------------------
        // 1. Create HttpContext + Session
        // -----------------------------
        private HttpContext CreateHttpContextWithSession()
        {
            var context = new DefaultHttpContext();
            var session = new TestSession();

            context.Features.Set<ISessionFeature>(new SessionFeature { Session = session });
            context.Session = session;

            return context;
        }

        public class SessionFeature : ISessionFeature
        {
            public ISession Session { get; set; }
        }

        // -----------------------------
        // 2. Create controller with session
        // -----------------------------
        private LMWDev.Controllers.ClusterContentController CreateControllerWithSession(
            ILogger<LMWDev.Controllers.ClusterContentController> logger,
            IPageService pageService)
        {
            var controller = new LMWDev.Controllers.ClusterContentController(logger, pageService);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = CreateHttpContextWithSession()
            };

            return controller;
        }

        // -----------------------------
        // 3. Tests
        // -----------------------------
        [Theory]
        [InlineData("1", 0, "software-development")]
        [InlineData("2", 1, "creative-works")]
        public void ClusterContentController_ReturnIndexViewModel_Correctly(string id, int count, string pillar)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();

            var mockPages = new List<Mock<IPage>>
            {
                new Mock<IPage>(),
                new Mock<IPage>()
            };

            mockPages[0].Setup(p => p.Category).Returns("Software Development");
            mockPages[1].Setup(p => p.Category).Returns("Creative Works");
            mockPages[0].Setup(p => p.PageType).Returns("Cluster Content Page");
            mockPages[1].Setup(p => p.PageType).Returns("Cluster Content Page");

            pageServiceMock.Setup(s => s.GetPage("1")).Returns(mockPages[0].Object);
            pageServiceMock.Setup(s => s.GetPage("2")).Returns(mockPages[1].Object);

            var controller = CreateControllerWithSession(
                loggerMock.Object,
                pageServiceMock.Object
            );

            // Act
            var result = controller.Index(pillar, id);

            // Assert
            var model = Assert.IsType<ClusterContentModel>(((ViewResult)result).Model);
            Assert.Equal(mockPages[count].Object, model.Page);
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
                new Mock<IPage>(),
                new Mock<IPage>()
            };

            mockPages[0].Setup(p => p.Category).Returns("Software Development");
            mockPages[1].Setup(p => p.Category).Returns("Creative Works");
            mockPages[0].Setup(p => p.PageType).Returns("Cluster Content Page");
            mockPages[1].Setup(p => p.PageType).Returns("Cluster Content Page");

            pageServiceMock.Setup(s => s.GetPage("1")).Returns(mockPages[0].Object);
            pageServiceMock.Setup(s => s.GetPage("2")).Returns(mockPages[1].Object);

            var controller = CreateControllerWithSession(
                loggerMock.Object,
                pageServiceMock.Object
            );

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
                new Mock<IPage>()
            };

            mockPages[0].Setup(p => p.Category).Returns("Software Development");
            mockPages[0].Setup(p => p.PageType).Returns("Pillar Page");

            pageServiceMock.Setup(s => s.GetPage("1")).Returns(mockPages[0].Object);

            var controller = CreateControllerWithSession(
                loggerMock.Object,
                pageServiceMock.Object
            );

            // Act
            var result = controller.Index(pillar, id);

            // Assert
            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);
        }
    }
}