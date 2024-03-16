using Infrastructure.Models.Data.Carousel;

namespace Infrastructure.Models.Interfaces.Carousel.Interfaces
{
    public interface ICarousel
    {
        public List<Image> Images { get; set; }
    }
}
