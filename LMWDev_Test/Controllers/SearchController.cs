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
    public class SearchControllerTests
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
        private LMWDev.Controllers.SearchController CreateControllerWithSession(
            IPageService pageService,
            ILogger<LMWDev.Controllers.SearchController> logger)
        {
            var controller = new LMWDev.Controllers.SearchController(pageService, logger);

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
        [InlineData("1", "Category1")]
        [InlineData("2", "Category1")]
        [InlineData("3", "Category2")]
        public void SearchController_ReturnIndexViewModel_Correctly(string id, string category)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.SearchController>>();
            var pageServiceMock = new Mock<IPageService>();

            var searchResults1 = new List<ISearchResult>
            {
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object
            };

            var searchResults2 = new List<ISearchResult>
            {
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object
            };

            var searchResults3 = new List<ISearchResult>
            {
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object,
                new Mock<ISearchResult>().Object
            };

            pageServiceMock.Setup(s => s.Search("1", "Category1")).Returns(searchResults1);
            pageServiceMock.Setup(s => s.Search("2", "Category1")).Returns(searchResults2);
            pageServiceMock.Setup(s => s.Search("3", "Category2")).Returns(searchResults3);

            var controller = CreateControllerWithSession(
                pageServiceMock.Object,
                loggerMock.Object
            );

            // Act
            var result = controller.Index(new SearchViewModel { Search = id, Category = category });

            // Assert
            var model = Assert.IsType<SearchViewModel>(((ViewResult)result).Model);

            if (id == "1")
                Assert.Equal(searchResults1, model.Results);
            else if (id == "2")
                Assert.Equal(searchResults2, model.Results);
            else
                Assert.Equal(searchResults3, model.Results);
        }
    }
}