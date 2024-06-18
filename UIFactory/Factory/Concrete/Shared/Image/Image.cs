using SEO.Service.AltService;
using SEO.Service.JsonLDService;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Concrete.Shared.Image.Interface;

namespace UIFactory.Factory.Concrete.Shared.Image
{
    public class Image : IImage, IConcreteUI
    {
        public Infrastructure.Models.Data.Shared.Image.Image ImageData { get; private set; }
        public SEO.Model.Alt.AltData? AltData { get; private set; }
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDs { get; private set; }

        private readonly Infrastructure.Models.Data.Shared.Image.Image _imageData;
        private readonly AltService? _altService;
        private readonly JsonLDService? _jsonLDService;


        public Image(Infrastructure.Models.Data.Shared.Image.Image imageData, AltService? altService, JsonLDService? jsonLDService)
        {
            _imageData = imageData;
            ImageData = _imageData;
            _altService = altService;
            _jsonLDService = jsonLDService;
            SetAltData();
            SetJsonLDData();
        }

        private void SetAltData()
        {
            if (_altService != null)
            {
                AltData = _altService.GetBySuperClassGUID(ImageData.GUID, false);
            }
            else
            {
                AltData = null;
            }
        }


        private void SetJsonLDData()
        {
            if (_jsonLDService != null)
            {
                JsonLDs = _jsonLDService.GetBySuperClassGUID(ImageData.GUID, false);
            }
            else
            {
                JsonLDs = null;
            }
        }
    }
}
