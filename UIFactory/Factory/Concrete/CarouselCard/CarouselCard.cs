using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.CarouselCard.Interface;

namespace UIFactory.Factory.Concrete.CarouselCard
{
    public class CarouselCard : ICarouselCard
    {
        public Infrastructure.Models.Data.CarouselCard.CarouselCard CarouselCardData { get; private set; }
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDData { get; private set; }

        private readonly Infrastructure.Models.Data.CarouselCard.CarouselCard _carouselCardDatas;
        private readonly JsonLDService? _jsonLDService;

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCardDatas, JsonLDService? jsonLDService)
        {
            _carouselCardDatas = carouselCardDatas;
            _jsonLDService = jsonLDService;
            SetJsonLD();
        }

        public void SetJsonLD()
        {
            if (CarouselCardData != null)
            {
                JsonLDData = _jsonLDService.GetBySuperClassGUID(CarouselCardData.GUID, false);
            }
            else
            {
                JsonLDData = null;
            }
        }


    }
}
