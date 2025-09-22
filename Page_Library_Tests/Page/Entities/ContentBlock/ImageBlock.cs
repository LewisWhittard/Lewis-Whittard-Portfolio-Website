using Moq;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Content.Entities.Content.DTO;
using Page_Library.Content.Entities.Content;

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
                MediaId = 42
            };

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
            var block = new ImageBlock(dto, image);

            // Assert
            Assert.Equal("Image", block.BlockType);
            Assert.Equal("Center", block.Alignment);
            Assert.Equal(42, block.MediaId);
            Assert.Equal(image, block.Content);
        }
    }
}

