using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Factory;
using Page_Library.Page.Entities.ContentBlock;
using Page_Library.Content.Entities.Content.DTO;

namespace Page_Library_Tests.Page.Factory
{
    public class ContentBlockFactoryTests
    {
        private readonly ContentBlockFactory _factory = new ContentBlockFactory();

        [Fact]
        public void CreateContentBlock_Header_ReturnsHeaderBlock()
        {
            var dto = new ContentBlockDTO { BlockType = "Header" };
            var result = _factory.CreateContentBlock(dto, null);
            Assert.IsType<HeaderBlock>(result);
        }

        [Fact]
        public void CreateContentBlock_Hyperlink_ReturnsHyperlinkBlock()
        {
            var dto = new ContentBlockDTO { BlockType = "Hyperlink" };
            var result = _factory.CreateContentBlock(dto, null);
            Assert.IsType<HyperlinkBlock>(result);
        }

        [Fact]
        public void CreateContentBlock_Paragraph_ReturnsParagraphBlock()
        {
            var dto = new ContentBlockDTO { BlockType = "Paragraph" };
            var result = _factory.CreateContentBlock(dto, null);
            Assert.IsType<ParagraphBlock>(result);
        }

        [Fact]
        public void CreateContentBlock_Image_WithValidContent_ReturnsImageBlock()
        {
            var dto = new ContentBlockDTO { BlockType = "Image", MediaId = 1 };
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
            var image = new Page_Library.Content.Entities.Content.Image(contentDTO);
            var result = _factory.CreateContentBlock(dto, image);
            Assert.IsType<ImageBlock>(result);
        }

        [Fact]
        public void CreateContentBlock_Image_WithInvalidContent_ThrowsInvalidCastException()
        {
            var dto = new ContentBlockDTO { BlockType = "Image" };
            // Arrange
            var contentDTO = new contentDTO
            {
                ID = 1,
                Name = "Test Name",
                Path = "/test/path.jpg",
                Description = "Test desc",
                ContentType = "Video"
            };

            // Act
            var video = new Page_Library.Content.Entities.Content.Video(contentDTO);
            Assert.Throws<InvalidCastException>(() => _factory.CreateContentBlock(dto, video));
        }

        [Fact]
        public void CreateContentBlock_Video_WithValidContent_ReturnsVideoBlock()
        {
            var dto = new ContentBlockDTO { BlockType = "Video", MediaId = 1 };
            // Arrange
            var contentDTO = new contentDTO
            {
                ID = 1,
                Name = "Test Name",
                Path = "/test/path.jpg",
                Description = "Test desc",
                ContentType = "Video"
            };

            // Act
            var video = new Page_Library.Content.Entities.Content.Video(contentDTO);
            var result = _factory.CreateContentBlock(dto, video);
            Assert.IsType<VideoBlock>(result);
        }

        [Fact]
        public void CreateContentBlock_Video_WithInvalidContent_ThrowsInvalidCastException()
        {
            var dto = new ContentBlockDTO { BlockType = "Video" };
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
            var image = new Page_Library.Content.Entities.Content.Image(contentDTO);
            Assert.Throws<InvalidCastException>(() => _factory.CreateContentBlock(dto, image));
        }

        [Fact]
        public void CreateContentBlock_UnsupportedType_ThrowsArgumentException()
        {
            var dto = new ContentBlockDTO { BlockType = "UnknownType" };
            Assert.Throws<ArgumentException>(() => _factory.CreateContentBlock(dto, null));
        }
    }
}