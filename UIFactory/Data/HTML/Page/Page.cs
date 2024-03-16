using UIFactory.Data.HTML.InfomationBlock;
using UIFactory.Data.HTML.Interface;
using UIFactory.Data.HTML.Page.Interface;

namespace UIFactory.Data.HTML.Page
{
    public class Page : IPage, IData
    {
        public string Webpage { get; set; }
        public List<Card.Card> Cards { get; set; }
        public List<Carousel.Carousel> Carousels { get; set; }
        public List<CarouselCard.Card> CarouselCards { get; set; }
        public List<InfomatonBlock> InfomationBlocks { get; set; }
        public List<Table.Table> Tables { get; set; }
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
    }
}
