using UIFactory.Concreate.CSHTML.Interface;
using UIFactory.Concreate.CSHTML.Page.Interface;

namespace UIFactory.Concreate.CSHTML.Page
{
    public class Page : IPage
    {
        public string Webpage { get; set; }
        public List<IHTML> HTMLs { get; set; }
    }
}
