using UIFactory.Concreate.CSHTML.InfomationBlock.Interfaces;
using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.InfomationBlock
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
