using UIFactory.Concreate.CSHTML.Card.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Concreate.CSHTML.Card
{
    public class Card : ICard, IHTML
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public int DisplayOrder { get; set; }
    }
}
