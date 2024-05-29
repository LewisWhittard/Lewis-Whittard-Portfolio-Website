using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Ctor
{
    public class CarouselCardTests
    {
        private List<Card> _cards;

        public void SetUp()
        {
            Image _image = new Image();
        }

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

        [Theory]
        [InlineData(1, true, false, 5, "test-guid")]
        [InlineData(2, false, true, 10, "another-guid")]
        [InlineData(1, true, true, 5, "test-guid")]
        [InlineData(2, false, false, 10, "another-guid")]
        public void ParameterizedConstructor_ShouldInitializeWithGivenValues(
            int id, bool deleted, bool inactive, int? displayOrder, string gUID)
        {
            // Arrange,Act
            SetUp();
            var carouselCard = new Infrastructure.Models.Data.CarouselCard.CarouselCard(id, deleted, inactive, _cards, displayOrder, gUID);

            // Assert
            Assert.Equal(id, carouselCard.Id);
            Assert.Equal(deleted, carouselCard.Deleted);
            Assert.Equal(inactive, carouselCard.Inactive);
            Assert.Equal(_cards, carouselCard.Cards);
            Assert.Equal(displayOrder, carouselCard.DisplayOrder);
            Assert.Equal(gUID, carouselCard.GUID);
            Assert.Equal(UIConcrete.CarouselCard, carouselCard.UIConcreteType);

            TearDown();
        }

        public void TearDown()
        {

        }
    }
}
