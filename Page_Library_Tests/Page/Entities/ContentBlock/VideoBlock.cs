using Moq;
using Page_Library.Content.Entities.Content;
using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Content.Entities.Content.DTO;

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
                MediaId = 99
            };

            // Arrange
            var contentDTO = new contentDTO()
            {
                ID = 1,
                Name = "Test Name",
                Path = "/test/path.jpg",
                Description = "Test desc",
                ContentType = "Video"
            };

            Video video = new Video(contentDTO);

            // Act
            var block = new Page_Library.Page.Entities.ContentBlock.VideoBlock(dto, video);

            // Assert
            Assert.Equal("Video", block.BlockType);
            Assert.Equal("Right", block.Alignment);
            Assert.Equal(99, block.MediaId);
            Assert.Equal(video, block.Content);
        }
    }
}
