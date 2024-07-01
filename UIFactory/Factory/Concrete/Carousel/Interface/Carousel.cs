namespace UIFactory.Factory.Concrete.Carousel.Interface
{
    public interface ICarousel
    {
        Infrastructure.Models.Data.Carousel.Carousel CarouselData { get; }
        List<SEO.Model.JsonLD.JsonLDData>? JsonLDDatas { get; }
        List<Shared.Image.Image> Images { get; }
    }
}
