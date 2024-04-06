using UIFactory.Factory.Interface;
using UIFactory.Strategy.Interface;

namespace UIFactory.Strategy
{
    public class UIFactoryStrategy : IUIFactoryStrategy
    {
        public IUIFactory _strategy { get; set; }

        public UIFactoryStrategy(IUIFactory UIFactory)
        {
            _strategy = UIFactory;
        }

        public void SwitchStrategy(IUIFactory UIFactory)
        {
            _strategy = UIFactory;
        }

        public List<IUI> ExecuteByPageName(string PageName)
        {
            return _strategy.CreateUIListByPageName(PageName);
        }
    }
}
