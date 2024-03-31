using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Concreate.CSHTML.InfomationBlock.Interfaces;
using UIFactory.Factory.Concreate.CSHTML.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.InfomationBlock
{
    public class InfomatonBlock : IInfomationBlock, ICSHTML, IJsonLD
    {
        public int Id { get; set; }
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public Infrastructure.Models.Data.InfomationBlock.InfomatonBlock _InfomatonBlock { get; set; }
        public UIPartial? UIPartialType { get; set; }

        public InfomatonBlock(Infrastructure.Models.Data.InfomationBlock.InfomatonBlock infomatonBlock)
        {
            _InfomatonBlock = infomatonBlock;

            foreach (var item in _InfomatonBlock.Images)
            {
                Image image = new Image(item);
            }
            foreach (var item in _InfomatonBlock.paragraphs)
            {
                Paragraph paragpraph = new Paragraph(item);
            }
            foreach (var item in _InfomatonBlock.headings)
            {

            }
            DisplayOrder = _InfomatonBlock.Id;
            UIPartialType = UIPartial.InfomationBlock;
        }
    }
}
