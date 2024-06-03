using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;

namespace InfrastructureTests.Ctor
{
    public class CardTests
    {
        private Image _image { get; set; }

        private void SetUp()
        {
            _image = new Image("Source", 0, 0, false, false, "GUID",null,null,null);
        }

        [Fact]
        public void Card_Constructor_NoParameters()
        {
            // Arrange & Act
            Card card = new Card();

            // Assert
            Assert.Equal(UIConcrete.Card, card.UIConcreteType);
            Assert.Null(card.Image);
            Assert.Null(card.Title);
            Assert.Null(card.Description);
            Assert.Null(card.Navigation);
            Assert.Equal(0, card.Id);
            Assert.False(card.Deleted);
            Assert.False(card.Inactive);
            Assert.Null(card.DisplayOrder);
            Assert.Null(card.GUID);
        }

        [Theory]
        [InlineData("Sample Title 1", "Sample Description 1", "Sample Navigation 1", 1, true, false, 10, "12345-67890",7)]
        [InlineData("Sample Title 2", "Sample Description 2", "Sample Navigation 2", 2, false, true, 20, "54321-09876",8)]
        [InlineData("Sample Title 1", "Sample Description 1", "Sample Navigation 1", 1, true, true, 10, "12345-67890",9)]
        [InlineData("Sample Title 2", "Sample Description 2", "Sample Navigation 2", 2, false, false, 20, "54321-09876",10)]
        [InlineData("Sample Title 2", "Sample Description 2", "Sample Navigation 2", 2, false, false, 20, "54321-09876", null)]
        public void Card_Constructor_SetsPropertiesCorrectly(string title, string description, string navigation, int id, bool deleted, bool inactive, int displayOrder, string gUID, int? pageId)
        {
            SetUp();

            // Act
            var card = new Card(_image, title, description, navigation, id, deleted, inactive, displayOrder, gUID, pageId);

            // Assert
            Assert.Equal(_image, card.Image);
            Assert.Equal(title, card.Title);
            Assert.Equal(description, card.Description);
            Assert.Equal(navigation, card.Navigation);
            Assert.Equal(id, card.Id);
            Assert.Equal(deleted, card.Deleted);
            Assert.Equal(inactive, card.Inactive);
            Assert.Equal(displayOrder, card.DisplayOrder);
            Assert.Equal(gUID, card.GUID);
            Assert.Equal(UIConcrete.Card, card.UIConcreteType);
            Assert.Equal(pageId, card.PageId);

            TearDown();
        }

        private void TearDown()
        {
            _image = null;
        }
    }
}
