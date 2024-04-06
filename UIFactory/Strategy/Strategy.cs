using UIFactory.Factory.Interface;
using UIFactory.Strategy.Interface;

namespace UIFactory.Strategy
{
    public class Strategy : IStrategy
    {
        public IUIFactory _strategy { get; set; }

        public Strategy(IUIFactory UIFactory)
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
