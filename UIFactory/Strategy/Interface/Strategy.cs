using UIFactory.Factory.Interface;

namespace UIFactory.Strategy.Interface
{
    public interface IStrategy
    {
        public IUIFactory _strategy { get; set; }
        public void SwitchStrategy(IUIFactory UIFactory);
        public List<IUI> Execute(string PageName);
    }
}
