using Infrastructure.Models.Data.Shared.Image;

namespace Infrastructure.Models.Data.InformationBlock.Interfaces
{
    public interface IInformationBlock
    {
        public List<Image> Images { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public List<Heading> Headings { get; set; }

    }
}
