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

        public Card(Infrastructure.Models.Data.CarouselCard.Card card)
        {
            Image = new Image(card.Image);
            Title = card.Title;
            Description = card.Description;
            Navigation = card.Navigation;
            Id = card.Id;
        }
    }
}
