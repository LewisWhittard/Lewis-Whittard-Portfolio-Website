using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Model
{
    public class HeadingTests
    {
        [Fact]
        public void Header_Constructor_NoParameters()
        {
            // Arrange & Act
            var heading = new Heading();

            // Assert
            Assert.NotNull(heading);
            Assert.Equal(0, heading.Id);
            Assert.False(heading.Deleted);
            Assert.False(heading.Inactive);
            Assert.Null(heading.Text);
            Assert.Null(heading.DisplayOrder);
            Assert.Equal(0, heading.InformationBlockid);
            Assert.Null(heading.UIID);
            Assert.Equal(0, heading.Level);
            Assert.Equal(UIConcrete.Heading, heading.UIConcreteType);
        }

        [Theory]
        [InlineData(1, false, true, "Test Heading", 10, 1, "ABC123", 1)]
        [InlineData(2, true, false, "Another Heading", 5, 2, "XYZ789", 2)]
        [InlineData(1, true, true, "Test Heading", 10, 1, "ABC123", 1)]
        [InlineData(2, false, false, "Another Heading", 5, 2, "XYZ789", 2)]
        public void Constructor_InitializesPropertiesCorrectly(int id, bool deleted, bool inactive, string text, int displayOrder, int informationBlockid, string uIId, int level)
        {
            // Act
            var heading = new Heading(id, deleted, inactive, text, displayOrder, informationBlockid, uIId, level);

            // Assert
            Assert.Equal(id, heading.Id);
            Assert.Equal(deleted, heading.Deleted);
            Assert.Equal(inactive, heading.Inactive);
            Assert.Equal(text, heading.Text);
            Assert.Equal(displayOrder, heading.DisplayOrder);
            Assert.Equal(informationBlockid, heading.InformationBlockid);
            Assert.Equal(uIId, heading.UIID);
            Assert.Equal(level, heading.Level);
            Assert.Equal(UIConcrete.Heading, heading.UIConcreteType);
        }
    }
}
