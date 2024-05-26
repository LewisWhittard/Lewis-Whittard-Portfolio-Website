using UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock
{
    public class Paragraph : IParagraph, ICSHTML, IUI
    {
        public string Text { get; set; }
        public int? DisplayOrder { get; set; }
        public int InformationBlockid { get; set; }
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.InformationBlock.Paragraph _paragraph;

        public Paragraph(Infrastructure.Models.Data.InformationBlock.Paragraph paragraph)
        {
            _paragraph = paragraph;
            Text = _paragraph.Text;
            DisplayOrder = _paragraph.DisplayOrder;
            InformationBlockid = _paragraph.InformationBlockid;



        }
    }
}
