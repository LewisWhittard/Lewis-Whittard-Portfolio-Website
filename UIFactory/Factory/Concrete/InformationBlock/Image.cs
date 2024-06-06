using SEO.Models.Alt.Interface;
using UIFactory.Factory.Concrete.InformationBlock.Interfaces;
using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class Image : IImage, ICSHTML, IUI
    {
        public string Source { get; private set; }
        public int? DisplayOrder { get; private set; }
        public UI? UIType { get; private set; }
        public string Alt { get; private set; }
        private readonly Infrastructure.Models.Data.Shared.Image.Image _image;
        private readonly IAltData _alt;
        public string GUID { get; private set; }

        public Image(Infrastructure.Models.Data.Shared.Image.Image Image, IAltData alt)
        {
            _image = Image;
            GUID = _image.GUID;
            _alt = alt;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            Alt = _alt.Value;

        }
    }
}