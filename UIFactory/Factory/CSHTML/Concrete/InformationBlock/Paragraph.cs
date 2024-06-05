using UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock
{
    public class Paragraph : IParagraph, ICSHTML, IUI
    {
        public string Text { get; private set; }
        public int? DisplayOrder { get; private set; }
        public int InformationBlockid { get; private set; }
        public UI? UIType { get; private set; }
        public string GUID { get; private set; }

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
