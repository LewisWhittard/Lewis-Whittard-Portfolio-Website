using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library_Tests.Page.Entities.ContentBlock
{
    public class ParagraphBlock
    {
        [Fact]
        public void Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var dto = new ContentBlockDTO
            {
                BlockType = "Paragraph",
                Alignment = "Justify",
                BodyText = "This is a sample paragraph."
            };

            // Act
            var block = new Page_Library.Page.Entities.ContentBlock.ParagraphBlock(dto);

            // Assert
            Assert.Equal("Paragraph", block.BlockType);
            Assert.Equal("Justify", block.Alignment);
            Assert.Equal("This is a sample paragraph.", block.BodyText);
        }
    }
}

