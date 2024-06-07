using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Shared.Image.Interface;

namespace UIFactory.Factory.Concrete.Shared.Image
{
    public class Image : IImage, IConcreteUI
    {
        public Infrastructure.Models.Data.Shared.Image.Image ImageData { get; private set; }
        public SEO.Models.Alt.AltData? AltData { get; private set; }
        public List<SEO.Models.JsonLD.JsonLDData>? TitleData { get; private set; }
        public UIConcrete UIConcrete { get; private set; }

        private readonly Infrastructure.Models.Data.Shared.Image.Image _imageData;
        private readonly SEO.Service.AltService.AltService? _altService;
        private readonly SEO.Service.JsonLDService.JsonLDService? _jsonLDService;


        public Image(Infrastructure.Models.Data.Shared.Image.Image imageData, SEO.Service.AltService.AltService? altService, SEO.Service.JsonLDService.JsonLDService? jsonLDService)
        {
            _imageData = imageData;
            ImageData = _imageData;
            UIConcrete = UIConcrete.Image;
            if (altService != null)
            {
                _altService = altService;
                SetAltData();
            }
            if (jsonLDService != null)
            {
                _jsonLDService = jsonLDService;
                SetJsonLDData();
            }
        }

        private void SetAltData()
        {
            AltData = _altService.GetBySuperClassGUID(ImageData.GUID, false);
        }


        private void SetJsonLDData()
        {
            TitleData = _jsonLDService.GetBySuperClassGUID(ImageData.GUID, false);
        }
    }
}
