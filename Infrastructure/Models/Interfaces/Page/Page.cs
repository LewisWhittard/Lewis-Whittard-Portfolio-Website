

namespace Infrastructure.Models.Interfaces.Page
{
    public interface IPage
    {
        public string Webpage { get; set; }
        public List<Data.Card.Card> Cards { get; set; }
        public List<Data.Carousel.Carousel> Carousels { get; set; }
        public List<Data.CarouselCard.CarouselCard> CarouselCards { get; set; }
        public List<Data.InfomationBlock.InfomatonBlock> InfomationBlocks { get; set; }
        public List<Data.Table.Table> Tables { get; set; }
    }
}
