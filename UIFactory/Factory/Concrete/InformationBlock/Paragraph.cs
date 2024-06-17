namespace UIFactory.Factory.Concrete.InformationBlock
{
    public class Paragraph
    {
        public Infrastructure.Models.Data.InformationBlock.Paragraph paragraph { get; private set; }

        private readonly Infrastructure.Models.Data.InformationBlock.Paragraph _paragraph;

        public Paragraph(Infrastructure.Models.Data.InformationBlock.Paragraph paragraph)
        {
            _paragraph = paragraph;
            paragraph = _paragraph;
        }
    }
}
