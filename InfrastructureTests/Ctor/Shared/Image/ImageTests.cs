using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Model
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

        [Theory]
        [InlineData("example.jpg", 10, 1, false, true, "ABC123",1,null,null)]
        [InlineData("anotherexample.png", null, 2, true, false, "XYZ789",null,1,null)]
        [InlineData("example.jpg", 10, 1, true, true, "ABC123",null,null,1)]
        [InlineData("anotherexample.png", null, 2, false, false, "XYZ789",null,null,null)]
        public void Constructor_InitializesPropertiesCorrectly(string source, int? displayOrder, int id, bool deleted, bool inactive, string gUID, int? cardId, int? informationBlockId, int? carouselId)
        {
            // Act
            var image = new Image(source, displayOrder, id, deleted, inactive, gUID,cardId,informationBlockId,carouselId);

            // Assert
            Assert.Equal(source, image.Source);
            Assert.Equal(displayOrder, image.DisplayOrder);
            Assert.Equal(id, image.Id);
            Assert.Equal(deleted, image.Deleted);
            Assert.Equal(inactive, image.Inactive);
            Assert.Equal(gUID, image.GUID);
            Assert.Equal(UIConcrete.Image, image.UIConcreteType);
            Assert.Equal(cardId, image.CardId);
            Assert.Equal(informationBlockId, image.InformationBlockId);
            Assert.Equal(carouselId, image.CarouselId);
        }
    }
}
