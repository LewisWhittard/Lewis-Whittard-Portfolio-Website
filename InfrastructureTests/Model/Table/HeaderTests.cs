using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table;

namespace InfrastructureTests.Model
{
    public class HeaderTests
    {
        [Fact]
        public void Header_Constructor_NoParameters()
        {
            // Arrange and Act
            var header = new Header();

            // Assert
            Assert.Equal(0, header.Id);
            Assert.False(header.Deleted);
            Assert.False(header.Inactive);
            Assert.Null(header.DisplayOrder);
            Assert.Equal(0, header.TableID);
            Assert.Null(header.Value);
            Assert.Null(header.UIId);
            Assert.Equal(UIConcrete.Header, header.UIConcreteType);
        }

        [Theory]
        [InlineData(1, false, true, 10, 20, "Test Value", "ABC123")]
        [InlineData(2, true, false, 5, 15, "Another Value", "XYZ789")]
        [InlineData(1, true, true, 10, 20, "Test Value", "ABC123")]
        [InlineData(2, false, false, 5, 15, "Another Value", "XYZ789")]
        public void Constructor_InitializesPropertiesCorrectly(int id, bool deleted, bool inactive, int displayOrder, int tableID, string value, string uIId)
        {
            // Act
            var header = new Header(id, deleted, inactive, displayOrder, tableID, value, uIId);

            // Assert
            Assert.Equal(id, header.Id);
            Assert.Equal(deleted, header.Deleted);
            Assert.Equal(inactive, header.Inactive);
            Assert.Equal(displayOrder, header.DisplayOrder);
            Assert.Equal(tableID, header.TableID);
            Assert.Equal(value, header.Value);
            Assert.Equal(uIId, header.UIId);
            Assert.Equal(UIConcrete.Header, header.UIConcreteType);
        }
    }
}
