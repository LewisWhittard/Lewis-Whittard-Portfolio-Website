using JsonLD_Library.Service.Interface;
using LMWDev.Controllers;
using LMWDev.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;
using Page_Library.Page.Service.Interface;
using static LMWDev_Test.Controllers.AccessibilityControllerTests;

namespace LMWDev_Test.Controllers
{
    public class ClusterContentControllerTests
    {
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

        private ClusterContentController CreateControllerWithSession(
            ILogger<ClusterContentController> logger,
            IPageService pageService,
            IJsonLDService jsonLDService)
        {
            var controller = new ClusterContentController(logger, pageService, jsonLDService);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = CreateHttpContextWithSession()
            };

            return controller;
        }

        private Mock<IJsonLDService> CreateJsonLdMock()
        {
            var jsonLdMock = new Mock<IJsonLDService>();

            jsonLdMock
                .Setup(x => x.GenerateJsonLDCulsterContentPage(It.IsAny<IPage>()))
                .Returns("{}");

            jsonLdMock
                .Setup(x => x.GenerateJsonLDHomePage())
                .Returns("{}");

            jsonLdMock
                .Setup(x => x.GenerateJsonLDPillarPage(
                    It.IsAny<IPage>(),
                    It.IsAny<List<ISearchResult>>()))
                .Returns("{}");

            return jsonLdMock;
        }

        // -----------------------------
        // Tests
        // -----------------------------
        [Theory]
        [InlineData("1", 0, "software-development")]
        [InlineData("2", 1, "creative-works")]
        public void ClusterContentController_ReturnIndexViewModel_Correctly(string id, int count, string pillar)
        {
            var loggerMock = new Mock<ILogger<ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();
            var jsonLdMock = CreateJsonLdMock();

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
                pageServiceMock.Object,
                jsonLdMock.Object
            );

            var result = controller.Index(pillar, id);

            var model = Assert.IsType<ClusterContentModel>(((ViewResult)result).Model);
            Assert.Equal(mockPages[count].Object, model.Page);
        }

        [Theory]
        [InlineData("2", 0, "software-development")]
        [InlineData("1", 1, "creative-works")]
        public void ClusterContentController_WrongPageForPillar_404(string id, int count, string pillar)
        {
            var loggerMock = new Mock<ILogger<ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();
            var jsonLdMock = CreateJsonLdMock();

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
                pageServiceMock.Object,
                jsonLdMock.Object
            );

            var result = controller.Index(pillar, id);

            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);
        }

        [Theory]
        [InlineData("1", 0, "software-development")]
        public void ClusterContentController_WrongPageType_404(string id, int count, string pillar)
        {
            var loggerMock = new Mock<ILogger<ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();
            var jsonLdMock = CreateJsonLdMock();

            var mockPages = new List<Mock<IPage>>
            {
                new Mock<IPage>()
            };

            mockPages[0].Setup(p => p.Category).Returns("Software Development");
            mockPages[0].Setup(p => p.PageType).Returns("Pillar Page");

            pageServiceMock.Setup(s => s.GetPage("1")).Returns(mockPages[0].Object);

            var controller = CreateControllerWithSession(
                loggerMock.Object,
                pageServiceMock.Object,
                jsonLdMock.Object
            );

            var result = controller.Index(pillar, id);

            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);
        }

        [Theory]
        [InlineData("1", "software-development")]
        public void ClusterContentController_CommaCategory_SoftwareDevelopment_WrongPillar_404(string id, string pillar)
        {
            var loggerMock = new Mock<ILogger<ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();
            var jsonLdMock = CreateJsonLdMock();

            var pageMock = new Mock<IPage>();
            pageMock.Setup(p => p.Category).Returns("Creative Works, Software Development");
            pageMock.Setup(p => p.PageType).Returns("Cluster Content Page");

            pageServiceMock.Setup(s => s.GetPage(id)).Returns(pageMock.Object);

            var controller = CreateControllerWithSession(
                loggerMock.Object,
                pageServiceMock.Object,
                jsonLdMock.Object
            );

            var result = controller.Index(pillar, id);

            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);
        }

        [Theory]
        [InlineData("1", "creative-works")]
        public void ClusterContentController_CommaCategory_CreativeWorks_WrongPillar_404(string id, string pillar)
        {
            var loggerMock = new Mock<ILogger<ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();
            var jsonLdMock = CreateJsonLdMock();

            var pageMock = new Mock<IPage>();
            pageMock.Setup(p => p.Category).Returns("Software Development,Creative Works");
            pageMock.Setup(p => p.PageType).Returns("Cluster Content Page");

            pageServiceMock.Setup(s => s.GetPage(id)).Returns(pageMock.Object);

            var controller = CreateControllerWithSession(
                loggerMock.Object,
                pageServiceMock.Object,
                jsonLdMock.Object
            );

            var result = controller.Index(pillar, id);

            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);
        }

        [Theory]
        [InlineData("1", "intersections")]
        public void ClusterContentController_NonCommaCategory_IntersectionsPillar_404(string id, string pillar)
        {
            var loggerMock = new Mock<ILogger<ClusterContentController>>();
            var pageServiceMock = new Mock<IPageService>();
            var jsonLdMock = CreateJsonLdMock();

            var pageMock = new Mock<IPage>();
            pageMock.Setup(p => p.Category).Returns("Software Development");
            pageMock.Setup(p => p.PageType).Returns("Cluster Content Page");

            pageServiceMock.Setup(s => s.GetPage(id)).Returns(pageMock.Object);

            var controller = CreateControllerWithSession(
                loggerMock.Object,
                pageServiceMock.Object,
                jsonLdMock.Object
            );

            var result = controller.Index(pillar, id);

            var notFound = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFound.StatusCode);
        }
    }
}