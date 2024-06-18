using UIFactory.Factory.Concrete.Interface;
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

        public List<IConcreteUI> ExecuteByPageName(string PageName)
        {
            return (List<IConcreteUI>)_strategy.CreateUIListByPageName(PageName).OrderBy(x => x.DisplayOrder);
        }
    }
}
