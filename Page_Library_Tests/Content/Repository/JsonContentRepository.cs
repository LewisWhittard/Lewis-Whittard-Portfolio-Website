using Page_Library.Content.Entities.Content;
using Page_Library.Content.Repository;

namespace Page_Library_Tests.Content.Repository
{
    public class JsonContentRepositoryTests
    {
        [Theory]
        [InlineData(0, typeof(Image))]
        [InlineData(4, typeof(Video))]
        public void GetContent_ByID_ReturnsCorrectly(int id, Type expectedType)
        {
            // Arrange
            var jsonPath = Path.Combine(AppContext.BaseDirectory, "TestData", "Content", "content.json");
            var repo = new JsonContentRepository(jsonPath);

            // Act
            var content = repo.GetContent(id);

            // Assert
            Assert.NotNull(content);
            Assert.IsType(expectedType, content);
            Assert.Equal(id, content.ID);
        }


    }
}
