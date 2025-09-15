using Page_Library.Page.Entities.ContentBlock.Base;
using Page_Library.Page.Entities.ContentBlock.DTO;

namespace Page_Library_Tests.Page.Entities.ContentBlock
{
    public class HeaderBlock
    {
        [Fact]
        public void Constructor_SetsAllPropertiesCorrectly()
        {
            // Arrange
            var dto = new ContentBlockDTO
            {
                BlockType = "Header",
                Alignment = "Right",
                Level = "H2",
                Text = "Welcome to the Jungle"
            };

            // Act
            var block = new Page_Library.Page.Entities.ContentBlock.HeaderBlock(dto);

            // Assert
            Assert.Equal("Header", block.BlockType);
            Assert.Equal("Right", block.Alignment);
            Assert.Equal("H2", block.Level);
            Assert.Equal("Welcome to the Jungle", block.Text);
        }
    }
}