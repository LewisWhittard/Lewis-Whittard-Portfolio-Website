using Infrastructure.Models.Data.Carousel;
using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Data.Page;
using Infrastructure.Models.Data.Shared.Card;
using Infrastructure.Models.Data.Shared.Image;
using Infrastructure.Models.Data.Table;

namespace InfrastructureTests.Ctor
{
    public class PageTests
    {
        private List<Card> _cards { get; set; }
        private List<Carousel> _carousels { get; set; }
        private List<CarouselCard> _carouselCards { get; set; }
        private List<InfomatonBlock> _informationBlocks { get; set; }
        private List<Table> _tables { get; set; }


        public PageTests()
        {
            _cards = new List<Card>();
            _carousels = new List<Carousel>();
            _carouselCards = new List<CarouselCard>();
            _informationBlocks = new List<InfomatonBlock>();
            _tables = new List<Table>();

            List<Image> imagesCards = new List<Image>
                {
                    new Image("Image0Source", 0, 0, false, false, "Image0GUID", 0,null,null),
                    new Image("Image1Source", 1, 1, false, false, "Image1GUID", 1, null, null)
                };

            _cards.Add(new Card(imagesCards[0], "Card0Title", "Card0Description", "Card0Navigation", 0, false, false, 0, "Card0GUID", 1));
            _cards.Add(new Card(imagesCards[1], "Card1Title", "Card1Description", "Card1Navigation", 1, false, false, 1, "Card1GUID", 1));

            List<Image> imagesCarousel0 = new List<Image>
            {
                new Image("Image0Source", 0, 2, false, false, "Image0GUID", null,null, 0),
                new Image("Image1Source", 1, 3, false, false, "Image1GUID", null, null,0)
            };

            List<Image> imagesCarousel1 = new List<Image>
            {
                new Image("Image2Source", 2, 2, false, false, "Image2GUID", null, null,1),
                new Image("Image3Source", 3, 3, false, false, "Image3GUID", null, null,1)
            };

            _carousels.Add(new Carousel(0, false, false, imagesCarousel0, 2, "Carousel0GUID", 1));
            _carousels.Add(new Carousel(1, false, false, imagesCarousel1, 3, "Carousel1GUID", 1));

            _carouselCards.Add(new CarouselCard(0,false,false,_cards,4, "carouselCards0GUID",1));
            _carouselCards.Add(new CarouselCard(1, false, false, _cards, 5, "carouselCards1GUID", 1));

            List<Paragraph> paragraphs1 = new List<Paragraph>
            {
                new Paragraph("Paragraph0Text", 0, 0, false, false, 0,"Paragraph0GUID"),
                new Paragraph("Paragraph1Text", 1, 1, false, false, 0,"Paragraph1GUID"),
            };

            List<Paragraph> paragraphs2 = new List<Paragraph>
            {
                new Paragraph("Paragraph2Text", 0, 2, false, false, 1,"Paragraph2GUID"),
                new Paragraph("Paragraph3Text", 1, 3, false, false, 1,"Paragraph3GUID"),
            };

            List<Heading> headings1 = new List<Heading>
            {
                new Heading(0,false,false,"Heading0Text",0,1,"Heading0GUID",0),
                new Heading(1,false,false,"Heading1Text",1,1,"Heading1GUID",1)
            };

            List<Heading> headings2 = new List<Heading>
            {
                new Heading(2,false,false,"Heading2Text",0,2,"Heading2GUID",0),
                new Heading(3,false,false,"Heading3Text",1,2,"Heading3GUID",1)
            };

            List<Image> imagesInformationBlock0 = new List<Image>
            {
                new Image("Image4Source", 0, 4, false, false, "Image4GUID", null,null, 0),
                new Image("image5Source", 1, 5, false, false, "Image5GUID", null, null,0)
            };

            List<Image> imagesInformationBlock1 = new List<Image>
            {
                new Image("Image6Source", 0, 6, false, false, "Image6GUID", null,null, 0),
                new Image("image7Source", 1, 7, false, false, "Image7GUID", null, null,0)
            };

            _informationBlocks.Add(new InfomatonBlock(0,false,false, imagesInformationBlock0, paragraphs1,headings1,6,"InfomationBlock0GUID",1));
            _informationBlocks.Add(new InfomatonBlock(0, false, false, imagesInformationBlock1, paragraphs1, headings1, 6, "InfomationBlock0GUID", 1));

            List<Header> Headers0 = new List<Header>
            {
                new Header(0, false, false, 0, 0, "Header0Value", "Header0GUID"),
                new Header(1, false, false, 1, 0, "Header1Value", "Header1GUID")
            };

            List<List<Column>> columns0 = new List<List<Column>>()
            {
                new List<Column>
                {
                    new Column(0,false,false,"ValueColumn0",0,0,"GUIDColumn0",0),
                    new Column(1,false,false,"ValueColumn1",1,0,"GUIDColumn1",0)
                },
                new List<Column>
                {
                    new Column(2,false,false,"ValueColumn2",0,0,"GUIDColumn2",1),
                    new Column(3,false,false,"ValueColumn3",1,0,"GUIDColumn3",1)
                }
            };

            List<Header> Headers1 = new List<Header>
            {
                new Header(5, false, false, 0, 1, "Header5Value", "Header5GUID"),
                new Header(6, false, false, 1, 1, "Header6Value", "Header6GUID")
            };

            List<List<Column>> columns1 = new List<List<Column>>()
            {
                new List<Column>
                {
                    new Column(4,false,false,"ValueColumn4",0,1,"GUIDColumn4",0),
                    new Column(5,false,false,"ValueColumn5",1,1,"GUIDColumn5",0)
                },
                new List<Column>
                {
                    new Column(6,false,false,"ValueColumn6",0,1,"GUIDColumn6",1),
                    new Column(7,false,false,"ValueColumn7",1,1,"GUIDColumn7",1)
                }
            };

            _tables = new List<Table>
            {
                new Table(0,false,false,0,Headers0,columns0,"gUIDTable0","Table0Title",0),
                new Table(1, false, false, 1, Headers1, columns1, "gUIDTable1", "Table1Title", 1)
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
            Assert.Null(page.GUID);
            Assert.Equal(0, page.Id);
            Assert.False(page.Deleted);
            Assert.False(page.Inactive);
            Assert.Equal(UIConcrete.Page, page.UIConcreteType);
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
