using UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard
{
    public class Card : ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int Id { get; set; }
        private readonly Infrastructure.Models.Data.CarouselCard.Card _Card;

        public Card(Infrastructure.Models.Data.CarouselCard.Card card)
        {
            _Card = card;
            Image = new Image(_Card.Image);
            Title = _Card.Title;
            Description = _Card.Description;
            Navigation = _Card.Navigation;
            Id = _Card.Id;
        }
    }
}
