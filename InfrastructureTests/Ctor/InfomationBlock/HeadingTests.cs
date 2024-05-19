using Infrastructure.Models.Data.InfomationBlock;
using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor
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
            Assert.Equal(0, heading.InfomationBlockid);
            Assert.Null(heading.GUID);
            Assert.Equal(0, heading.Level);
            Assert.Equal(UIConcrete.Heading, heading.UIConcreteType);
        }
    }
}
