using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Strategy.Interface
{
    public interface IStrategy
    {
        public IUIFactory _strategy { get; set; }
        public void SwitchStrategy(IUIFactory UIFactory);
        public IUI Exicute(IData data, List<IJsonLDData> JsonLDData);
        public IUI Exicute(IData data);
        public List<IUI> ExicuteList(List<IData> data, List<IJsonLDData> JsonLDData);
        public List<IUI> ExicuteList(List<IData> data);
    }
}
