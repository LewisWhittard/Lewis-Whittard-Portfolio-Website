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
    }
}
