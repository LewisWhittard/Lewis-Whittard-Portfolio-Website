using Infrastructure.Models.Data.InfomationBlock;
using Infrastructure.Models.Data.Table;

namespace Infrastructure.Repository.Page
{
    public class MockHomePageData
    {
        public MockHomePageData()
        {
            Heading heading = new Heading(0,false,false,"About Me",0,0, "HomePageInfomationBlock0Heading0", 1);
            Paragraph paragraph = new Paragraph("Having over 5 years experience in the software industry I have worked as a software tester using mostly manual techniques and dabbled with automation. Currently I am transitioning into a support developer role.",1,0,false,false,0, "HomePageInfomationBlock0Paragraph0");
            Heading heading2 = new Heading(1, false, false, "Hobbies and Interests", 2, 0, "HomePageInfomationBlock0Heading1", 2);
            Paragraph paragraph2 = new Paragraph("Having over 5 years experience in the software industry I have worked as a software tester using mostly manual techniques and dabbled with automation. Currently I am transitioning into a support developer role.", 4, 1, false, false, 0, "HomePageInfomationBlock0Paragraph1");
            Image image = new Image("LewisWhittard.png", 5,0,false,false, "HomePageInfomationBlock0Image0");
            List<Heading> headings = new List<Heading>() { heading, heading2 };
            List<Paragraph> paragraphs = new List<Paragraph>() { paragraph,paragraph2 };
            List<Image> images = new List<Image> { image };
            InfomatonBlock infomationBLock = new InfomatonBlock(0,false,false,images,paragraphs,headings,0,"HomePageInfomationBlock0");
            List<InfomatonBlock> infomationBLocks =  new List<InfomatonBlock> { infomationBLock };

            Header header0 = new Header(0,false,false,0,0, "Qualification", "HomePageTable0Header0");
            Header header1 = new Header(1,false,false,1,0, "Result", "HomePageTable0Header1");
            Header header2 = new Header(2, false, false, 2, 0, "Year", "HomePageTable0Header2");

            Column column0 = new Column(0,false,false, "Software Development Technician Level 3", 0,0,0, "HomePageTable0Column0");
            Column column1 = new Column(1, false, false, "Pass", 1, 0, 0, "HomePageTable0Column1");
            Column column2 = new Column(2, false, false, "2020", 2, 0, 0, "HomePageTable0Column2");
            Column column3 = new Column(3, false, false, "BTEC Level 3 Extended Diploma in Creative Media Production (Game Development) (QCF)", 0, 1, 0, "HomePageTable0Column3");
            Column column4 = new Column(4, false, false, "Merit, Merit, Pass", 1, 1, 0, "HomePageTable0Column4");
            Column column5 = new Column(5, false, false, "2016", 2, 1, 0, "HomePageTable0Column5");
            List<Header> headers0 = new List<Header>() { header0,header1,header2 };
            List<List<Column>> columns0 = new List<List<Column>>()
            {
                new List<Column>() { column0, column1, column2 },
                new List<Column>() { column3, column4, column5 }
            };
            Table table1 = new Table(0,false,false,1,headers0,columns0,"HomePage","HomePageTable0");

            List<Table> tables = new List<Table>()
            {
                table1
            };

            Models.Data.Page.Page page = new Models.Data.Page.Page("HomePage",null,null,null,infomationBLocks,null,"HomePage",0,false,false);
        }

        public 
    }
}
