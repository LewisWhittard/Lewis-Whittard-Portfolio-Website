using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.Page.Interface
{
    public interface IPage
    {
        public string PageName { get; set; }
        public List<Card.Card>? Cards { get; set; }
        public List<Carousel.Carousel>? Carousels { get; set; }
        public List<CarouselCard.CarouselCard>? CarouselCards { get; set; }
        public List<InfomationBlock.InfomatonBlock>? InfomationBlocks { get; set; }
        public List<Table.Table>? Tables { get; set; }
        public List<IData> CreateIDataList();
    }
}
