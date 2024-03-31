using UIFactory.Factory.Concreate.CSHTML.Interface;
using UIFactory.Factory.Concreate.CSHTML.Page.Interface;

namespace UIFactory.Factory.Concreate.CSHTML.Page
{
    public class Page : IPage
    {
        public string Webpage { get; set; }
        public List<ICSHTML> HTMLs { get; set; }
    }
}
