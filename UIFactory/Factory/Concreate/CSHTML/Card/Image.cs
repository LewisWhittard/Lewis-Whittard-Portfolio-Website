using UIFactory.Factory.Concreate.CSHTML.Card.Interfaces;

namespace UIFactory.Factory.Concreate.CSHTML.Card
{
    public class Image : IImage
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        private readonly Infrastructure.Models.Data.Card.Image _image;

        public Image(Infrastructure.Models.Data.Card.Image image)
        {
            _image = image;
            Source = _image.Source;
            DisplayOrder = _image.DisplayOrder;
            Id = _image.Id;
            Deleted = _image.Deleted;
            Inactive = _image.Inactive;
        }
    }
}
