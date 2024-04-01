using UIFactory.Factory.CSHTML.Concreate.Carousel;

namespace UIFactory.Factory.CSHTML.Concreate.Carousel.Interfaces
{
    public interface ICarousel
    {
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
    }
}
