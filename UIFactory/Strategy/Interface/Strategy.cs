using UIFactory.Factory.Interface;

namespace UIFactory.Strategy.Interface
{
    public interface IUIFactoryStrategy
    {
        public IUIFactory _strategy { get; set; }
        public void SwitchStrategy(IUIFactory UIFactory);
        public List<IUI> ExecuteByPageName(string PageName);
    }
}
