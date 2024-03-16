using Infrastructure.Models.Data.InfomationBlock;

namespace Infrastructure.Models.Interfaces.InfomationBlock
{
    public interface IInfomationBlock
    {
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }

    }
}
