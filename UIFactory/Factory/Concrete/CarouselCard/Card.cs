using SEO.Models.Alt.Interface;
using UIFactory.Factory.Concrete.CarouselCard.Interfaces;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.Concrete.CarouselCard
{
    public class Card : ICard, IUI
    {
        public Image Image { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Navigation { get; private set; }
        public string Alt { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }
        public int? DisplayOrder { get; private set; }

        private readonly Infrastructure.Models.Data.Shared.Card.Card _card;
        private readonly IAltData _alt;

        public Card(Infrastructure.Models.Data.Shared.Card.Card card, IAltData alt)
        {
            _card = card;
            _alt = alt;
            Image = new Image(_card.Image);
            Title = _card.Title;
            Description = _card.Description;
            Navigation = _card.Navigation;
            GUID = _card.GUID;
            Alt = _alt.Value;
        }

        public Card()
        {
            Image = new Image();
            Title = "";
            Description = "";
            Navigation = "";
            Alt = "";
        }
    }
}