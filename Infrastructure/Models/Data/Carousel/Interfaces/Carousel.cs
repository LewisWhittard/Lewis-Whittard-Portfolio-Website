namespace Infrastructure.Models.Data.Carousel.Interfaces
{
    public interface ICarousel
    {
        List<Shared.Image.Image> Images { get; }
        int PageId { get; }

    }
}
