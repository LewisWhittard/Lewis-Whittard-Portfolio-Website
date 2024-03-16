using UIFactory.Data.HTML.Card.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.Card
{
    public class Card : ICard, IHTML
    {
        public Image Image { get; set; }
        public Paragraph Paragraph { get; set; }
        public Navigation Navigation { get; set; }
        public int Id { get; set; }
        public string? ItemProp { get; set; }
        public string? ItemScopeItemType { get; set; }
    }
}
