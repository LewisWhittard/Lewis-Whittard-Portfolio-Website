using UIFactory.Concreate.CSHTML.Carousel.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.Carousel
{
    public class Carousel : ICarousel, IHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
    }
}
