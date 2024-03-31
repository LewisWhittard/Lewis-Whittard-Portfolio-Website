using UIFactory.Factory.Concreate.CSHTML.CarouselCard.Interfaces;
using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.CarouselCard
{
    public class CarouselCard : ICarouselCard, ICSHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        private Infrastructure.Models.Data.CarouselCard.CarouselCard _CarouselCard;

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCard)
        {
            _CarouselCard = carouselCard;

            Id = _CarouselCard.Id;
            foreach (var item in _CarouselCard.Cards)
            {
                Cards.Add(new Card(item));
            }
            DisplayOrder = _CarouselCard.DisplayOrder;
        }
    }
}
