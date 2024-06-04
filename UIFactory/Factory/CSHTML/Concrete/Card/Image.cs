using SEO.Models.Alt.Interface;
using UIFactory.Factory.CSHTML.Concrete.Card.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.Card
{
    public class Image : IImage , IUI
    {
        public string Source { get; private set; }
        public int? DisplayOrder { get; private set; }
        private readonly Infrastructure.Models.Data.Shared.Image.Image _image;
        private readonly IAltData _altData;
        public string Alt {  get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

        public Image(Infrastructure.Models.Data.Shared.Image.Image image, IAltData altData)
        {
            _image = image;
            _altData = altData;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            Alt = _altData.Value;
            GUID = _image.GUID;
        }
    }
}
