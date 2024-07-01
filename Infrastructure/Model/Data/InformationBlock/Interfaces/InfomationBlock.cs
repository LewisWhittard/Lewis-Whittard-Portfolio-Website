using Infrastructure.Models.Data.Shared.Image;

namespace Infrastructure.Models.Data.InformationBlock.Interfaces
{
    public interface IInformationBlock
    {
        List<Image> Images { get; }
        List<Paragraph> Paragraphs { get; }
        List<Heading> Headings { get; }
        int PageId { get; }
    }
}
