using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Interface
{
    public interface IUIFactory
    {
        public IUI CreateUI(IData data);
    }
}
