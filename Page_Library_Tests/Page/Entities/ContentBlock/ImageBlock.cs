using Moq;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Content.Entities.Content.Interface;

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
                MediaId = 42,
                AltText = "A scenic mountain view"
            };

            var mockContent = new Mock<IContent>();

            // Act
            var block = new ImageBlock(dto, mockContent.Object);

            // Assert
            Assert.Equal("Image", block.BlockType);
            Assert.Equal("Center", block.Alignment);
            Assert.Equal(42, block.MediaId);
            Assert.Equal("A scenic mountain view", block.AltText);
            Assert.Equal(mockContent.Object, block.Content);
        }
    }
}

