using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Shared.Card;

namespace InfrastructureTests.Ctor
{
    public class CardTests
    {
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
    }
}
