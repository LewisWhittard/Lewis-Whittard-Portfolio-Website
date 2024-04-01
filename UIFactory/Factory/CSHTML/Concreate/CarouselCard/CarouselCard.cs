using UIFactory.Factory.CSHTML.Concreate.CarouselCard.Interfaces;
using UIFactory.Factory.CSHTML.Concreate.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concreate.CarouselCard
{
    public class CarouselCard : ICarouselCard, ICSHTML, IJsonLD, IUI
    {
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UI? UIType { get; set; }

        private Infrastructure.Models.Data.CarouselCard.CarouselCard _carouselCard;

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCard)
        {
            _carouselCard = carouselCard;
            foreach (var item in _carouselCard.Cards)
            {
                Cards.Add(new Card(item));
            }
            DisplayOrder = _carouselCard.DisplayOrder;
            UIType = UI.CarouselCard;
        }
    }
}
