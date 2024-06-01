using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Ctor
{
    public class CarouselCardTests
    {
        private List<Card> _cards { get; set; }

        private void SetUp()
        {
            Image image0 = new Image("Image0Source",0,0,false,false, "ImageGUID0");
            Image image1 = new Image("Image1Source", 1, 1, false, false, "ImageGUID1");
            Image image2 = new Image("Image2Source", 2, 2, false, false, "ImageGUID2");

            _cards = new List<Card>();

            _cards.Add(new Card(image0,"Title0","Description0","Navigation0",0,false,false,0,"CardGuid0",null));
            _cards.Add(new Card(image1, "Title1", "Description1", "Navigation1", 0, false, false, 0, "CardGuid1", null));
            _cards.Add(new Card(image2, "Title2", "Description2", "Navigation2", 0, false, false, 0, "CardGuid2", null));

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
            var carouselCard = new Infrastructure.Models.Data.CarouselCard.CarouselCard(id, deleted, inactive, _cards, displayOrder, gUID,1);

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

        private void TearDown()
        {
            _cards.Clear();
        }
    }
}
