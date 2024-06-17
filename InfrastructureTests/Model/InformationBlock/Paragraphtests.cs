using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Model
{
    public class ParagraphTests
    {
        [Fact]
        public void Paragraph_Constructor_NoParameters()
        {
            // Arrange & Act
            var paragraph = new Paragraph();

            // Assert
            Assert.Equal(UIConcrete.Paragraph, paragraph.UIConcreteType);
            Assert.Null(paragraph.Text);
            Assert.Null(paragraph.DisplayOrder);
            Assert.Equal(0, paragraph.Id);
            Assert.False(paragraph.Deleted);
            Assert.False(paragraph.Inactive);
            Assert.Equal(0, paragraph.InformationBlockid);
            Assert.Null(paragraph.GUID);
        }

        [Theory]
        [InlineData("Sample text", 1, 100, true, false, 200, "ABC123")]
        [InlineData("Another sample text", 2, 101, false, true, 201, "DEF456")]
        [InlineData("Sample text", 1, 100, false, false, 200, "ABC123")]
        [InlineData("Another sample text", 2, 101, true, true, 201, "DEF456")]
        // Add more inline data sets for additional test cases if needed
        public void Constructor_Initializes_Properties_Correctly(string text, int displayOrder, int id, bool deleted, bool inactive, int informationBlockId, string guid)
        {
            // Act
            var paragraph = new Paragraph(text, displayOrder, id, deleted, inactive, informationBlockId, guid);

            // Assert
            Assert.Equal(text, paragraph.Text);
            Assert.Equal(displayOrder, paragraph.DisplayOrder);
            Assert.Equal(id, paragraph.Id);
            Assert.Equal(deleted, paragraph.Deleted);
            Assert.Equal(inactive, paragraph.Inactive);
            Assert.Equal(informationBlockId, paragraph.InformationBlockid);
            Assert.Equal(guid, paragraph.GUID);
            Assert.Equal(UIConcrete.Paragraph, paragraph.UIConcreteType);
        }
    }
}
