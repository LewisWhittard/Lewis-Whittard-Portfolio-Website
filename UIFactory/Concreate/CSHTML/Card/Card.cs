using UIFactory.Concreate.CSHTML.Card.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.Card
{
    public class Card : ICard, ICSHTML
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        private readonly Infrastructure.Models.Data.Card.Card _card;

        public Card(Infrastructure.Models.Data.Card.Card card)
        {
            _card = card;
            Image = new Image(_card.Image);
            Paragraph = new Paragraph(_card.Paragraph);
            Navigation = new Navigation(_card.Navigation);
            Id = _card.Id;
            DisplayOrder = _card.DisplayOrder;
        }
    }
}
