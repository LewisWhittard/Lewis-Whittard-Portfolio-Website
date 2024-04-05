using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using System.Data;
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

        public List<IUI> Execute(string PageName)
        {
            return null;
        }
    }
}
