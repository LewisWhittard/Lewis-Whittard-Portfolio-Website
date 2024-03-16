using UIFactory.Data.HTML.InfomationBlock.Interfaces;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.InfomationBlock
{
    public class InfomatonBlock : IInfomationBlock, IHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
    }
}
