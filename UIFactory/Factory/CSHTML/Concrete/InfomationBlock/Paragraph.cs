using UIFactory.Factory.CSHTML.Concrete.InfomationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InfomationBlock
{
    public class Paragraph : IParagraph, ICSHTML, IUI
    {
        public string Text { get; set; }
        public int? DisplayOrder { get; set; }
        public int InfomationBlockid { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

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
