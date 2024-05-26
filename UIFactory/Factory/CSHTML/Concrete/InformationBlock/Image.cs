using SEO.Models.Alt.Interface;
using UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock
{
    public class Image : IImage, ICSHTML, IUI
    {
        public string Source { get; set; }
        public int? DisplayOrder { get; set; }
        public UI? UIType { get; set; }
        public string Alt { get; set; } 
        private readonly Infrastructure.Models.Data.Shared.Image.Image _image;
        private readonly IAltData _alt;
        public string GUID { get; set; }

        public Image(Infrastructure.Models.Data.Shared.Image.Image Image,IAltData alt)
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