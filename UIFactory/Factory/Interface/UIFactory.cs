using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;

namespace UIFactory.Factory.Interface
{
    public interface IUIFactory
    {
        public IUI CreateUI(IData data);
        public IUI CreateUI(IData data, List<IJsonLDData> JsonLDData);
    }
}
