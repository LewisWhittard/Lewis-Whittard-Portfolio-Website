using Infrastructure.Models.Data.Carousel;
using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.InfomationBlock;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;
using Infrastructure.Models.Data.Table;
using Infrastructure.Models.Data.Video;
using Infrastructure.Repository.Page.Interface;

namespace Infrastructure.Repository.Page
{
    public class MockPageRepository : IPageRepository
    {
        private List<Models.Data.Page.Page> _pages {  get; set; }

        public MockPageRepository()
        {
            // Create lists to hold the instances
            List<Card> cards = new List<Card>();
            List<Carousel> carousels = new List<Carousel>();
            List<CarouselCard> carouselCards = new List<CarouselCard>();
            List<Table> tables = new List<Table>();
            List<InfomatonBlock> infoBlocks = new List<InfomatonBlock>();
            List<Video> videos = new List<Video>();

            // Add instances to the lists
            cards.Add((new Card(null,"","","",0,false,false,0,"")));
            //cards.Add(new Card() { Id = 0, Deleted = false, Inactive = false});
            carousels.Add(new Carousel() { Id = 0, Deleted = false, Inactive = false });
            carouselCards.Add(new CarouselCard() { Id = 0, Deleted = false, Inactive = false });
            tables.Add(new Table() { Id = 0, Deleted = false, Inactive = false });
            infoBlocks.Add(new InfomatonBlock() { Id = 0, Deleted = false, Inactive = false });
            videos.Add(new Video() { Id = 0, Deleted = false, Inactive = false });

            cards.Add(new Card() { Id = 1, Deleted = false, Inactive = false });
            carousels.Add(new Carousel() { Id = 1, Deleted = false, Inactive = false });
            carouselCards.Add(new CarouselCard() { Id = 1, Deleted = false, Inactive = false });
            tables.Add(new Table() { Id = 1, Deleted = false, Inactive = false });
            infoBlocks.Add(new InfomatonBlock() { Id = 1, Deleted = false, Inactive = false });
            videos.Add(new Video() { Id = 1, Deleted = false, Inactive = false });

            _pages = new List<Models.Data.Page.Page>()
            {
                new Models.Data.Page.Page() {PageName = "First", Deleted = false, Inactive = false, Cards = cards, Carousels = carousels, CarouselCards = carouselCards, Tables = tables, Videos = videos, InfomationBlocks = infoBlocks},
                new Models.Data.Page.Page() {PageName = "Second", Deleted = false, Inactive = false},
                new Models.Data.Page.Page() {PageName = "Deleted", Deleted = true, Inactive = false},
                new Models.Data.Page.Page() {PageName = "IncludeInactive", Deleted = false, Inactive = true},
                new Models.Data.Page.Page() {PageName = "ExcludeInactive", Deleted = false, Inactive = true}
            };
            

            

        }

        public List<Models.Data.Page.Page> GetPages(string PageName)
        {
            return _pages;
        }
    }
}
