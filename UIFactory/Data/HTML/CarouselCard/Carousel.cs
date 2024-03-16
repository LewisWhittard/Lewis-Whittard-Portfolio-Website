using UIFactory.Data.HTML.CarouselCard.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.CarouselCard
{
    public class Carousel : ICarousel, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Card> Cards { get; set; }
    }
}
