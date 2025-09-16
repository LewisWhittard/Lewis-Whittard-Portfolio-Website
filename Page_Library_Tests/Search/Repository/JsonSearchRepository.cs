namespace Page_Library_Tests.Search.Repository
{
    public class SearchRepositoryTests
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
        [InlineData("Intro", false, false, false, false, false, false, 1)]
        public void Search_FullTitle_ReturnsExpectedResults(
        string searchTerm,
        bool programming,
        bool testing,
        bool games,
        bool threeDAssets,
        bool twoDAssets,
        bool blog,
        int expectedCount)
        {
            // Arrange
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Search", "Search.json");
            var repository = new Page_Library.Search.Repository.JsonPageSearchRepository(jsonPath);

            // Act
            var results = repository.Search(searchTerm, programming, testing, games, threeDAssets, twoDAssets, blog);

            // Assert

            foreach (var item in results)
            {
                Assert.Equal(searchTerm, item.Title);
            }

            Assert.Equal(expectedCount, results.Count);
        }

        [Theory]
        [InlineData("lan", true, false, false, false, false, false, 1)]
        [InlineData("TD", false, true, false, false, false, false, 1)]
        [InlineData("eng", false, false, true, false, false, false, 1)]
        [InlineData("Mod", false, false, false, true, false, false, 1)]
        [InlineData("Spr", false, false, false, false, true, false, 1)]
        [InlineData("Blo", false, false, false, false, false, true, 1)]
        [InlineData("Dev", true, true, true, true, true, true, 3)]
        [InlineData("In", false, false, false, false, false, false, 0)]
        [InlineData("tit", true, true, true, true, true, true, 0)]
        public void Search_SemiTitle_ReturnsExpectedResults(
        string searchTerm,
        bool programming,
        bool testing,
        bool games,
        bool threeDAssets,
        bool twoDAssets,
        bool blog,
        int expectedCount)
        {
            // Arrange
            var repository = new Page_Library.Search.Repository.JsonPageSearchRepository("");

            // Act
            var results = repository.Search(searchTerm, programming, testing, games, threeDAssets, twoDAssets, blog);

            // Assert

            foreach (var item in results)
            {
                Assert.Contains(searchTerm, item.Title);
            }

            Assert.Equal(expectedCount, results.Count);
        }

        [Theory]
        [InlineData("description test", true, true, true, true, true, true, 1)]
        [InlineData("description test 2", true, true, true, true, true, true, 2)]
        public void Search_FullDescription_ReturnsExpectedResults(
        string searchTerm,
        bool programming,
        bool testing,
        bool games,
        bool threeDAssets,
        bool twoDAssets,
        bool blog,
        int expectedCount)
        {
            // Arrange
            var repository = new Page_Library.Search.Repository.JsonPageSearchRepository("");

            // Act
            var results = repository.Search(searchTerm, programming, testing, games, threeDAssets, twoDAssets, blog);

            // Assert

            foreach (var item in results)
            {
                Assert.Equal(searchTerm, item.Title);
            }

            Assert.Equal(expectedCount, results.Count);
        }

        [Theory]
        [InlineData("desc", true, true, true, true, true, true, 3)]
        public void Search_SemiDescription_ReturnsExpectedResults(
        string searchTerm,
        bool programming,
        bool testing,
        bool games,
        bool threeDAssets,
        bool twoDAssets,
        bool blog,
        int expectedCount)
        {
            // Arrange
            var repository = new Page_Library.Search.Repository.JsonPageSearchRepository("");

            // Act
            var results = repository.Search(searchTerm, programming, testing, games, threeDAssets, twoDAssets, blog);

            // Assert

            foreach (var item in results)
            {
                Assert.Contains(searchTerm, item.Title);
            }

            Assert.Equal(expectedCount, results.Count);
        }
    }
}
