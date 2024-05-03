using Infrastructure.Models.Data.Interface;

namespace InfrastructureTests.Ctor.CarouselCard
{
    public class CarouselCardTests
    {
        [Fact]
        public void CarouselCard_Constructor_NoParameters()
        {
            //arrange, act
            Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCard = new Infrastructure.Models.Data.CarouselCard.CarouselCard();


            //assert
            Assert.Equal(0, carouselCard.Id);
            Assert.False(carouselCard.Deleted);
            Assert.False(carouselCard.Inactive);
            Assert.Null(carouselCard.Cards);
            Assert.Null(carouselCard.DisplayOrder);
            Assert.Equal(UIConcrete.CarouselCard, carouselCard.UIConcreteType);
            Assert.Null(carouselCard.GUID);
        }
    }
}
