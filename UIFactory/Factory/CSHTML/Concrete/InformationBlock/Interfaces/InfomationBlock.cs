using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Concrete.InformationBlock.Interfaces
{
    public interface IInformationBlock
    {
        List<Image> Images { get; }
        List<Paragraph> Paragraphs { get; }
        List<Heading> Headings { get; }

        public List<IUI> ReturnContentsAsListIUI();
    }
}
