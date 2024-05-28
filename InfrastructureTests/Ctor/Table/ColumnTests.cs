using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table;

namespace InfrastructureTests.Ctor
{
    public class ColumnTests
    {
        [Fact]
        public void Column_Constructor_NoParameters()
        {
            // Act and arrange
            var column = new Column();


            // Assert
            Assert.Equal(0, column.Id);
            Assert.False(column.Deleted);
            Assert.False(column.Inactive);
            Assert.Null(column.Value);
            Assert.Null(column.DisplayOrder);
            Assert.Equal(0, column.TableID);
            Assert.Null(column.GUID);
            Assert.Equal(UIConcrete.Column, column.UIConcreteType);
        }

        [Theory]
        [InlineData(1, false, true, "Test Value", 10, 20, "ABC123",0)]
        [InlineData(2, true, false, "Another Value", 5, 15, "XYZ789",1)]
        public void Constructor_InitializesPropertiesCorrectly(int id, bool deleted, bool inactive, string value, int displayOrder, int tableID, string gUID, int rowId)
        {
            // Act
            var column = new Column(id, deleted, inactive, value, displayOrder, tableID, gUID,rowId);

            // Assert
            Assert.Equal(id, column.Id);
            Assert.Equal(deleted, column.Deleted);
            Assert.Equal(inactive, column.Inactive);
            Assert.Equal(value, column.Value);
            Assert.Equal(displayOrder, column.DisplayOrder);
            Assert.Equal(tableID, column.TableID);
            Assert.Equal(gUID, column.GUID);
            Assert.Equal(UIConcrete.Column, column.UIConcreteType);
            Assert.Equal(rowId, column.RowId);
        }
    }
}
