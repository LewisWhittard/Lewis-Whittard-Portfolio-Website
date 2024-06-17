namespace UIFactory.Factory.Concrete.Carousel
{
    public class Carousel
    {
        public Infrastructure.Models.Data.Carousel.Carousel CarouselData { get; private set; }
        public SEO.Models.JsonLD.JsonLDData JsonLDData { get; private set; }

        private readonly Infrastructure.Models.Data.Carousel.Carousel _carouselData;
        private readonly SEO.Services.JsonLDService _jsonLDService;

    }
}
