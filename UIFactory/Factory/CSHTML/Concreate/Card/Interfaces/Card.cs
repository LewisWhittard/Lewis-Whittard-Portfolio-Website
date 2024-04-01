using UIFactory.Factory.CSHTML.Concreate.Card;

namespace UIFactory.Factory.CSHTML.Concreate.Card.Interfaces
{
    public interface ICard
    {
        public Image Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Navigation { get; set; }
        public int DisplayOrder { get; set; }
    }
}
