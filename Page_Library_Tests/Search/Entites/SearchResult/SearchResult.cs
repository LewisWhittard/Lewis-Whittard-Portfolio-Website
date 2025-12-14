using Page_Library.Content.Entities.Content;
using Page_Library.Content.Entities.Content.DTO;
using Page_Library.Page.Entities.SearchResult.Base;
using Page_Library.Page.Entities.SearchResult.DTO;

namespace Page_Library_Tests.Search.Entites.SearchResult
{
    public class SearchResultBaseTests
    {
        private class TestSearchResult : SearchResultBase
        {
            public TestSearchResult(SearchResultDTO dto) : base(dto) { }
        }

        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var dto = new SearchResultDTO
            {
                ID = 1,
                Title = "Test Title",
                Description = "Test Description",
                ContentID = 42,
                Category = "Test Category"
            };

            // Act
            var result = new TestSearchResult(dto);

            // Assert
            Assert.Equal(1, result.ID);
            Assert.Equal("Test Title", result.Title);
            Assert.Equal("Test Description", result.Description);
            Assert.Equal(42, result.ContentID);
            Assert.Equal("Test Category", result.Category);
            Assert.Null(result.Content); // Content should be null initially
        }

        [Fact]
        public void SetContent_ShouldAssignImage()
        {
            // Arrange
            var dto = new SearchResultDTO
            {
                ID = 2,
                Title = "Another Title",
                Description = "Another Description",
                ContentID = 99,
                Category = "Another Category"
            };
            var result = new TestSearchResult(dto);

            // Arrange
            var contentDTO = new contentDTO
            {
                ID = 1,
                Name = "Test Name",
                Path = "/test/path.jpg",
                Alt = "Test Alt",
                ContentType = "Image"
            };

            // Act
            var image = new Image(contentDTO);

            // Act
            result.SetContent(image);

            // Assert
            Assert.Equal(image, result.Content);
        }
    }
}