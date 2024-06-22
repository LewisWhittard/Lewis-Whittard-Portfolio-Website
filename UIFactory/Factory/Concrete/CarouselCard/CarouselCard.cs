using Infrastructure.Models.Data.Interface;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.CarouselCard.Interface;
using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Concrete.CarouselCard
{
    public class CarouselCard : ICarouselCard, IConcreteUI
    {
        public Infrastructure.Models.Data.CarouselCard.CarouselCard CarouselCardData { get; private set; }
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDData { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

        private readonly Infrastructure.Models.Data.CarouselCard.CarouselCard _carouselCardDatas;
        private readonly JsonLDService? _jsonLDService;

        public CarouselCard(Infrastructure.Models.Data.CarouselCard.CarouselCard carouselCardDatas, JsonLDService? jsonLDService)
        {
            _carouselCardDatas = carouselCardDatas;
            _jsonLDService = jsonLDService;
            SetJsonLD();
            DisplayOrder = (int)_carouselCardDatas.DisplayOrder;
            UIConcreteType = (UIConcrete)_carouselCardDatas.UIConcreteType;
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
