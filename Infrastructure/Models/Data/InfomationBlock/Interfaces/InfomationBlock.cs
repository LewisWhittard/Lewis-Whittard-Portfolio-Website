using Infrastructure.Models.Data.Shared.Image;

namespace Infrastructure.Models.Data.InfomationBlock.Interfaces
{
    public interface IInfomationBlock
    {
        public List<Image> Images { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public List<Heading> Headings { get; set; }

    }
}
