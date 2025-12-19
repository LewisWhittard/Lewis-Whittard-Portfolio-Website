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
        [InlineData("1")]
        [InlineData("2")]
        public void SearchController_ReturnIndexViewModel_Correctly(string ID)
        {
            // Arrange
            var loggerMock = new Mock<ILogger<LMWDev.Controllers.SearchController>>();
            var searchServiceMock = new Mock<Page_Library.Search.Service.Interface.IPageSearchService>();

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

            // Setup the service to return the correct list based on ID
            searchServiceMock
                .Setup(service => service.Search("1", true, true, true, true, true, true))
                .Returns(searchResults1);

            searchServiceMock
                .Setup(service => service.Search("2", true, true, true, true, true, true))
                .Returns(searchResults2);

            var controller = new LMWDev.Controllers.SearchController(searchServiceMock.Object, loggerMock.Object);

            // Act
            var result = controller.Index(new SearchViewModel { Search = ID });

            // Assert
            var model = Assert.IsType<SearchViewModel>(((ViewResult)result).Model);

            // Validate the correct list was returned
            var expectedResults = ID == "1" ? searchResults1 : searchResults2;
            Assert.Equal(expectedResults, model.Results); // Assuming model.Pages is the property holding the list
        }
    }
}