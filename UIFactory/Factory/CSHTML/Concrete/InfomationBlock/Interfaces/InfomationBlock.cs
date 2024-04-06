using UIFactory.Factory.CSHTML.Concrete.InfomationBlock;

namespace UIFactory.Factory.CSHTML.Concrete.InfomationBlock.Interfaces
{
    public interface IInfomationBlock
    {
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }
        public int DisplayOrder { get; set; }

    }
}
