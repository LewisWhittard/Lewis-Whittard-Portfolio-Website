using UIFactory.Factory.CSHTML.Concreate.InfomationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concreate.Interface;

namespace UIFactory.Factory.CSHTML.Concreate.InfomationBlock
{
    public class Paragraph : IParagraph, ICSHTML
    {
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
        public UIPartial? UIPartialType { get; set; }
        private readonly Infrastructure.Models.Data.InfomationBlock.Paragraph _paragraph;

        public Paragraph(Infrastructure.Models.Data.InfomationBlock.Paragraph paragraph)
        {
            _paragraph = paragraph;
            Text = _paragraph.Text;
            DisplayOrder = _paragraph.DisplayOrder;
            InfomationBlockid = _paragraph.InfomationBlockid;



        }
    }
}
