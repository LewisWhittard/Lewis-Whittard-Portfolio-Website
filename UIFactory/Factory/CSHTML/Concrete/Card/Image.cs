using SEO.Models.Alt.Interface;
using UIFactory.Factory.CSHTML.Concrete.Card.Interfaces;

namespace UIFactory.Factory.CSHTML.Concrete.Card
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        private readonly Infrastructure.Models.Data.Card.Image _image;
        private readonly IAltData _altData;
        public string Alt {  get; set; }

        public Image(Infrastructure.Models.Data.Card.Image image, IAltData altData)
        {
            _image = image;
            _altData = altData;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            Alt = _altData.Value;
        }
    }
}
