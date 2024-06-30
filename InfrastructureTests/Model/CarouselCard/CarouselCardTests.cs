using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Model
{
    public class CarouselCardTests
    {
        private List<Card> _cards { get; set; }

        private void SetUp()
        {
            Image image0 = new Image("Image0Source",0,0,false,false, "ImageUIId0",0,null,null);
            Image image1 = new Image("Image1Source", 1, 1, false, false, "ImageUIId1", 1, null, null);
            Image image2 = new Image("Image2Source", 2, 2, false, false, "ImageUIId2", 2, null, null);

            _cards = new List<Card>();

            _cards.Add(new Card(image0,"Title0","Description0","Navigation0",0,false,false,0,"CardUIId0",null, null));
            _cards.Add(new Card(image1, "Title1", "Description1", "Navigation1", 1, false, false, 0, "CardUIId1", null, null));
            _cards.Add(new Card(image2, "Title2", "Description2", "Navigation2", 2, false, false, 0, "CardUIId2", null, null));

        }

        [Fact]
        public void CarouselCard_Constructor_NoParameters()
        {
            //arrange, act
            CarouselCard carouselCard = new CarouselCard();


            //assert
            Assert.Equal(0, carouselCard.Id);
            Assert.False(carouselCard.Deleted);
            Assert.False(carouselCard.Inactive);
            Assert.Null(carouselCard.Cards);
            Assert.Null(carouselCard.DisplayOrder);
            Assert.Equal(UIConcrete.CarouselCard, carouselCard.UIConcreteType);
            Assert.Null(carouselCard.UIId);
            Assert.Equal(0, carouselCard.PageId);
        }

        [Theory]
        [InlineData(1, true, false, 5, "test-uIId",5)]
        [InlineData(2, false, true, 10, "another-uIId",6)]
        [InlineData(1, true, true, 5, "test-uIId",7)]
        [InlineData(2, false, false, 10, "another-uIId",8)]
        public void ParameterizedConstructor_ShouldInitializeWithGivenValues(
            int id, bool deleted, bool inactive, int? displayOrder, string uIId, int pageId)
        {
            // Arrange,Act
            SetUp();
            var carouselCard = new CarouselCard(id, deleted, inactive, _cards, displayOrder, uIId,pageId);

            // Assert
            Assert.Equal(id, carouselCard.Id);
            Assert.Equal(deleted, carouselCard.Deleted);
            Assert.Equal(inactive, carouselCard.Inactive);
            Assert.Equal(_cards, carouselCard.Cards);
            Assert.Equal(displayOrder, carouselCard.DisplayOrder);
            Assert.Equal(uIId, carouselCard.UIId);
            Assert.Equal(UIConcrete.CarouselCard, carouselCard.UIConcreteType);
            Assert.Equal(pageId, carouselCard.PageId);

            TearDown();
        }

        private void TearDown()
        {
            _cards.Clear();
        }
    }
}
