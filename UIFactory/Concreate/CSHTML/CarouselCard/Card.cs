using UIFactory.Concreate.CSHTML.CarouselCard.Interfaces;

namespace UIFactory.Concreate.CSHTML.CarouselCard
{
    public class Card : ICard
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int Id { get; set; }

        public Card(Infrastructure.Models.Data.CarouselCard.Card card)
        {
            Image = new Image(card.Image);
            Paragraph = new Paragraph(card.Paragraph);
            Navigation = new Navigation(card.Navigation);
            Id = card.Id;
        }
    }
}
