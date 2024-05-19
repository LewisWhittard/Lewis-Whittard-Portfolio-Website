using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table;

namespace InfrastructureTests.Ctor
{
    public class TableTests
    {
        [Fact]
        public void Table_Constructor_NoParameters()
        {
            // Arrange & Act
            var table = new Infrastructure.Models.Data.Table.Table();

            // Assert
            Assert.Equal(0, table.Id);
            Assert.Null(table.Title);
            Assert.False(table.Deleted);
            Assert.False(table.Inactive);
            Assert.Null(table.Headers);
            Assert.Null(table.Columns);
            Assert.Null(table.DisplayOrder);
            Assert.Null(table.GUID);
            Assert.Null(table.UIConcreteType);
        }
    }
}