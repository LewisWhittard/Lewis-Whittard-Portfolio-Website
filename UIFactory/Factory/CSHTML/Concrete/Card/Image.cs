using UIFactory.Factory.CSHTML.Concrete.Card.Interfaces;

namespace UIFactory.Factory.CSHTML.Concrete.Card
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        private readonly Infrastructure.Models.Data.Card.Image _image;

        public Image(Infrastructure.Models.Data.Card.Image image)
        {
            _image = image;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            Deleted = _image.Deleted;
            Inactive = _image.Inactive;
        }
    }
}
