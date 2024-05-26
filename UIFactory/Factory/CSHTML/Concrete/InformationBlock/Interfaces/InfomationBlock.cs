using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces
{
    public interface IInformationBlock
    {
        public List<Image> Images { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public List<Heading> Headings { get; set; }

        public List<IUI> ReturnContentsAsListIUI();

    }
}
