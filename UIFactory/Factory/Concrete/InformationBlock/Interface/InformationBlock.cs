using UIFactory.Factory.Concrete.Shared.Image;
namespace UIFactory.Factory.Concrete.InformationBlock.Interface
{
    public interface IInformationBlock
    {
        Infrastructure.Models.Data.InformationBlock.InfomatonBlock InformationBlockData { get; }
        List<SEO.Model.JsonLD.JsonLDData>? JsonLDDatas { get; }
        List<Heading>? Headings { get; }
        List<Paragraph>? Paragraphs { get; }
        List<Image>? Images { get; }
    }
}
