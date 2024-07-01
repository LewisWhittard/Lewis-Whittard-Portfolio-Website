using Infrastructure.Models.Data.Interface;
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
        public List<SEO.Model.JsonLD.JsonLDData>? JsonLDDatas { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }


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
            DisplayOrder = _imageData.DisplayOrder;
            UIConcreteType = (UIConcrete)_imageData.UIConcreteType;
        }

        private void SetAltData()
        {
            if (_altService != null)
            {
                AltData = _altService.GetByUIId(ImageData.UIId, false);
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
                JsonLDDatas = _jsonLDService.GetByUIId(ImageData.UIId, false);
            }
            else
            {
                JsonLDDatas = null;
            }
        }
    }
}
