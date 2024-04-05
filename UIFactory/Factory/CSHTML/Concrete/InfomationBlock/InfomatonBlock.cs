using UIFactory.Factory.CSHTML.Concrete.InfomationBlock.Interfaces;
using UIFactory.Factory.CSHTML.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InfomationBlock
{
    public class InfomatonBlock : IInfomationBlock, ICSHTML, IJsonLD, IUI
    {
        public List<Image> Images { get; set; }
        public List<Paragraph> paragraphs { get; set; }
        public List<Heading> headings { get; set; }
        public int DisplayOrder { get; set; }
        public List<string> JsonLDValues { get; set; }
        public Infrastructure.Models.Data.InfomationBlock.InfomatonBlock _infomatonBlock { get; set; }
        public UI? UIType { get; set; }

        public InfomatonBlock(Infrastructure.Models.Data.InfomationBlock.InfomatonBlock infomatonBlock)
        {
            _infomatonBlock = infomatonBlock;

            foreach (var item in _infomatonBlock.Images)
            {
                Image image = new Image(item);
            }
            foreach (var item in _infomatonBlock.paragraphs)
            {
                Paragraph paragpraph = new Paragraph(item);
            }
            foreach (var item in _infomatonBlock.headings)
            {

            }
            DisplayOrder = _infomatonBlock.Id;
            UIType = UI.InfomationBlock;
        }
    }
}
