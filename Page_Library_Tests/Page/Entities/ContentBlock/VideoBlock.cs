using Moq;
using Page_Library.Content.Entities.Content.Interface;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library_Tests.Page.Entities.ContentBlock
{
    public class VideoBlock
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var dto = new ContentBlockDTO
            {
                BlockType = "Video",
                Alignment = "Right",
                MediaId = 99,
                Caption = "Watch this amazing clip"
            };

            var mockContent = new Mock<IContent>();

            // Act
            var block = new Page_Library.Page.Entities.ContentBlock.VideoBlock(dto, mockContent.Object);

            // Assert
            Assert.Equal("Video", block.BlockType);
            Assert.Equal("Right", block.Alignment);
            Assert.Equal(99, block.MediaId);
            Assert.Equal("Watch this amazing clip", block.Caption);
            Assert.Equal(mockContent.Object, block.Content);
        }
    }
}
