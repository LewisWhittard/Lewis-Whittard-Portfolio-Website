using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock;

namespace Page_Library_Tests.Page.Entities.ContentBlock
{
    public class ImageBlockTests
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var dto = new ContentBlockDTO
            {
                BlockType = "Image",
                Alignment = "Center",
                ImageUrl = "/test/path.jpg",
                Alt = "Test Alt"
            };

            // Act
            var block = new ImageBlock(dto);

            // Assert
            Assert.Equal("Image", block.BlockType);
            Assert.Equal("Center", block.Alignment);
            Assert.Equal("/test/path.jpg", block.URL);
            Assert.Equal("Test Alt", block.Alt);
        }
    }
}
