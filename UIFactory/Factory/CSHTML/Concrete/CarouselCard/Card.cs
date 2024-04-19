using SEO.Models.Alt.Interface;
using UIFactory.Factory.CSHTML.Concrete.CarouselCard.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.CarouselCard
{
    public class Card : ICard, IUI
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public string Alt { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }
        public int? DisplayOrder { get; set; }

        private readonly Infrastructure.Models.Data.CarouselCard.Card _card;
        private readonly IAltData _alt;

        public Card(Infrastructure.Models.Data.CarouselCard.Card card, IAltData alt)
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