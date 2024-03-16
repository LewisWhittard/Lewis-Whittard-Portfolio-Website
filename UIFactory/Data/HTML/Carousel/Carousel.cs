using UIFactory.Data.HTML.Carousel.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.Carousel
{
    public class Carousel : ICarousel, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Image> Images { get; set; }
    }
}
