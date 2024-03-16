using UIFactory.Data.HTML.Carousel.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.Carousel
{
    public class Carousel : ICarousel, IHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
    }
}
