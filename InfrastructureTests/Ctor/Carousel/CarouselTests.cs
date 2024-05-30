using Infrastructure.Models.Data.Carousel;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Ctor
{
    public class CarouselTests
    {
        public List<Image> _images { get; set; }



        public void SetUp()
        {
            _images = new List<Image>();

            _images.Add(new Image("ImageSource0", 0, 0, false, false, "ImageGuid0"));
            _images.Add(new Image("ImageSource1", 1, 1, false, false, "ImageGuid1"));
            _images.Add(new Image("ImageSource2", 2, 2, false, false, "ImageGuid2"));
        }
        [Fact]
        public void Carousel_Constructor_NoParameters()
        {
            //arrange, act
            Carousel carousel = new Carousel();

            //assert
            Assert.Equal(0, carousel.Id);
            Assert.False(carousel.Deleted);
            Assert.False(carousel.Inactive);
            Assert.Null(carousel.Images);
            Assert.Null(carousel.DisplayOrder);
            Assert.Equal(UIConcrete.Carousel, carousel.UIConcreteType);
            Assert.Null(carousel.GUID);
        }

        [Theory]
        [InlineData(1, true, false, 4, "guid1")]
        [InlineData(2, false, true, 3, "guid2")]
        [InlineData(3, false, false, 2, "guid3")]
        [InlineData(4, true, true, 1, "guid4")]
        public void Constructor_Parameterized_ShouldInitializeProperties(int id, bool deleted, bool inactive, int displayOrder, string guid)
        {
            // Act, arrange
            SetUp();
            var carousel = new Carousel(id, deleted, inactive, _images, displayOrder, guid);

            // Assert
            Assert.Equal(id, carousel.Id);
            Assert.Equal(deleted, carousel.Deleted);
            Assert.Equal(inactive, carousel.Inactive);
            Assert.Equal(_images, carousel.Images);
            Assert.Equal(displayOrder, carousel.DisplayOrder);
            Assert.Equal(UIConcrete.Carousel, carousel.UIConcreteType);
            Assert.Equal(guid, carousel.GUID);
        }

        public void TearDown()
        {
            _images.Clear();
        }
    }
}
