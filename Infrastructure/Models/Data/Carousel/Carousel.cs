using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Interfaces.Carousel.Interfaces;

namespace Infrastructure.Models.Data.Carousel
{
    public class Carousel : ICarousel, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Image> Images { get; set; }
    }
}
