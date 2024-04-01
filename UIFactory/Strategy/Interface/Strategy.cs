using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.CSHTML.Concreate.Interface;
using UIFactory.Factory.CSHTML.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Strategy.Interface
{
    public interface IStrategy
    {
        public void SwitchStrategy(IUIFactory UIFactory);
    }
}
