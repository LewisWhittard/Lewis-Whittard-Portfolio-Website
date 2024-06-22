using UIFactory.Factory.Concrete.Carousel.Interface;
using SEO.Service.AltService;
using UIFactory.Factory.Concrete.Interface;
using Infrastructure.Models.Data.Interface;

namespace UIFactory.Factory.Concrete.Carousel
{
    public class Carousel : ICarousel, IConcreteUI
    {
        public Infrastructure.Models.Data.Carousel.Carousel CarouselData { get; private set; }
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDDatas { get; private set; }
        public List<Shared.Image.Image> Images { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

        private readonly Infrastructure.Models.Data.Carousel.Carousel _carouselData;
        private readonly SEO.Service.JsonLDService.JsonLDService? _jsonLDService;
        private readonly AltService? _altService;
        
        public Carousel(Infrastructure.Models.Data.Carousel.Carousel carouselData, SEO.Service.JsonLDService.JsonLDService? jsonLDService, AltService? altService)
        {
            _carouselData = carouselData;
            _jsonLDService = jsonLDService;
            _altService = altService;
            CarouselData = _carouselData;
            SetJsonLD();
            SetImages();
            DisplayOrder = (int)_carouselData.DisplayOrder;
            UIConcreteType = (UIConcrete)_carouselData.UIConcreteType;
        }

        private void SetJsonLD()
        {
            if (_jsonLDService != null)
            {
                JsonLDDatas = _jsonLDService.GetBySuperClassGUID(_carouselData.GUID, false);
            }
            else
            {
                JsonLDDatas = null;
            }
        }

        private void SetImages()
        {
            foreach (var item in CarouselData.Images)
            {
                Images.Add(new Shared.Image.Image(item,_altService,_jsonLDService));
            }
        }

    }
}
