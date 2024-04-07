using SEO.Models.Alt.Interface;
using SEO.Models.JsonLD.Interface;
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
        public UI? UIType { get; set; }
        public string GUID { get; set; }

        private readonly Infrastructure.Models.Data.InfomationBlock.InfomatonBlock _infomatonBlock;
        private readonly List<IAltData> _alt;

        public InfomatonBlock(Infrastructure.Models.Data.InfomationBlock.InfomatonBlock infomatonBlock, List<IJsonLDData> JsonLd, List<IAltData> alt)
        {
            _infomatonBlock = infomatonBlock;
            _alt = alt;
            foreach (var item in _infomatonBlock.Images)
            {
                Image image = new Image(item,alt);
                Images.Add(image);
            }
            foreach (var item in _infomatonBlock.paragraphs)
            {
                Paragraph paragraph = new Paragraph(item);
                paragraphs.Add(paragraph);
            }
            foreach (var item in _infomatonBlock.headings)
            {
                Heading heading = new Heading(item);
            }
            DisplayOrder = _infomatonBlock.Id;
            UIType = UI.InfomationBlock;
        }
    }
}
