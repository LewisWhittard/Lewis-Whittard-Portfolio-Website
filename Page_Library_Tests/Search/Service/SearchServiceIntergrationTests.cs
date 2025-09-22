using Page_Library.Content.Repository;
using Page_Library.Search.Repository;
using Page_Library.Search.Service;

namespace Page_Library_Tests.Search.Service
{
    public class SearchServiceIntergrationTests
    {
        [Theory]
        [InlineData("language", true, false, false, false, false, false, 1)]
        [InlineData("TDD", false, true, false, false, false, false, 1)]
        [InlineData("engine", false, false, true, false, false, false, 1)]
        [InlineData("Models", false, false, false, true, false, false, 1)]
        [InlineData("Sprites", false, false, false, false, true, false, 1)]
        [InlineData("Blog test", false, false, false, false, false, true, 1)]
        [InlineData("Dev", true, true, true, true, true, true, 3)]
        [InlineData("Nonexistent", true, true, true, true, true, true, 0)]
        [InlineData("Intro", false, false, false, false, false, false, 0)]
        public void SearchService_GetPageById_Correctly(string searchTerm,
        bool programming,
        bool testing,
        bool games,
        bool threeDAssets,
        bool twoDAssets,
        bool blog,
        int expectedCount)
        {
            var SearchPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Search", "Search.json");
            var ContentPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");

            JsonPageSearchRepository SearchRepository = new JsonPageSearchRepository(SearchPath);
            JsonContentRepository ContentRepository = new JsonContentRepository(ContentPath);

            PageSearchService service = new PageSearchService(SearchRepository, ContentRepository);

            var results = service.Search(searchTerm, programming, testing, games, threeDAssets, twoDAssets, blog);

            // Assert

            foreach (var item in results)
            {
                Assert.Equal(searchTerm.ToLower(), item.Title.ToLower());
                Assert.NotNull(item.Content);
            }

            Assert.Equal(expectedCount, results.Count);
        }
    }
}
