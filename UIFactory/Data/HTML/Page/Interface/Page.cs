using UIFactory.Data.HTML.InfomationBlock;

namespace UIFactory.Data.HTML.Page.Interface
{
    public interface IPage
    {
        public string Webpage { get; set; }
        public List<Card.Card> Cards { get; set; }
        public List<Carousel.Carousel> Carousels { get; set; }
        public List<CarouselCard.Card> CarouselCards { get; set; }
        public List<InfomatonBlock> InfomationBlocks { get; set; }
        public List<Table.Table> Tables { get; set; }
    }
}
