using UIFactory.Factory.Concrete.InformationBlock.Interface;

namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class Paragraph : IParagraph
    {
        public Infrastructure.Models.Data.InformationBlock.Paragraph ParagraphData { get; private set; }

        private readonly Infrastructure.Models.Data.InformationBlock.Paragraph _paragraph;

        public Paragraph(Infrastructure.Models.Data.InformationBlock.Paragraph paragraph)
        {
            _paragraph = paragraph;
            paragraph = _paragraph;
        }
    }
}
