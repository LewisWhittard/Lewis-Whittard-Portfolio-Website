using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Strategy.Interface
{
    public interface IStrategy
    {
        public IUIFactory _strategy { get; set; }
        public void SwitchStrategy(IUIFactory UIFactory);
        public IUI Execute(IData data, List<IJsonLDData> JsonLDData);
        public IUI Execute(IData data);
        public List<IUI> ExecuteList(List<IData> data, List<IJsonLDData> JsonLDData);
        public List<IUI> ExecuteList(List<IData> data);
    }
}
