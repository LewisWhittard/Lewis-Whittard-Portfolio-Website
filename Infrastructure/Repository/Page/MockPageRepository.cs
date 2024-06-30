using Infrastructure.Models.Data.Carousel;
using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.Head;
using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Table;
using Infrastructure.Models.Data.Video;
using Infrastructure.Repository.Page.Interface;

namespace Infrastructure.Repository.Page
{
    public class MockPageRepository : IPageRepository
    {
        private List<Models.Data.Page.Page> _pages;

        public MockPageRepository()
        {
            List<Card> cards = new List<Card>()
            {
                new Card(),
                new Card()
            };

            List<Carousel> carousels = new List<Carousel>()
            {
                new Carousel(),
                new Carousel()
            };

            List<CarouselCard> carouselCards = new List<CarouselCard>()
            {
                new CarouselCard(),
                new CarouselCard()
            };

            List<InfomatonBlock> informationBlocks = new List<InfomatonBlock>()
            {
                new InfomatonBlock(),
                new InfomatonBlock()
            };

            List<Table> tables = new List<Table>()
            {
                new Table(),
                new Table()
            };

            List<Video> videos = new List<Video>()
            {
                new Video(),
                new Video()
            };

            Head head = new Head();

            _pages = new List<Models.Data.Page.Page>();
            _pages.Add(new Models.Data.Page.Page("First", cards,head, carousels, carouselCards, informationBlocks, tables, videos, "FirstUIID", 0, false, false));
            _pages.Add(new Models.Data.Page.Page("Second", null, null , null, null, null, null, null, "SecondUIID", 0, false, false));
            _pages.Add(new Models.Data.Page.Page("Deleted", null,null, null, null, null, null, null, "DeletedUIID", 0, true, false));
            _pages.Add(new Models.Data.Page.Page("IncludeInactive",null, null, null, null, null, null, null, "IncludeInactiveUIID", 0, false, true));
            _pages.Add(new Models.Data.Page.Page("ExcludeInactive", null, null, null, null, null, null, null, "ExcludeInactiveUIID", 0, true, false));
        }

        public List<Models.Data.Page.Page> GetPages(string PageName)
        {
            return _pages;
        }
    }
}
