using UIFactory.Data.HTML.CarouselCard.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.CarouselCard
{
    public class CarouselCard : ICarouselCard, IHTML,IJsonLD
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Card> Cards { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
    }
}
