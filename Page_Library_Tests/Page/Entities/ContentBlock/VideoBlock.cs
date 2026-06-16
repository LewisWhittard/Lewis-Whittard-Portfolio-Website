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
                VideoUrl = "/test/video.mp4",
                ThumbnailUrl = "/test/thumb.jpg",
                VideoTitle = "Test Title",
                Description = "Test desc"
            };

            // Act
            var block = new Page_Library.Page.Entities.ContentBlock.VideoBlock(dto);

            // Assert
            Assert.Equal("Video", block.BlockType);
            Assert.Equal("Right", block.Alignment);
            Assert.Equal("/test/video.mp4", block.URL);
            Assert.Equal("/test/thumb.jpg", block.ThumbnailURL);
            Assert.Equal("Test Title", block.Title);
            Assert.Equal("Test desc", block.Description);
        }
    }
}
