using UIFactory.Concreate.CSHTML.CarouselCard.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.CarouselCard
{
    public class CarouselCard : ICarouselCard, IHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard card)
        {
            Id = card.Id;
            foreach (var item in card.Cards) 
            {
                Cards.Add(new Card(item));
            }
            DisplayOrder = card.DisplayOrder;
        }
    }
}
