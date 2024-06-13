using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.CarouselCard.Interface;

namespace UIFactory.Factory.Concrete.CarouselCard
{
    public class CarouselCard : ICarouselCard
    {
        public Infrastructure.Models.Data.CarouselCard.CarouselCard CarouselCardDatas { get; private set; }
        public List<SEO.Models.JsonLD.JsonLDData> JsonLDData { get; private set; }

        private readonly CarouselCard _carouselCardDatas;
        private readonly JsonLDService _jsonLDService;

        public CarouselCard(CarouselCard carouselCardDatas, JsonLDService jsonLDService)
        {
            _carouselCardDatas = carouselCardDatas;
            _jsonLDService = jsonLDService;
            CarouselCardDatas = _carouselCardDatas;
        }


    }
}
