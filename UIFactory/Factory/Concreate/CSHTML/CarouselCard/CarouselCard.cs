using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces;
using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard
{
    public class CarouselCard : ICarouselCard, ICSHTML, IJsonLD
    {
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public UIPartial? UIPartialType { get; set; }

        private Infrastructure.Models.Data.CarouselCard.CarouselCard _carouselCard;

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCard)
        {
            _carouselCard = carouselCard;
            foreach (var item in _carouselCard.Cards)
            {
                Cards.Add(new Card(item));
            }
            DisplayOrder = _carouselCard.DisplayOrder;
            UIPartialType = UIPartial.CarouselCard;
        }
    }
}
