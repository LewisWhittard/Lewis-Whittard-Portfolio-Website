using Infrastructure.Models.Data.InfomationBlock;

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
            Models.Data.Page.Page page = new Models.Data.Page.Page();
        }

        public 
    }
}
