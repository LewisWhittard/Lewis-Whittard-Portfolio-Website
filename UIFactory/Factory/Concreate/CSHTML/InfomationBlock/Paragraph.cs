using UIFactory.Factory.Concreate.CSHTML.InfomationBlock.Interfaces;
using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.InfomationBlock
{
    public class Paragraph : IParagraph, ICSHTML
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int Id { get; set; }
        public int InfomationBlockid { get; set; }
        private readonly Infrastructure.Models.Data.InfomationBlock.Paragraph _paragraph;

        public Paragraph(Infrastructure.Models.Data.InfomationBlock.Paragraph paragraph)
        {
            _paragraph = paragraph;
            Text = _paragraph.Text;
            DisplayOrder = _paragraph.DisplayOrder;
            Id = _paragraph.Id;
            InfomationBlockid = _paragraph.InfomationBlockid;



        }
    }
}
