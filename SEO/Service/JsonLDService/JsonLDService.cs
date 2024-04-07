using Infrastructure.Models.Data.Interface;
using SEO.Models.JsonLD.Interface;
using SEO.Service.JsonLDService.Interface;

namespace SEO.Service.JsonLDService
{
    public class JsonLDService : IJsonLDService
    {
        public List<IJsonLDData> GetByPageName(string pageName, IData data)
        {
            return GetByPageName(pageName).Where(x => x.SuperClassDataId == data.Id && data.UIConcreteType == x.UIConcreteType).ToList();
        }

        public List<IJsonLDData> GetByPageName(string pageName)
        {
            return null;
        }
    }
}
