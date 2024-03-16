using UIFactory.Data.HTML.Card;

namespace UIFactory.Data.HTML.Card.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
    }
}
