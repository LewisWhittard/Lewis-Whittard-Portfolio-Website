using Infrastructure.Models.Data.Interface;
using Infrastructure.Models.Interfaces.InfomationBlock;

namespace Infrastructure.Models.Data.InfomationBlock
{
    public class InfomatonBlock : IInfomationBlock, IData
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public bool Inactive { get; set; }
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }
    }
}
