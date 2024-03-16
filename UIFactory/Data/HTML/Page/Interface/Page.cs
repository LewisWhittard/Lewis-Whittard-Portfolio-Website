using UIFactory.Data.HTML.InfomationBlock;
using UIFactory.Data.HTML.Interface;

namespace UIFactory.Data.HTML.Page.Interface
{
    public interface IPage
    {
        public string Webpage { get; set; }
        public List<IHTML> HTMLs { get; set; }

    }
}
