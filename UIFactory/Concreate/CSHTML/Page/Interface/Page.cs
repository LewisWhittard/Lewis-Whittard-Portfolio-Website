using UIFactory.Concreate.CSHTML.Interface;

namespace UIFactory.Concreate.CSHTML.Page.Interface
{
    public interface IPage
    {
        public string Webpage { get; set; }
        public List<IHTML> HTMLs { get; set; }
    }
}
