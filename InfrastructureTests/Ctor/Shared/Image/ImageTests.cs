using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Ctor
{
    public class ImageTests
    {
        [Fact]
        public void Image_Constructor_NoParameters()
        {
            // Arrange & Act
            var image = new Image();

            // Assert
            Assert.Null(image.Source);
            Assert.Null(image.DisplayOrder);
            Assert.Equal(0, image.Id);
            Assert.False(image.Deleted);
            Assert.False(image.Inactive);
            Assert.Null(image.GUID);
            Assert.Equal(UIConcrete.Image, image.UIConcreteType);
        }
    }
}
