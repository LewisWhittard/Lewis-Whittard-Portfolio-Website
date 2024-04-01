using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using UIFactory.Factory.Interface;

namespace UIFactory.Factory.CSHTML.Interface
{
    public interface IUIFactory
    {
        public IUI CreateUI(IData data);
        public IUI CreateUI(IData data,List<IJsonLDData> JsonLDData);
    }
}
