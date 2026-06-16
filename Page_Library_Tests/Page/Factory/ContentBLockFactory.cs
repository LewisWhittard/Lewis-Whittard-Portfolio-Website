using Page_Library.Page.Entities.ContentBlock.DTO;
using Page_Library.Page.Factory;
using Page_Library.Page.Entities.ContentBlock;

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
        public void CreateContentBlock_Image_ReturnsImageBlock()
        {
            var dto = new ContentBlockDTO
            {
                BlockType = "Image",
                ImageUrl = "/test/path.jpg",
                Alt = "Test Alt"
            };
            var result = _factory.CreateContentBlock(dto, null);
            Assert.IsType<ImageBlock>(result);
        }

        [Fact]
        public void CreateContentBlock_Video_ReturnsVideoBlock()
        {
            var dto = new ContentBlockDTO
            {
                BlockType = "Video",
                VideoUrl = "/test/video.mp4",
                ThumbnailUrl = "/test/thumb.jpg",
                VideoTitle = "Test Title",
                Description = "Test desc"
            };
            var result = _factory.CreateContentBlock(dto, null);
            Assert.IsType<VideoBlock>(result);
        }

        [Fact]
        public void CreateContentBlock_UnsupportedType_ThrowsArgumentException()
        {
            var dto = new ContentBlockDTO { BlockType = "UnknownType" };
            Assert.Throws<ArgumentException>(() => _factory.CreateContentBlock(dto, null));
        }
    }
}
