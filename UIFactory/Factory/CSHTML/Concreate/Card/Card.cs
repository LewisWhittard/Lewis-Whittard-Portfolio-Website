using UIFactory.Factory.CSHTML.Concreate.Card.Interfaces;
using UIFactory.Factory.CSHTML.Concreate.Interface;

namespace UIFactory.Factory.CSHTML.Concreate.Card
{
    public class Card : ICard, ICSHTML
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int DisplayOrder { get; set; }
        public UIPartial? UIPartialType { get; set; }
        private readonly Infrastructure.Models.Data.Card.Card _card;

        public Card(Infrastructure.Models.Data.Card.Card card)
        {
            _card = card;
            Image = new Image(_card.Image);
            Title = _card.Title;
            Description = _card.Description;
            Navigation = _card.Navigation;
            DisplayOrder = _card.DisplayOrder;
            UIPartialType = UIPartial.Card;
        }
    }
}
