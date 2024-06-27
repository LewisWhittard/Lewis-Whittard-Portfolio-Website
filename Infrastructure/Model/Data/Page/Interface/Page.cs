using Infrastructure.Models.Data.Interface;

namespace Infrastructure.Models.Data.Page.Interface
{
    public interface IPage
    {
        string PageName { get; }
        public Head.Head Head { get; }
        List<Shared.Card.Card>? Cards { get; }
        List<Carousel.Carousel>? Carousels { get; }
        List<CarouselCard.CarouselCard>? CarouselCards { get; }
        List<InformationBlock.InfomatonBlock>? InformationBlocks { get; }
        List<Table.Table>? Tables { get; }
        List<IData> CreateIDataList();
    }
}
