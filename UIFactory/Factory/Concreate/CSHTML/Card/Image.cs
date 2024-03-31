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

        public Image(Infrastructure.Models.Data.Card.Image image)
        {
            Source = image.Source;
            DisplayOrder = image.DisplayOrder;
            Id = image.Id;
            Deleted = image.Deleted;
            Inactive = image.Inactive;
        }
    }
}
