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
        private readonly Infrastructure.Models.Data.CarouselCard.Card _card;

        public Card(Infrastructure.Models.Data.CarouselCard.Card card)
        {
            _card = card;
            Image = new Image(_card.Image);
            Title = _card.Title;
            Description = _card.Description;
            Navigation = _card.Navigation;
            Id = _card.Id;
        }
    }
}
