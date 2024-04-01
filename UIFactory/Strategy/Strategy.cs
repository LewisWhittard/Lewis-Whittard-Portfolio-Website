using Infrastructure.Models.Data.Interface;
using UIFactory.Factory.CSHTML.Interface;
using UIFactory.Factory.Interface;
using UIFactory.Strategy.Interface;

namespace UIFactory.Strategy
{
    public class Strategy : IStrategy
    {
        private IUIFactory _strategy { get; set; }

        public Strategy(IUIFactory UIFactory)
        {
            _strategy = UIFactory;
        }

        public void SwitchStrategy(IUIFactory UIFactory)
        {
            _strategy = UIFactory;
        }


    }
}
