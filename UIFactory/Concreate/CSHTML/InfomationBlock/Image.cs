using UIFactory.Concreate.CSHTML.InfomationBlock.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.InfomationBlock
{
    public class Image : IImage, ICSHTML
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
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