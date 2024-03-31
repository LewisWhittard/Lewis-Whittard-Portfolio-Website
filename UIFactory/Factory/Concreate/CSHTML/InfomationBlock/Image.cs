using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.InfomationBlock.Interfaces;
using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.InfomationBlock
{
    public class Image : IImage, ICSHTML
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public UIPartial? UIPartialType { get; set; }

        private readonly Infrastructure.Models.Data.InfomationBlock.Image _image;

        public Image(Infrastructure.Models.Data.InfomationBlock.Image Image)
        {
            _image = Image;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            Id = _image.Id;
        }
    }
}