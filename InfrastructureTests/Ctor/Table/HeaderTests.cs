using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Table;

namespace InfrastructureTests.Ctor
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
            Assert.Null(header.GUID);
            Assert.Equal(UIConcrete.Header, header.UIConcreteType);
        }
    }
}
