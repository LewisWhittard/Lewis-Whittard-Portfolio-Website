using LMWDev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Page_Library.Page.Entities.Page.Interface;
using Page_Library.Page.Entities.SearchResult.Interface;
using Page_Library.Page.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMWDev_Test.Controllers
{
    public class SearchController
    {
        [Theory]
        [InlineData("1", "Category1")]
        [InlineData("2", "Category1")]
        [InlineData("3", "Category2")]
        public void SearchController_ReturnIndexViewModel_Correctly(string id, string category)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.SearchController>>();
            var pageServiceMock = new Mock<IPageService>();


            // Create mock search results for ID = 1
            var searchResults1 = new List<ISearchResult>
    {
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object
    };

            // Create mock search results for ID = 2
            var searchResults2 = new List<ISearchResult>
    {
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object
    };

            // Create mock search results for ID = 2
            var searchResults3 = new List<ISearchResult>
    {
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object,
        new Mock<ISearchResult>().Object
    };

            // Setup the service to return the correct list based on ID
            pageServiceMock
                .Setup(service => service.Search("1", "Category1"))
                .Returns(searchResults1);

            pageServiceMock
                .Setup(service => service.Search("2", "Category1"))
                .Returns(searchResults2);
            
            pageServiceMock
                .Setup(service => service.Search("3", "Category2"))
                .Returns(searchResults3);

            var controller = new LMWDev.Controllers.SearchController(pageServiceMock.Object, loggerMock.Object);

            // Act
            var result = controller.Index(new SearchViewModel { Search = id, Category = category });

            // Assert
            var model = Assert.IsType<SearchViewModel>(((ViewResult)result).Model);

            // Validate the correct list was returned

            if (id == "1")
            {
                Assert.Equal(searchResults1, model.Results);
            }
            else if (id == "2")
            {
                Assert.Equal(searchResults2, model.Results);
            }
            else
            {
                Assert.Equal(searchResults3, model.Results);
            }
        }
    }
}