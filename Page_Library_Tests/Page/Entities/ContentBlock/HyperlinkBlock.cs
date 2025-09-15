using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library_Tests.Page.Entities.ContentBlock
{
    public class HyperlinkBlock
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var dto = new ContentBlockDTO
            {
                BlockType = "Hyperlink",
                Alignment = "Left",
                Url = "https://example.com",
                LinkText = "Click here"
            };

            // Act
            var block = new Page_Library.Page.Entities.ContentBlock.HyperlinkBlock(dto);

            // Assert
            Assert.Equal("Hyperlink", block.BlockType);
            Assert.Equal("Left", block.Alignment);
            Assert.Equal("https://example.com", block.Url);
            Assert.Equal("Click here", block.LinkText);
        }


    }
}
