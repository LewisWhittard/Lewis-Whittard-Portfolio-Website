using UIFactory.Concreate.CSHTML.Carousel;

namespace UIFactory.Concreate.CSHTML.Carousel.Interfaces
{
    public interface ICarousel
    {
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
    }
}
