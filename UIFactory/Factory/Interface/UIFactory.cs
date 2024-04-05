using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUIFactory
    {
        public List<IUI> CreateUIList(string PageName);
    }
}
