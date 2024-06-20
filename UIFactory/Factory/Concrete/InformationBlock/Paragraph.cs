using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concrete.InformationBlock.Interface;
using UIFactory.Factory.Concrete.Interface;

namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class Paragraph : IParagraph, IConcreteUI
    {
        public Infrastructure.Models.Data.InformationBlock.Paragraph ParagraphData { get; private set; }
        public int DisplayOrder { get; private set; }
        public UIConcrete UIConcreteType { get; private set; }

        private readonly Infrastructure.Models.Data.InformationBlock.Paragraph _paragraph;

        public Paragraph(Infrastructure.Models.Data.InformationBlock.Paragraph paragraph)
        {
            _paragraph = paragraph;
            ParagraphData = _paragraph;
            DisplayOrder = (int)_paragraph.DisplayOrder;
            UIConcreteType = (UIConcrete)_paragraph.UIConcreteType;
        }
    }
}
