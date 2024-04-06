using SEO.Models.Alt.Interface;
using SEO.Models.JsonLD;
using UIFactory.Factory.CSHTML.Concrete.CarouselCard.Interfaces;

namespace UIFactory.Factory.CSHTML.Concrete.CarouselCard
{
    public class Card : ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public string Alt {  get; set; }
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
        }
    }
}
