using Infrastructure.Models.Data.InfomationBlock;
using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor
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
            Assert.Equal(0, paragraph.InfomationBlockid);
            Assert.Null(paragraph.GUID);
        }
    }
}
