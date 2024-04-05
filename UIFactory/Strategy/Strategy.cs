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

        public IUI Execute(IData data,List<IJsonLDData> jsonLDData)
        {
            return _strategy.CreateUI(data, jsonLDData);
        }

        public IUI Execute(IData data)
        {
            return _strategy.CreateUI(data);
        }

        public List<IUI> ExecuteList(List<IData> data, List<IJsonLDData> jsonLDData)
        {
            List<IUI> uIs = new List<IUI>();

            foreach (var item in data)
            {
                List<IJsonLDData> jsonLD = jsonLDData.Where(x => x.DataId == item.Id && item.UIConcreteType == x.UIConcreteType).ToList();
                IUI uI = _strategy.CreateUI(item);
                uIs.Add(uI);
            }
            
            return uIs;
        }

        public List<IUI> ExecuteList(List<IData> data)
        {
            List<IUI> uIs = new List<IUI>();

            foreach (var item in data)
            {
                IUI uI = _strategy.CreateUI(item);
                uIs.Add(uI);
            }

            return uIs;
        }
    }
}
