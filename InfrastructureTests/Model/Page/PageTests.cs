using Infrastructure.Models.Data.Carousel;
using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.Head;
using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Page;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;
using Infrastructure.Models.Data.Table;
using Infrastructure.Models.Data.Video;

namespace InfrastructureTests.Model
{
    public class PageTests
    {
        private List<Card> _cards { get; set; }
        private List<Carousel> _carousels { get; set; }
        private List<CarouselCard> _carouselCards { get; set; }
        private List<InfomatonBlock> _informationBlocks { get; set; }
        private List<Table> _tables { get; set; }
        private List<Video> _video { get; set; }
        private Head _head { get; set; }



        public void SetUp()
        {
            _cards = new List<Card>();
            _carousels = new List<Carousel>();
            _carouselCards = new List<CarouselCard>();
            _informationBlocks = new List<InfomatonBlock>();
            _tables = new List<Table>();

            List<Image> imagesCards = new List<Image>
                {
                    new Image("Image0Source", null, 0, false, false, "Image0UIId", 0,null,null),
                    new Image("Image1Source", null, 1, false, false, "Image1UIId", 1, null, null)
                };

            _cards.Add(new Card(imagesCards[0], "Card0Title", "Card0Description", "Card0Navigation", 0, false, false, 0, "Card0UIId", 1, null));
            _cards.Add(new Card(imagesCards[1], "Card1Title", "Card1Description", "Card1Navigation", 1, false, false, 1, "Card1UIId", 1, null));

            List<Image> imagesCarousel0 = new List<Image>
            {
                new Image("Image0Source", 0, 2, false, false, "Image0UIId", null,null, 0),
                new Image("Image1Source", 1, 3, false, false, "Image1UIId", null, null,0)
            };

            List<Image> imagesCarousel1 = new List<Image>
            {
                new Image("Image2Source", 1, 2, false, false, "Image2UIId", null, null,1),
                new Image("Image3Source", 2, 3, false, false, "Image3UIId", null, null,1)
            };

            _carousels.Add(new Carousel(0, false, false, imagesCarousel0, 2, "Carousel0UIId", 1));
            _carousels.Add(new Carousel(1, false, false, imagesCarousel1, 3, "Carousel1UIId", 1));

            _carouselCards.Add(new CarouselCard(0,false,false,_cards,4, "carouselCards0UIId",1));
            _carouselCards.Add(new CarouselCard(1, false, false, _cards, 5, "carouselCards1UIId", 1));

            List<Paragraph> paragraphs1 = new List<Paragraph>
            {
                new Paragraph("Paragraph0Text", 0, 0, false, false, 0,"Paragraph0UIId"),
                new Paragraph("Paragraph1Text", 1, 1, false, false, 0,"Paragraph1UIId"),
            };

            List<Paragraph> paragraphs2 = new List<Paragraph>
            {
                new Paragraph("Paragraph2Text", 0, 2, false, false, 1,"Paragraph2UIId"),
                new Paragraph("Paragraph3Text", 1, 3, false, false, 1,"Paragraph3UIId"),
            };

            List<Heading> headings1 = new List<Heading>
            {
                new Heading(0,false,false,"Heading0Text",2,1,"Heading0UIId",0),
                new Heading(1,false,false,"Heading1Text",3,1,"Heading1UIId",1)
            };

            List<Heading> headings2 = new List<Heading>
            {
                new Heading(2,false,false,"Heading2Text",4,2,"Heading2UIId",0),
                new Heading(3,false,false,"Heading3Text",5,2,"Heading3UIId",1)
            };

            List<Image> imagesInformationBlock0 = new List<Image>
            {
                new Image("Image4Source", 6, 4, false, false, "Image4UIId", null,null, 0),
                new Image("image5Source", 7, 5, false, false, "Image5UIId", null, null,0)
            };

            List<Image> imagesInformationBlock1 = new List<Image>
            {
                new Image("Image6Source", 8, 6, false, false, "Image6UIId", null,null, 0),
                new Image("image7Source", 9, 7, false, false, "Image7UIId", null, null,0)
            };

            _informationBlocks.Add(new InfomatonBlock(0,false,false, imagesInformationBlock0, paragraphs1,headings1,6,"InfomationBlock0UIId",1));
            _informationBlocks.Add(new InfomatonBlock(0, false, false, imagesInformationBlock1, paragraphs1, headings1, 6, "InfomationBlock0UIId", 1));

            _informationBlocks = new List<InfomatonBlock>
            {
                new InfomatonBlock(0,false,false, imagesInformationBlock0, paragraphs1,headings1,6,"InfomationBlock0UIId",1),
                new InfomatonBlock(0, false, false, imagesInformationBlock1, paragraphs1, headings1, 7, "InfomationBlock0UIId", 1)
            };

            List<Header> Headers0 = new List<Header>
            {
                new Header(0, false, false, 0, 0, "Header0Value", "Header0UIId"),
                new Header(1, false, false, 1, 0, "Header1Value", "Header1UIId")
            };

            List<List<Column>> columns0 = new List<List<Column>>()
            {
                new List<Column>
                {
                    new Column(0,false,false,"ValueColumn0",0,0,"UIIdColumn0",0),
                    new Column(1,false,false,"ValueColumn1",1,0,"UIIdColumn1",0)
                },
                new List<Column>
                {
                    new Column(2,false,false,"ValueColumn2",0,0,"UIIdColumn2",1),
                    new Column(3,false,false,"ValueColumn3",1,0,"UIIdColumn3",1)
                }
            };

            List<Header> Headers1 = new List<Header>
            {
                new Header(5, false, false, 0, 1, "Header5Value", "Header5UIId"),
                new Header(6, false, false, 1, 1, "Header6Value", "Header6UIId")
            };

            List<List<Column>> columns1 = new List<List<Column>>()
            {
                new List<Column>
                {
                    new Column(4,false,false,"ValueColumn4",0,1,"UIIdColumn4",0),
                    new Column(5,false,false,"ValueColumn5",1,1,"UIIdColumn5",0)
                },
                new List<Column>
                {
                    new Column(6,false,false,"ValueColumn6",0,1,"UIIdColumn6",1),
                    new Column(7,false,false,"ValueColumn7",1,1,"UIIdColumn7",1)
                }
            };

            _tables = new List<Table>
            {
                new Table(0,false,false,8,Headers0,columns0,"uIIdTable0","Table0Title",0),
                new Table(1, false, false, 9, Headers1, columns1, "uIIdTable1", "Table1Title", 1)
            };

            _video = new List<Video>
            {
                new Video("SourceVideo0","TitleVideo0","DescriptionVideo0","NavigationVideo0",0,false,false,10,"UIIdVideo0",0),
                new Video("SourceVideo1","TitleVideo1","DescriptionVideo1","NavigationVideo1",1,false,false,11,"UIIdVideo1",1)

            };


        }
        

        [Fact]
        public void Page_Constructor_NoParameters()
        {
            //arrange, act
            Page page = new Page();

            //assert
            Assert.Null(page.PageName);
            Assert.Null(page.Cards);
            Assert.Null(page.Carousels);
            Assert.Null(page.CarouselCards);
            Assert.Null(page.InformationBlocks);
            Assert.Null(page.Tables);
            Assert.Null(page.Videos);
            Assert.Null(page.UIId);
            Assert.Equal(0, page.Id);
            Assert.False(page.Deleted);
            Assert.False(page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Null(page.Head);
        }

        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        [InlineData("PageName1", "UIId1", 2, true, false)]
        [InlineData("PageName2", "UIId2", 3, false, true)]
        [InlineData("PageName3", "UIId3", 4, true, true)]
        public void Page_Constructor_WithParameters(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, _cards, _head, _carousels, _carouselCards, _informationBlocks, _tables, _video, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(_cards,page.Cards);
            Assert.Equal(_carousels, page.Carousels);
            Assert.Equal(_carouselCards, page.CarouselCards);
            Assert.Equal(_informationBlocks, page.InformationBlocks);
            Assert.Equal(_tables, page.Tables);
            Assert.Equal(_video, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Equal(_head, page.Head);

            TearDown();
        }

        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        public void Page_Constructor_WithParametersAllowNullCards(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, null, _head, _carousels, _carouselCards, _informationBlocks, _tables, _video, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(null, page.Cards);
            Assert.Equal(_carousels, page.Carousels);
            Assert.Equal(_carouselCards, page.CarouselCards);
            Assert.Equal(_informationBlocks, page.InformationBlocks);
            Assert.Equal(_tables, page.Tables);
            Assert.Equal(_video, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Equal(_head, page.Head);

            TearDown();
        }

        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        public void Page_Constructor_WithParametersAllowNullCarousels(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, _cards, _head, null, _carouselCards, _informationBlocks, _tables, _video, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(_cards, page.Cards);
            Assert.Equal(null, page.Carousels);
            Assert.Equal(_carouselCards, page.CarouselCards);
            Assert.Equal(_informationBlocks, page.InformationBlocks);
            Assert.Equal(_tables, page.Tables);
            Assert.Equal(_video, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Equal(_head, page.Head);

            TearDown();
        }

        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        public void Page_Constructor_WithParametersAllowNullCarouselCards(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, _cards, _head, _carousels, null, _informationBlocks, _tables, _video, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(_cards, page.Cards);
            Assert.Equal(_carousels, page.Carousels);
            Assert.Equal(null, page.CarouselCards);
            Assert.Equal(_informationBlocks, page.InformationBlocks);
            Assert.Equal(_tables, page.Tables);
            Assert.Equal(_video, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Equal(_head, page.Head);

            TearDown();
        }

        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        public void Page_Constructor_WithParametersAllowNullInformationBlocks(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, _cards, _head, _carousels, _carouselCards, null, _tables, _video, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(_cards, page.Cards);
            Assert.Equal(_carousels, page.Carousels);
            Assert.Equal(_carouselCards, page.CarouselCards);
            Assert.Equal(null, page.InformationBlocks);
            Assert.Equal(_tables, page.Tables);
            Assert.Equal(_video, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Equal(_head, page.Head);

            TearDown();
        }

        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        public void Page_Constructor_WithParametersAllowNullTables(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, _cards, _head, _carousels, _carouselCards, _informationBlocks, null, _video, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(_cards, page.Cards);
            Assert.Equal(_carousels, page.Carousels);
            Assert.Equal(_carouselCards, page.CarouselCards);
            Assert.Equal(_informationBlocks, page.InformationBlocks);
            Assert.Equal(null, page.Tables);
            Assert.Equal(_video, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Equal(_head, page.Head);

            TearDown();
        }

        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        public void Page_Constructor_WithParametersAllowNullVideos(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, _cards, _head, _carousels, _carouselCards, _informationBlocks, _tables, null, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(_cards, page.Cards);
            Assert.Equal(_carousels, page.Carousels);
            Assert.Equal(_carouselCards, page.CarouselCards);
            Assert.Equal(_informationBlocks, page.InformationBlocks);
            Assert.Equal(_tables, page.Tables);
            Assert.Equal(null, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Equal(_head, page.Head);

            TearDown();
        }

        //null _head
        [Theory]
        [InlineData("PageName", "UIId", 1, false, false)]
        public void Page_Constructor_WithParametersAllowNullHead(string pageName, string uIId, int id, bool deleted, bool inactive)
        {
            //arrange, act
            SetUp();
            Page page = new Page(pageName, _cards, null, _carousels, _carouselCards, _informationBlocks, _tables, _video, uIId, id, deleted, inactive);

            //assert
            Assert.Equal(pageName, page.PageName);
            Assert.Equal(_cards, page.Cards);
            Assert.Equal(_carousels, page.Carousels);
            Assert.Equal(_carouselCards, page.CarouselCards);
            Assert.Equal(_informationBlocks, page.InformationBlocks);
            Assert.Equal(_tables, page.Tables);
            Assert.Equal(_video, page.Videos);
            Assert.Equal(uIId, page.UIId);
            Assert.Equal(id, page.Id);
            Assert.Equal(deleted, page.Deleted);
            Assert.Equal(inactive, page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
            Assert.Null(page.Head);

            TearDown();
        }


        public void TearDown()
        {
            _cards.Clear();
            _carousels.Clear();
            _carouselCards.Clear();
            _informationBlocks.Clear();
            _tables.Clear();
        }
    }
}
