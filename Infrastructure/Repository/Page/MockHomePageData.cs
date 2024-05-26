using Infrastructure.Models.Data.InformationBlock;
using Infrastructure.Models.Data.Table;
using Infrastructure.Models.Data.Shared.Image;
using Infrastructure.Models.Data.CarouselCard;
using Infrastructure.Models.Data.Shared.Card;

namespace Infrastructure.Repository.Page
{
    public class MockHomePageData
    {
        public List<Models.Data.Page.Page> Page { get; set; }

        public List<Models.Data.Page.Page> returnPage()
        {
            return Page;
        }

        public MockHomePageData()
        {
            Heading heading00 = new Heading(0,false,false,"About Me",0,0, "HomePageInformationBlock0Heading0", 1);
            Paragraph paragraph00 = new Paragraph("Having over 5 years experience in the software industry I have worked as a software tester using mostly manual techniques and dabbled with automation. Currently I am transitioning into a support developer role.",1,0,false,false,0, "HomePageInformationBlock0Paragraph0");
            Heading heading01 = new Heading(1, false, false, "Hobbies and Interests", 2, 0, "HomePageInformationBlock0Heading1", 2);
            Paragraph paragraph01 = new Paragraph("I enjoy improving my skill set by doing side projects outside of my day job, which will be displayed on this portfolio site. Some of this stems for my passion for gaming which I have done from a young age. This helped ignite my interest in computing as a whole. I also do kick boxing for both health and enjoyment.", 4, 1, false, false, 0, "HomePageInformationBlock0Paragraph1");
            Image image00 = new Image("LewisWhittard.png", 5,0,false,false, "HomePageInformationBlock0Image0");
            List<Heading> headings0 = new List<Heading>() { heading00, heading01 };
            List<Paragraph> paragraphs0 = new List<Paragraph>() { paragraph00, paragraph01 };
            List<Image> images0 = new List<Image> { image00 };
            InfomatonBlock informationBLock = new InfomatonBlock(0,false,false,images0,paragraphs0,headings0,0,"HomePageInformationBlock0");
            List<InfomatonBlock> informationBLocks =  new List<InfomatonBlock> { informationBLock };

            Header header00 = new Header(0,false,false,0,0, "Qualification", "HomePageTable0Header0");
            Header header01 = new Header(1,false,false,1,0, "Result", "HomePageTable0Header1");
            Header header02 = new Header(2, false, false, 2, 0, "Year", "HomePageTable0Header2");

            //Column column00 = new Column(0,false,false, "Software Development Technician Level 3", 0,0,0, "HomePageTable0Column0");
            //Column column01 = new Column(1, false, false, "Pass", 1, 0, 0, "HomePageTable0Column1");
            //Column column02 = new Column(2, false, false, "2020", 2, 0, 0, "HomePageTable0Column2");
            //Column column03 = new Column(3, false, false, "BTEC Level 3 Extended Diploma in Creative Media Production (Game Development) (QCF)", 0, 1, 0, "HomePageTable0Column3");
            //Column column04 = new Column(4, false, false, "Merit, Merit, Pass", 1, 1, 0, "HomePageTable0Column4");
            //Column column05 = new Column(5, false, false, "2016", 2, 1, 0, "HomePageTable0Column5");
            List<Header> headers0 = new List<Header>() { header00,header01,header02 };
            List<List<Column>> columns0 = new List<List<Column>>()
            {
                //new List<Column>() { column00, column01, column02 },
                //new List<Column>() { column03, column04, column05 }
            };

            Table table0 = new Table(0, false, false, 1, headers0, columns0, "HomePage", "HomePageTable0", "Certifications");

            Header header10 = new Header(3, false, false, 0, 1, "Certification", "HomePageTable1Header0");
            Header header11 = new Header(4, false, false, 1, 1, "Result", "HomePageTable1Header1");
            Header header12 = new Header(5, false, false, 2, 1, "Year", "HomePageTable1Header2");
            //Column column10 = new Column(6, false, false, "ISTQB® Certified Tester, Foundation Level (4.0)", 0, 0, 1, "HomePageTable1Column0");
            //Column column11 = new Column(7, false, false, "Pass", 1, 0, 1, "HomePageTable1Column1");
            //Column column12 = new Column(8, false, false, "2024", 2, 0, 1, "HomePageTable1Column2");
            //Column column13 = new Column(9, false, false, "BCS Level 3 Certificate in Programming (603/1192/7)", 0, 1, 1, "HomePageTable1Column3");
            //Column column14 = new Column(10, false, false, "Pass", 1, 1, 1, "HomePageTable1Column4");
            //Column column15 = new Column(11, false, false, "2019", 2, 1, 1, "HomePageTable1Column5");
            //Column column16 = new Column(12, false, false, "BCS Level 3 Certificate in Software Development Context and Methodologies (603/1191/5)", 0, 2, 1, "HomePageTable1Column6");
            //Column column17 = new Column(13, false, false, "Pass", 1, 2, 1, "HomePageTable1Column7");
            //Column column18 = new Column(14, false, false, "2019", 2, 2, 1, "HomePageTable1Column8");
            List<Header> headers1 = new List<Header>() { header10, header11, header12 };
            List<List<Column>> columns1 = new List<List<Column>>()
            {
                //new List<Column>() { column10, column11, column12 },
                //new List<Column>() { column13, column14, column15 },
                //new List<Column>() { column16, column17, column18 }
            };
            Table table1 = new Table(0,false,false,2,headers1,columns1,"HomePage","HomePageTable0", "Certifications");
            List<Table> tables = new List<Table>()
            {
                table0,
                table1
            };
            
            MockSearchPageData mockSearchPageData = new MockSearchPageData();
            List<Card> cards = mockSearchPageData.ReturnCards();
            CarouselCard carouselCard0 = new CarouselCard(0, false, false,cards,3,"HomeCardCarousel0");
            List<CarouselCard> carouselCards = new List<CarouselCard>()
            {
                carouselCard0
            };
            
            Models.Data.Page.Page page0 = new Models.Data.Page.Page("HomePage",null,null, carouselCards, informationBLocks,tables,null,"HomePage",0,false,false);
            Page = new List<Models.Data.Page.Page>()
            {
                page0
            };
        }
    }
}
