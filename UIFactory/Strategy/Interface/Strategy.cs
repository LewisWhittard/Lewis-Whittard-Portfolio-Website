using UIFactory.Factory.Concrete.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Strategy.Interface
{
    public interface IUIFactoryStrategy
    {
        public IUIFactory _strategy { get; set; }
        public void SwitchStrategy(IUIFactory UIFactory);
        public List<IConcreteUI> ExecuteByPageName(string PageName);
        public List<IConcreteUI> ExecuteBySearch(string Search);
    }
}
