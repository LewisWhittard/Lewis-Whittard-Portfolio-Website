using UIFactory.Factory.CSHTML.Concrete.Carousel;

namespace UIFactory.Factory.CSHTML.Concrete.Carousel.Interfaces
{
    public interface ICarousel
    {
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
    }
}
