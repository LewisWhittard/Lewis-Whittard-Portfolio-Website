using UIFactory.Concreate.CSHTML.Card.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.Card
{
    public class Card : ICard, IHTML
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int Id { get; set; }
        public int DisplayOrder { get; set; }

        public Card()
        {
            
        }

        public Card(Infrastructure.Models.Data.Card.Card card)
        {
            Image = new Image(card.Image);
            Paragraph = new Paragraph(card.Paragraph);
            Navigation = new Navigation(card.Navigation);
            Id = card.Id;
            DisplayOrder = card.DisplayOrder;

        }
    }
}
