using UIFactory.Concreate.CSHTML.Card;

namespace UIFactory.Concreate.CSHTML.Card.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int DisplayOrder { get; set; }
    }
}
