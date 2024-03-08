using Infrastructure.Models.Data.InfomationBlock;

namespace JsonCreator.JsonFiles
{
    public class InfomationBlock
    {
        public void HomePage()
        {
            Heading AboutMe = new Heading(0,false,false,"About Me",0,0);
            Paragraph AboutMeparagraph = new Paragraph("Having over 5 years experience in the software industry I have worked as a software tester using mostly manual techniques and dabbled with automation. Currently I am transitioning into a support developer role.",1,0,false,false,0);
            Heading HobbiesAndInterests = new Heading(0, false, false, "Hobbies and Interests", 2,0);
            Paragraph paragraph = new Paragraph("I enjoy improving my skill set by doing side projects outside of my day job, which will be displayed on this portfolio site. Some of this stems for my passion for gaming which I have done from a young age. This helped ignite my interest in computing as a whole. I also do kick boxing for both health and enjoyment.", 1, 0, false, false, 0);
        }
    }
}
