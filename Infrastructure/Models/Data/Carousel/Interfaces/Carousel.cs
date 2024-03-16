namespace Infrastructure.Models.Data.Carousel.Interfaces
{
    public interface ICarousel
    {
        public List<Image> Images { get; set; }
        public int DisplayOrder { get; set; }
    }
}
