using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Carousel;

namespace InfrastructureTests.Ctor.Carousel
{
    public class CarouselCardTests
    {
        [Fact]
        public void Carousel_Constructor_NoParameters()
        {
            //arrange, act
            Infrastructure.Models.Data.Carousel.Carousel carousel = new Infrastructure.Models.Data.Carousel.Carousel();

            //assert
            Assert.Equal(0, carousel.Id);
            Assert.False(carousel.Deleted);
            Assert.False(carousel.Inactive);
            Assert.Null(carousel.Images);
            Assert.Null(carousel.DisplayOrder);
            Assert.Equal(UIConcrete.Carousel, carousel.UIConcreteType);
            Assert.Null(carousel.GUID);
        }
    }
}
