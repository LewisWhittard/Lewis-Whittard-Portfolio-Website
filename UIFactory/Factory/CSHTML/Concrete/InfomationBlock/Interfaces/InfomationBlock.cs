using UIFactory.Factory.CSHTML.Concrete.InfomationBlock;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InfomationBlock.Interfaces
{
    public interface IInfomationBlock
    {
        public List<Image> Images { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public List<Heading> Headings { get; set; }

        public List<IUI> ReturnContentsAsListIUI();

    }
}
