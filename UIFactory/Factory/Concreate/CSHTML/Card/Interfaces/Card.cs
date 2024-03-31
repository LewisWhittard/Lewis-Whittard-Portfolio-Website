using UIFactory.Factory.Concreate.CSHTML.Card;

namespace UIFactory.Factory.Concreate.CSHTML.Card.Interfaces
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
