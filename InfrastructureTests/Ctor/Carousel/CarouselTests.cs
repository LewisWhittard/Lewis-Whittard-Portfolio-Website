using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor
{
    public class CarouselTests
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
