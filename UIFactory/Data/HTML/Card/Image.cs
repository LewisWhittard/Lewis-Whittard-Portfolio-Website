using UIFactory.Data.HTML.Card.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.Card
{
    public class Image : IImage, IHTML
    {
        public string Source { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public string? ItemProp { get; set; }
        public string? ItemScopeItemType { get; set; }
    }
}
