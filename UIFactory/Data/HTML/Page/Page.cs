using UIFactory.Data.HTML.Interface;
using UIFactory.Data.HTML.Page.Interface;

namespace UIFactory.Data.HTML.Page
{
    public class Page : IPage
    {
        public string Webpage { get; set; }
        public List<IHTML> HTMLs { get; set; }
    }
}
