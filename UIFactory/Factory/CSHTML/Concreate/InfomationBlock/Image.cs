using UIFactory.Factory.CSHTML.Concreate.InfomationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concreate.Interface;

namespace UIFactory.Factory.CSHTML.Concreate.InfomationBlock
{
    public class Image : IImage, ICSHTML
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public UI? UIType { get; set; }

        private readonly Infrastructure.Models.Data.InfomationBlock.Image _image;

        public Image(Infrastructure.Models.Data.InfomationBlock.Image Image)
        {
            _image = Image;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
        }
    }
}